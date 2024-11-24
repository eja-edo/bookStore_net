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
        public ListProduct()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListProduct_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Add(10);
            guna2DataGridView1.Rows[0].Cells[2].Value ="Sách dậy nấu ăn";
            guna2DataGridView1.Rows[0].Cells[5].Value = Properties.Resources.edit;
            guna2DataGridView1.Rows[0].Cells[6].Value = Properties.Resources.bin;
        }
    }
}
