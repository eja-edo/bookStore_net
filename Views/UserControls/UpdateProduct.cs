using BookStore.Controllers;
using BookStore.Models.Entity;
using BookStore.Utilities;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.UserControls
{
    public partial class UpdateProduct : UserControl
    {
        private bool isBook;
        private UpdateProductController Controller;
        public int ProductId { set; get; }
        public UpdateProduct()
        {
            InitializeComponent();
            Controller = new UpdateProductController(this);
            isBook = false;
        }
        public UpdateProduct(int id) : this()
        {
            this.ProductId = id;
            Controller.LoadProductDetails();
        }



        // Set Product ID
        public void SetProductId(string productId)
        {
            inpProductID.Text = productId;
        }

        // Set Product Name
        public void SetProductName(string productName)
        {
            inpProductName.Text = productName;
        }
        public String GetProductName()
        {
            return inpProductName.Text;
        }

        // Set ISBN
        public void SetISBN(string isbn)
        {
            inpISBN.Text = isbn;
        }
        public string GetISBN()
        {
            return inpISBN.Text;
        }

        // Set Publisher
        public void SetPublisher(string publisher)
        {
            inpPublisher.Text = publisher;
        }

        // Set Publish Year
        public void SetPublishYear(string publishYear)
        {
            inpPublishYear.Text = publishYear;
        }

        // Set Page Count
        public void SetPageCount(string pageCount)
        {
            inpPageCount.Text = pageCount;
        }

        // Set Stock
        public void SetStock(string stock)
        {
            inpStock.Text = stock;
        }

        // Set Price
        public void SetPrice(string price)
        {
            inpPrice.Text = price;
        }
        public decimal getPrice()
        {
            return Format.formatPrice_StrToDec(inpPrice.Text);
        }

        // Set Create Date
        public void SetCreateDate(DateTime createDate)
        {
            inpCreateDate.Value = createDate;
        }

        // Set Year Update
        public void SetYearUpdate(DateTime yearUpdate)
        {
            inpYearUpdate.Value = yearUpdate;
        }

        // Set Description
        public void SetDescription(string description)
        {
            inpDescription.Text = description;
        }
        public string GetDescription()
        {
            return inpDescription.Text;
        }

        // Set Category
        public void SetCategory(string category)
        {
            comboCategories.Items.Add(category);
            comboCategories.SelectedItem = category;
        }

        // Set Author
        public void SetAuthors(List<BookAuthor> authors)
        {
            // Xóa các mục cũ trong ListBox
            listAuthor.Items.Clear();

            if (authors != null && authors.Count > 0)
            {
                // Lặp qua danh sách tác giả và thêm vào ListBox
                foreach (var author in authors)
                {
                    // Định dạng mỗi dòng: Tên Tác Giả - Chức Vụ
                    string displayText = $"{author.Name} - {author.Role}";
                    listAuthor.Items.Add(displayText);
                }
            }
            else
            {
                // Trường hợp danh sách rỗng hoặc null
                listAuthor.Items.Add("Không có tác giả nào.");
            }
        }

        public void AddImagesToFlowLayoutPanel(List<string> imagePaths)
        {
            // Xóa các hình ảnh cũ (nếu cần)
            flowLayoutPanel1.Controls.Clear();

            // Lặp qua danh sách đường dẫn hình ảnh
            foreach (var path in imagePaths)
            {
                // Tạo một PictureBox mới
                var pictureBox = new Guna.UI2.WinForms.Guna2PictureBox
                {
                    BackColor = Color.White,
                    BorderRadius = 12,
                    FillColor = Color.FromArgb(255, 128, 128),
                    ImageRotate = 0F,
                    Size = new Size(95, 95),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Margin = new Padding(10),
                };

                // Kiểm tra và tải hình ảnh từ đường dẫn cục bộ
                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        pictureBox.Image = Image.FromFile(path);
                    }
                    else
                    {
                        Console.WriteLine($"Hình ảnh không tồn tại: {path}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi tải hình ảnh từ đường dẫn {path}: {ex.Message}");
                }

                // Thêm PictureBox vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
        }


        public void setLayOutBook()
        {
            if (!isBook)
            {
                //9,10,11,3,12
                panel9.Visible = true;
                panel10.Visible = true;
                panel11.Visible = true;
                panel3.Visible = true;
                panel12.Visible = true;
                isBook = true;
            }
        }

        public void setLayoutProdcut()
        {
            if (isBook)
            {
                //9,10,11,3,12
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel3.Visible = false;
                panel12.Visible = false;
                isBook = false;
            }
        }
        // Biến để theo dõi trạng thái "Checked" của nút
        private bool isUpdate = false;

        private void btnUpdateOrSave_Click(object sender, EventArgs e)
        {

            OnCheckedChanged();
            // Toggle trạng thái isChecked
            isUpdate = !isUpdate;
        }

        private void OnCheckedChanged()
        {
            if (isUpdate)
            {
                btnUpdateOrSave.FillColor = Color.MediumBlue;
                btnUpdateOrSave.Text = "Chỉnh sửa";        // Text khi được chọn

                inpProductName.Enabled = false;
                inpISBN.Enabled = false;
                inpPublishYear.Enabled = false;
                inpPageCount.Enabled = false;
                inpPrice.Enabled = false;
                comboCategories.Enabled = false;
                inpPublisher.Enabled = false;
                inpStock.Enabled = false;
                inpDescription.Enabled = false;
                addImg.Visible = false;

                Controller.Click_UpdateProduct();
            }
            else
            {
                btnUpdateOrSave.FillColor = Color.Green; // Màu khi bỏ chọn
                btnUpdateOrSave.Text = "Lưu";    // Text khi bỏ chọn

                inpProductName.Enabled = true;
                inpISBN.Enabled = true;
                inpPublishYear.Enabled = true;
                inpPageCount.Enabled = true;
                inpPrice.Enabled = true;
                comboCategories.Enabled = true;
                inpPublisher.Enabled = true;
                inpStock.Enabled = true;
                inpDescription.Enabled = true;
                addImg.Visible = true;

            }

            // Thực hiện các logic khác nếu cần
            System.Diagnostics.Debug.WriteLine($"CheckedChanged: {isUpdate}");

        }





        private void inpPrice_Validating(object sender, CancelEventArgs e)
        {
            // Lấy điều khiển TextBox đang gọi sự kiện này
            Guna2TextBox textBox = sender as Guna2TextBox;
            // Kiểm tra nếu TextBox không trống
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Thử chuyển đổi giá trị trong TextBox thành số thập phân
                if (decimal.TryParse(textBox.Text, out decimal price))
                {
                    // Format lại giá trị số
                    textBox.Text = Format.formatPrice(price);
                }
                else
                {
                    // Nếu không hợp lệ, thông báo lỗi và ngăn không cho rời khỏi TextBox
                    e.Cancel = true;
                    MessageBox.Show("Vui lòng nhập vào một số hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.SelectAll(); // Chọn toàn bộ văn bản để dễ chỉnh sửa
                }
            }
            else
            {
                // Nếu trống, hiển thị thông báo lỗi
                e.Cancel = true;
                MessageBox.Show("Giá không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
