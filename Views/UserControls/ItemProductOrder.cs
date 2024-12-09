using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.UserControls
{
    public partial class ItemProductOrder : UserControl
    {
        private CreateOrder parent;
        public ItemProductOrder()
        {

            InitializeComponent();
            
        }

        public ProductViewModel _Product { get; set; }
        public ItemProductOrder(ProductViewModel product, CreateOrder parent) : this()
        {
            _Product = product;
            this.parent = parent;
            setData();
        }

        public OrderItem GetOrderItem()
        {
            return new OrderItem
            {
                ProductId = _Product.ProductID,
                UnitPrice = _Product.Price,
                Quantity = (int)upDownQuantity.Value
            };
        }

        public void setData()
        {
            // Đảm bảo thông tin về sản phẩm được hiển thị đầy đủ
            LabID.Text = _Product.ProductID.ToString();
            LabName.Text = _Product.Name;

            // Cập nhật mức tối đa của upDownQuantity nếu StockLevel có giá trị
            upDownQuantity.Maximum = _Product.StockLevel.HasValue ? (decimal)_Product.StockLevel.Value : 0;

            // Cập nhật mức stock tối đa trên giao diện
            labMaxStrock.Text = _Product.StockLevel.HasValue ? _Product.StockLevel.Value.ToString() : "0";

            // Định dạng giá hiện tại của sản phẩm
            labCurPrice.Text = Utilities.Format.formatPrice(_Product.Price);

            // Tính tổng giá trị dựa trên số lượng và giá sản phẩm
            decimal totalPrice = upDownQuantity.Value * _Product.Price;

            // Hiển thị tổng giá trị trên giao diện
            labTotal.Text = Utilities.Format.formatPrice(totalPrice);
        }


        private CancellationTokenSource _cancellationTokenSource;
        private async void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Hủy bỏ các tác vụ trước đó nếu có sự thay đổi giá trị
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
                // Chờ 1 giây sau khi thay đổi giá trị trước khi tính toán
                await Task.Delay(1000, cancellationToken);

                // Tính tổng giá trị dựa trên số lượng và giá sản phẩm
                decimal totalPrice = upDownQuantity.Value * _Product.Price;

                // Hiển thị tổng giá trị trên giao diện
                labTotal.Text = Utilities.Format.formatPrice(totalPrice);

                parent.biling();
                // Gọi phương thức tính toán tổng từ lớp cha nếu cần
                System.Diagnostics.Debug.WriteLine($"Tổng giá trị sau 1 giây: {totalPrice}");
            }
            catch (TaskCanceledException)
            {
                // Nếu tác vụ bị hủy bỏ do sự thay đổi giá trị tiếp theo, thì không làm gì
            }
        }

        public decimal getTotal()
        {
            return Utilities.Format.formatPrice_StrToDec(labTotal.Text);
        }

    }
}
