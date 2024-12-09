using BookStore.Controllers;
using BookStore.Models.Data;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using Guna.UI2.AnimatorNS;
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
    public partial class ListProduct : UserControl
    {
        ListProductController controller;
        public ListProduct()
        {
            InitializeComponent();
            // Khởi tạo controller
            controller = new ListProductController(this);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem ô được nhấn có nằm trong cột thứ 5 hay không
            if (e.ColumnIndex == 7 && e.RowIndex >= 0) // Cột thứ 7 (index bắt đầu từ 0)
            {
                int rowIndex = e.RowIndex; // Chỉ số hàng của ô được nhấn
                var idValue = guna2DataGridView1.Rows[rowIndex].Cells["productID"].Value;

                // Hiển thị hộp thoại xác nhận xóa sản phẩm
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa sản phẩm {rowIndex + 1}?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
                {
                    if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                    {
                        bool isDeleted = ProductDAO.DeleteProduct(id);
                        if (isDeleted)
                        {
                            // Cập nhật UI nếu cần, ví dụ xóa dòng trong DataGridView
                            guna2DataGridView1.Rows.RemoveAt(rowIndex);
                            MessageBox.Show("Sản phẩm đã được xóa thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa sản phẩm.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hành động xóa đã bị hủy.");
                }
            }
            else if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {

                int rowIndex = e.RowIndex; // Chỉ số hàng của ô được nhấn
                var idValue = guna2DataGridView1.Rows[rowIndex].Cells["productID"].Value;

                if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                {
                    MessageBox.Show($"chi tiết sản phẩm {rowIndex + 1}");
                    UpdateProduct updateProduct = new UpdateProduct(this , id)
                    {
                        Dock = DockStyle.Fill,           // Đặt Dock để lấp đầy container
                        Location = new Point(0, 0),      // Vị trí bắt đầu
                        Name = "updateProduct",          // Tên của UserControl
                        Size = new Size(889, 574),       // Kích thước (nếu cần)
                        TabIndex = 10                    // TabIndex (nếu cần)
                    };
                
                    this.Controls.Add(updateProduct);
                    updateProduct.BringToFront();
                }
            }
            
        }


        private void ListProduct_Load(object sender, EventArgs e)
        {
            controller.LoadData();
        }

        public void SetProductData(List<ProductViewModel> products)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            guna2DataGridView1.Rows.Clear();

            // Lặp qua danh sách sản phẩm và thêm vào DataGridView
            foreach (var product in products)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();  // Thêm một hàng mới
                // Create the full path to the image (combine relative path with the application path)
                string relativePath = product.UrlImg; // This assumes you have ProductImage as relative path
                string fullPath = Path.Combine(Application.StartupPath, relativePath);  // Get the full path

                // Check if the image exists
                if (File.Exists(fullPath))
                {
                    // Set the image to the respective cell
                    guna2DataGridView1.Rows[rowIndex].Cells["img"].Value = Image.FromFile(fullPath);  // Assuming ProductImage is the image column
                }
                else
                {
                    // If the image doesn't exist, you could set a default image or handle the error
                    guna2DataGridView1.Rows[rowIndex].Cells["img"].Value = null; // Or set a default image
                }

                // Điền các giá trị của sản phẩm vào các ô tương ứng trong hàng mới
                guna2DataGridView1.Rows[rowIndex].Cells["productID"].Value = product.ProductID;
                guna2DataGridView1.Rows[rowIndex].Cells["ProductName"].Value = product.Name;
                guna2DataGridView1.Rows[rowIndex].Cells["price"].Value = product.Price;
                guna2DataGridView1.Rows[rowIndex].Cells["stock"].Value = product.StockLevel;
                guna2DataGridView1.Rows[rowIndex].Cells["categories"].Value = product.CategoryName;
                guna2DataGridView1.Rows[rowIndex].Cells["info"].Value = Properties.Resources.edit;
                guna2DataGridView1.Rows[rowIndex].Cells["delete"].Value = Properties.Resources.bin;
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        public void addData(ProductViewModel product)
        {

            // Kiểm tra nếu ProductID đã tồn tại trong DataGridView
            bool exists = false;
            int rowIndex = -1;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                // Kiểm tra giá trị của cột "productID" trong mỗi dòng
                if (row.Cells["productID"].Value != null && (int)row.Cells["productID"].Value == product.ProductID)
                {
                    exists = true;
                    rowIndex = row.Index;
                    break;
                }
            }

            if (!exists)
            {
                // Tạo mới dòng nếu ProductID chưa tồn tại
                rowIndex = guna2DataGridView1.Rows.Add();
            }

            string relativePath = product.UrlImg; // This assumes you have ProductImage as relative path
            string fullPath = Path.Combine(Application.StartupPath, relativePath);  // Get the full path

            // Check if the image exists
            if (File.Exists(fullPath))
            {
                // Set the image to the respective cell
                guna2DataGridView1.Rows[rowIndex].Cells["img"].Value = Image.FromFile(fullPath);  // Assuming ProductImage is the image column
            }
            else
            {
                // If the image doesn't exist, you could set a default image or handle the error
                guna2DataGridView1.Rows[rowIndex].Cells["img"].Value = null; // Or set a default image
            }

            guna2DataGridView1.Rows[rowIndex].Cells["productID"].Value = product.ProductID;
            guna2DataGridView1.Rows[rowIndex].Cells["ProductName"].Value = product.Name;
            guna2DataGridView1.Rows[rowIndex].Cells["price"].Value = product.Price;
            guna2DataGridView1.Rows[rowIndex].Cells["stock"].Value = product.StockLevel;
            guna2DataGridView1.Rows[rowIndex].Cells["categories"].Value = product.CategoryName;
            guna2DataGridView1.Rows[rowIndex].Cells["info"].Value = Properties.Resources.edit;
            guna2DataGridView1.Rows[rowIndex].Cells["delete"].Value = Properties.Resources.bin;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct(this)
            {
                Dock = DockStyle.Fill,           // Đặt Dock để lấp đầy container
                Location = new Point(0, 0),      // Vị trí bắt đầu
                Name = "updateProduct",          // Tên của UserControl
                Size = new Size(889, 574),       // Kích thước (nếu cần)
                TabIndex = 10                    // TabIndex (nếu cần)
            };
            this.Controls.Add(updateProduct);
            updateProduct.BringToFront();
        }
    }
}
