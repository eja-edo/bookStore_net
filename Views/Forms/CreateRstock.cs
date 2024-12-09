using BookStore.Models.ModelViews;
using BookStore.Views.UserControls;
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
    public partial class CreateRstock : UserControl
    {
        public CreateRstock()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var selectedRow = guna2DataGridView1.Rows[e.RowIndex];

            //    var selectedProduct = new ProductViewModel
            //    {
            //        ProductID = Convert.ToInt32(selectedRow.Cells["productID"].Value),
            //        Name = selectedRow.Cells["ProductName"].Value?.ToString(),
            //        Price = Convert.ToDecimal(selectedRow.Cells["price"].Value),
            //        StockLevel = Convert.ToInt32(selectedRow.Cells["stock"].Value),
            //        CategoryName = selectedRow.Cells["categories"].Value?.ToString()
            //    };

            //    var currentTab = tabControl1.SelectedTab;
            //    var createOrder = currentTab.Controls.OfType<CreateOrder>().FirstOrDefault();

            //    createOrder?.setItemOrder(selectedProduct);

            //    guna2DataGridView1.Rows.Clear();
            //    guna2DataGridView1.Height = 0;
            //}
        }
    }
}
