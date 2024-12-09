using BookStore.Models.Data;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Ví dụ: Thay đổi màu nền cho panel1
            e.Graphics.FillRectangle(Brushes.Gray, e.ClipRectangle);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            UserDAO.GetUserByCredentials(inpIdentifier.Text, inpPass.Text);
        }
    }
}
