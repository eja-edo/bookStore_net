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
    }
}
