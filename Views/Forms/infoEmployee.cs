using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.Forms
{
    public partial class infoEmployee : UserControl
    {
        private infoEmployee? model = null;
        public infoEmployee()
        {
            InitializeComponent();
        }

        // Các phương thức set giá trị cho từng điều khiển
        public void SetFirstName(string firstName)
        {
            inpFirstName.Text = firstName;
        }

        public void SetLastName(string lastName)
        {
            inpLastName.Text = lastName;
        }

        public void SetUserName(string userName)
        {
            inpUserName.Text = userName;
        }

        public void SetPhone(string phone)
        {
            inpPhone.Text = phone;
        }

        public void SetEmail(string email)
        {
            inpEmail.Text = email;
        }

        public void SetSex(string sex)
        {
            ComboBoxSex.SelectedItem = sex;
        }

        public void SetDateOfBirth(DateTime birthDate)
        {
            DateOld.Value = birthDate;
        }

        public void SetRole(string role)
        {
            comboRole.SelectedItem = role;
        }

        public void SetProfilePicture(string imagePath)
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
    }
}
