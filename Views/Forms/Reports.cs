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
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
        }

        public void Reports_loadData()
        {
            salesReport1.SalesReport_loadData();
            productReport1.ProductReport_loadData();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu index chọn là 0
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                // Nếu là index 0, chọn index 0 cho control1
                tabControl1.SelectedIndex = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                // Nếu là index 0, chọn index 0 cho control1
                tabControl1.SelectedIndex = 1;
            }
        }
    }
}
