using BookStore.Utilities;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace BookStore
{
    public partial class QuanLy : BaseMaterialForm
    {
        public QuanLy()
        {
            InitializeComponent();
            QuanlyLoad_data();
        }

        public void QuanlyLoad_data()
        {
            if (CurrentUser.Current == null)
            {
                // Handle null user case, e.g., show a default image or an error message
                MessageBox.Show("User is not logged in or user information is not initialized.");
                return;
            }

            SetProfilePicture(CurrentUser.Current.UrlImg);
        }

        public void SetProfilePicture(string? imagePath)
        {
            try
            {
                // Tạo đường dẫn đầy đủ nếu imagePath là đường dẫn tương đối
                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);

                // Kiểm tra nếu đường dẫn tồn tại
                if (System.IO.File.Exists(fullPath))
                {
                    // Gán ảnh vào PictureBox
                    guna2CirclePictureBox1.Image = Image.FromFile(fullPath);
                }
                else
                {
                    // Nếu không tìm thấy ảnh, có thể gán ảnh mặc định hoặc thông báo lỗi
                    MessageBox.Show("Image not found at: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi nếu có vấn đề khi tải ảnh
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }


        private void customTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra tab đang được chọn
            if (menu.SelectedTab == report) // tabPage1 là tên Tab bạn muốn kiểm tra
            {
                reports1.Reports_loadData(); // Hàm tải lại dữ liệu cho tab
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện hành động đăng xuất
                CurrentUser.Current = null;
                MessageBox.Show("Đã đăng xuất!");
                // Thực hiện các thao tác cần thiết như quay về màn hình đăng nhập hoặc xóa thông tin người dùng
            }
            else
            {
            }
        }
    }
}
