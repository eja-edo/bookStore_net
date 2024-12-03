using BookStore.Controllers;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.UserControls
{
    public partial class UpdateProduct : UserControl
    {
        private bool isBook;
        private UpdateProductController Controller;
        public bool isNew { get; set; }
        public bool isUpdate { get; set; }
        public UpdateProduct()
        {
            InitializeComponent();
            Controller = new UpdateProductController(this);
            isBook = false;
            isNew = true;
            isUpdate = true;
        }
        public UpdateProduct(int id) : this()
        {

            isNew = false;
            isUpdate = false;
            Controller.LoadProductDetails(id);
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
        public String GetPublisher()
        {
            return inpPublisher.Text;
        }

        // Set Publish Year
        public void SetPublishYear(string publishYear)
        {
            inpPublishYear.Text = publishYear;
        }

        public int GetPublicYear()
        {
            // Kiểm tra nếu inpPublishYear.Text có thể chuyển đổi sang int
            if (int.TryParse(inpPublishYear.Text, out int publishYear))
            {
                return publishYear;
            }
            else
            {
                // Nếu không thể chuyển đổi, trả về một giá trị mặc định hoặc ném lỗi
                throw new InvalidOperationException("Giá trị năm xuất bản không hợp lệ.");
            }
        }

        // Set Page Count
        public void SetPageCount(string pageCount)
        {
            inpPageCount.Text = pageCount;
        }

        public int GetPageCount()
        {
            // Kiểm tra nếu inpPublishYear.Text có thể chuyển đổi sang int
            if (int.TryParse(inpPageCount.Text, out int count))
            {
                return count;
            }
            else
            {
                // Nếu không thể chuyển đổi, trả về một giá trị mặc định hoặc ném lỗi
                throw new InvalidOperationException("Giá trị số trang không hợp lệ");
            }
        }


        // Set Stock
        public void SetStock(string stock)
        {
            inpStock.Text = stock;
        }

        public int getStock()
        {
            // Kiểm tra nếu inpPublishYear.Text có thể chuyển đổi sang int
            if (int.TryParse(inpStock.Text, out int stock))
            {
                return stock;
            }
            else
            {
                // Nếu không thể chuyển đổi, trả về một giá trị mặc định hoặc ném lỗi
                throw new InvalidOperationException("Giá trị số lượng không hợp lệ");
            }
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
            inpCategoryName.Text = category;
        }

        public string GetCategory()
        {
            return inpCategoryName.Text;
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
                    string displayText = $"{author.NameAuthor} - {author.Role}";
                    listAuthor.Items.Add(displayText);
                }
            }
            else
            {
                // Trường hợp danh sách rỗng hoặc null
                listAuthor.Items.Add("Không có tác giả nào.");
            }
        }
        public void addImgAtTheEnd(string urlImg)
        {
            Controller.setEnListImg(urlImg);
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
                if (System.IO.File.Exists(urlImg))
                {
                    pictureBox.Image = Image.FromFile(urlImg);
                }
                else
                {
                    Console.WriteLine($"Hình ảnh không tồn tại: {urlImg}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải hình ảnh từ đường dẫn {urlImg}: {ex.Message}");
            }

            // Thêm PictureBox vào FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(pictureBox);

        }

        public void AddImagesToFlowLayoutPanel(Queue<string> imageUrls)
        {
            // Xóa các hình ảnh cũ (nếu cần)
            flowLayoutPanel1.Controls.Clear();

            // Lặp qua danh sách đường dẫn hình ảnh trong Queue
            foreach (var url in imageUrls)
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
                    if (System.IO.File.Exists(url))
                    {
                        pictureBox.Image = Image.FromFile(url);
                    }
                    else
                    {
                        Console.WriteLine($"Hình ảnh không tồn tại: {url}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi tải hình ảnh từ đường dẫn {url}: {ex.Message}");
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

        public void setLayoutProduct()
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

        private void btnUpdateOrSave_Click(object sender, EventArgs e)
        {
            Controller.click_updateProdcut();
        }

        public void setIsUpdate()
        {
            btnUpdateOrSave.FillColor = Color.Green; // Màu khi bỏ chọn
            btnUpdateOrSave.Text = "Lưu";    // Text khi bỏ chọn

            inpProductName.Enabled = true;
            inpISBN.Enabled = true;
            inpPublishYear.Enabled = true;
            inpPageCount.Enabled = true;
            inpPrice.Enabled = true;
            inpCategoryName.Enabled = true;
            inpPublisher.Enabled = true;
            inpStock.Enabled = true;
            inpDescription.Enabled = true;
            addImg.Visible = true;
        }

        public void setEndUpdate()
        {
            btnUpdateOrSave.FillColor = Color.MediumBlue;
            btnUpdateOrSave.Text = "Chỉnh sửa";        // Text khi được chọn

            inpProductName.Enabled = false;
            inpISBN.Enabled = false;
            inpPublishYear.Enabled = false;
            inpPageCount.Enabled = false;
            inpPrice.Enabled = false;
            inpCategoryName.Enabled = false;
            inpPublisher.Enabled = false;
            inpStock.Enabled = false;
            inpDescription.Enabled = false;
            addImg.Visible = false;
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

        private void inpCategoryName_Validating(object sender, CancelEventArgs e)
        {
            // Kiểm tra xem sender có phải là TextBox hay không
            if (sender is Guna2TextBox textBox)
            {
                if (textBox.Text == "Sách")  // Kiểm tra nội dung nhập vào
                {
                    setLayOutBook();
                }
                else
                {
                    setLayoutProduct();
                }
            }
            else
            {
                // Nếu sender không phải TextBox, bạn có thể xử lý thêm nếu cần thiết.
                Console.WriteLine("Invalid control type");
            }
        }

        private void addImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Thiết lập thuộc tính cho hộp thoại
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn một hình ảnh";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                // Hiển thị hộp thoại và kiểm tra nếu người dùng chọn file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của file được chọn
                    string selectedFilePath = openFileDialog.FileName;

                    // Định nghĩa thư mục "Static\Image\User" trong thư mục gốc của dự án
                    string projectDirectory = Application.StartupPath; // Đảm bảo đường dẫn là thư mục gốc của dự án
                    string imgDirectory = Path.Combine(projectDirectory, "Static", "Image", "User");

                    // Kiểm tra và tạo thư mục "User" nếu chưa tồn tại
                    if (!Directory.Exists(imgDirectory))
                    {
                        Directory.CreateDirectory(imgDirectory);
                    }

                    // Lấy tên file và tạo đường dẫn lưu ảnh vào thư mục "User"
                    string fileName = Path.GetFileName(selectedFilePath);
                    string destinationPath = Path.Combine(imgDirectory, fileName);

                    // Sao chép file vào thư mục "User"
                    try
                    {
                        File.Copy(selectedFilePath, destinationPath, true); // Nếu file đã tồn tại, ghi đè lên file cũ


                        addImgAtTheEnd($"Static\\Image\\User\\{fileName}");
                        MessageBox.Show($"Hình ảnh đã được tải lên thư mục Static\\Image\\User: Static\\Image\\User\\{fileName}", "Thông Báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi sao chép file: {ex.Message}", "Lỗi");
                    }
                }
            }
        }
    }
}
