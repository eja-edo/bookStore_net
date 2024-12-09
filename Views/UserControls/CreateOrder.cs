using BookStore.Controllers;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
using BookStore.Views.Forms;
using BookStore.Views.MyComponent;
using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.UserControls
{
    public partial class CreateOrder : UserControl
    {
        private bool isDone;
        private OrderController _controller;

        private ListOrder ListOrder;
        private buttonOrder ButtonOrder;
        private createOrders createOrders;
        public CreateOrder()
        {
            InitializeComponent();
            _controller = new OrderController(this);
            Items = new List<ItemProductOrder>();
            isDone = false;
            //Items = new List<ItemProductOrder>();
            //setItemOrder(new ProductViewModel
            //{
            //    ProductID = 2,
            //    StockLevel = 10,
            //    Price = 100000,

            //});
            //setItemOrder(new ProductViewModel
            //{
            //    ProductID = 1,
            //    StockLevel = 10,
            //    Price = 100000,

            //});
        }

        public CreateOrder(ListOrder listOrder,createOrders createOrders , buttonOrder buttonOrder) :this()
        {
            this.ListOrder = listOrder; 
            this.ButtonOrder = buttonOrder;
            this.createOrders = createOrders;
        }
        public void setDataList(Order order)
        {
            ListOrder.AddData(order);
        }


        private List<ItemProductOrder> Items;

        public List<OrderItem> GetListItem()
        {
            List<OrderItem> ListItem = new List<OrderItem>();

            // Kiểm tra Items không null và có phần tử
            if (Items != null && Items.Count > 0)
            {
                foreach (ItemProductOrder item in Items)
                {
                    OrderItem orderItem = item.GetOrderItem();
                    ListItem.Add(orderItem);

                    // Hiển thị thông tin về OrderItem được thêm vào (có thể thay đổi thông tin tùy ý)
                    MessageBox.Show($"ProductID: {orderItem.ProductId}, Quantity: {orderItem.Quantity}, Price: {orderItem.UnitPrice}", "Order Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Kiểm tra và hiển thị số lượng phần tử trong danh sách ListItem
            MessageBox.Show($"Total items added: {ListItem.Count}", "Total Items", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return ListItem; // Trả về danh sách OrderItem
        }



        public void setItemOrder(ProductViewModel product)
        {
            if (Items.Count > 0)
            {
                // Kiểm tra xem ProductID có tồn tại trong danh sách Items hay không
                var existingItem = Items.FirstOrDefault(item => item._Product.ProductID == product.ProductID);

                if (existingItem != null)
                {
                    // Nếu sản phẩm đã có trong danh sách, hiển thị thông báo
                    MessageBox.Show("Sản phẩm đã có trong đơn hàng.");
                    return;
                }
            }

            // Tạo mới một ItemProductOrder
            ItemProductOrder newItem = new ItemProductOrder(product, this)
            {
                Padding = new Padding(0, 0, 10, 0),
                Dock = DockStyle.Fill
            };

            // Tăng số lượng hàng lên
            tableLayoutPanel1.RowCount++;

            // Chèn một hàng mới vào đầu với chiều cao cố định là 85px
            tableLayoutPanel1.RowStyles.Insert(0, new RowStyle(SizeType.Absolute, 118F));

            // Thêm hàng mới vào dòng đầu tiên
            tableLayoutPanel1.Controls.Add(newItem, 0, 0);

            // Thêm ItemProductOrder vào danh sách Items
            Items.Insert(0, newItem);
            biling();
        }

        public void biling()
        {
            // Biến lưu trữ tổng giá trị đơn hàng
            decimal totalOrderValue = 0;

            // Duyệt qua từng ItemProductOrder trong danh sách Items
            foreach (var item in Items)
            {
                // Lấy tổng giá trị của sản phẩm từ phương thức getTotal
                decimal itemTotal = item.getTotal();

                // Cộng tổng giá trị của sản phẩm vào tổng giá trị đơn hàng
                totalOrderValue += itemTotal;
            }

            // Hiển thị tổng giá trị đơn hàng trên giao diện
            inpTotalPrice.Text = Format.formatPrice(totalOrderValue);

            // Xử lý chiết khấu
            if (float.TryParse(inpDiscount.Text, out float discount))
            {
                // Chuyển đổi discount từ phần trăm sang giá trị thực
                discount = discount / 100;

                // Tính tổng giá trị sau chiết khấu
                decimal total = totalOrderValue - (totalOrderValue * (decimal)discount);

                // Hiển thị tổng giá trị sau chiết khấu
                inpTotal.Text = Format.formatPrice(total);
            }
            else
            {
                // Nếu discount không hợp lệ, hiển thị thông báo lỗi
                MessageBox.Show("Chiết khấu không hợp lệ. Vui lòng nhập giá trị hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal getInpTotal()
        {
            return Format.formatPrice_StrToDec(inpTotalPrice.Text);
        }
        public decimal getInpDiscount()
        {
            decimal discountValue;
            bool isValid = decimal.TryParse(inpDiscount.Text, out discountValue);
            return discountValue;
        }
        public string GetPaymentMethod()
        {
            // Kiểm tra nếu ComboBox không rỗng và có giá trị được chọn
            if (cbPaymentMethod.SelectedItem != null)
            {
                string selectedPaymentMethod = cbPaymentMethod.SelectedItem.ToString();

                // Kiểm tra nếu giá trị được chọn là "Phương thức thanh toán"
                if (selectedPaymentMethod == "Phương thức thanh toán")
                {
                    // Chọn "Tiền mặt" nếu chưa chọn phương thức thanh toán
                    cbPaymentMethod.SelectedItem = "Tiền mặt";
                    return "Tiền mặt"; // Trả về giá trị "Tiền mặt"
                }

                return selectedPaymentMethod; // Trả về phương thức thanh toán đã chọn
            }
            else
            {
                return string.Empty; // Trả về chuỗi rỗng nếu không có giá trị được chọn
            }
        }

        public string getNote()
        {
            if (InpNote.Text != null)
            {
                return InpNote.Text;
            }
            else return string.Empty;
        }


        private void inpDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím Enter được nhấn
            if (e.KeyCode == Keys.Enter)
            {
                // Kiểm tra giá trị nhập vào
                decimal discountValue;
                bool isValid = decimal.TryParse(inpDiscount.Text, out discountValue);

                if (isValid && discountValue > 100)
                {
                    // Nếu giá trị nhập vào lớn hơn 100, hiển thị thông báo
                    MessageBox.Show("Giá trị không được lớn hơn 100.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Ngừng việc nhập liệu và không thực hiện tiếp hành động
                    e.SuppressKeyPress = true;

                    // Tùy chọn: Đưa tiêu điểm lại vào TextBox để người dùng chỉnh sửa lại
                    inpDiscount.Focus();
                }
                else
                {
                    // Nếu giá trị hợp lệ và không vượt quá 100, tiếp tục xử lý
                    biling();
                    this.SelectNextControl((Control)sender, true, true, true, true);
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _controller.ClickOrder();
        }

        public void setDelete()
        {
            if (createOrders != null && ButtonOrder != null)
            {
                createOrders.deleteOrderTemp(ButtonOrder);
            }else
            {
                MessageBox.Show("Lỗi tự đóng hóa đơn, vui lòng đóng thủ công!");
            }

        }
    }
}
