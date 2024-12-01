using BookStore.Controllers;
using BookStore.Models.Entity;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
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
    public partial class eplManagement : UserControl
    {
        ListEmpController controller;
        public eplManagement()
        {
            InitializeComponent();
            controller = new ListEmpController(this);
        }



        public void SetEmpsData(List<ItemEmp> emps)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            guna2DataGridView1.Rows.Clear();

            // Lặp qua danh sách sản phẩm và thêm vào DataGridView
            foreach (var emp in emps)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();  // Thêm một hàng mới
                guna2DataGridView1.Rows[rowIndex].Cells["EplID"].Value = emp.Id;
                guna2DataGridView1.Rows[rowIndex].Cells["EplName"].Value = emp.Name;
                guna2DataGridView1.Rows[rowIndex].Cells["Role"].Value = emp.Role;
                guna2DataGridView1.Rows[rowIndex].Cells["Phone"].Value = emp.Phone;
                guna2DataGridView1.Rows[rowIndex].Cells["Salary"].Value = Format.formatPrice(emp.Salary);
                guna2DataGridView1.Rows[rowIndex].Cells["Address"].Value = emp.Address;

                guna2DataGridView1.Rows[rowIndex].Cells["info"].Value = Properties.Resources.edit;
                guna2DataGridView1.Rows[rowIndex].Cells["delete"].Value = Properties.Resources.bin;
            }
        }

        private void eplManagement_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(1);
            controller.LoadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormInfoEmp newEmploy = new FormInfoEmp();
            newEmploy.ShowDialog();
        }
    }
}
