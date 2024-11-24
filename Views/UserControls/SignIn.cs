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
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Mã của bạn để xử lý sự kiện TextChanged sẽ ở đây
        }
        private void SignIn_Load(object sender, EventArgs e)
        {
            // Thực hiện các thao tác khi form được tải
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Ví dụ: Thay đổi màu nền cho panel1
            e.Graphics.FillRectangle(Brushes.Gray, e.ClipRectangle);
        }
    }
}
