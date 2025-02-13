using BookStore.Controllers;
using BookStore.Models.ModelViews;
using BookStore.Views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Views.Forms
{
    public partial class ctmManagement : UserControl
    {
        ListCusController controller;

        public static int stt = 0;
        public ctmManagement()
        {
            InitializeComponent();
            controller = new ListCusController(this);
            currentCust = new List<ItemCust>();
        }

        public List<ItemCust> currentCust { get; set; }


        public void SetCtmsData(List<ItemCust> cust)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView
            guna2DataGridView1.Rows.Clear();

            // Lặp qua danh sách sản phẩm và thêm vào DataGridView
            foreach (var c in cust)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();  // Thêm một hàng mới
                stt += 1;
                guna2DataGridView1.Rows[rowIndex].Cells["Column1"].Value = stt;
                guna2DataGridView1.Rows[rowIndex].Cells["CTMID"].Value = c.Id;
                guna2DataGridView1.Rows[rowIndex].Cells["EplName"].Value = c.Name;
                guna2DataGridView1.Rows[rowIndex].Cells["PhoneNum"].Value = c.Phone;
                guna2DataGridView1.Rows[rowIndex].Cells["City"].Value = c.City;
                guna2DataGridView1.Rows[rowIndex].Cells["Date"].Value = c.Create_date;
                guna2DataGridView1.Rows[rowIndex].Cells["Address"].Value = c.Address;
                guna2DataGridView1.Rows[rowIndex].Cells["Score"].Value = c.Score;

                guna2DataGridView1.Rows[rowIndex].Cells["info"].Value = Properties.Resources.edit;
                guna2DataGridView1.Rows[rowIndex].Cells["delete"].Value = Properties.Resources.bin;
            }
        }

        void guna2Button1_Click(object sender, EventArgs e)
        {
            Form popupForm = new Form();
            AddCtm addCtmControl = new AddCtm();
            popupForm.Controls.Add(addCtmControl);
            addCtmControl.Dock = DockStyle.Fill;
            popupForm.FormBorderStyle = FormBorderStyle.None; // Remove window border
            popupForm.StartPosition = FormStartPosition.CenterParent;

            // Set the size proportional to the main window
            popupForm.Size = new Size((int)(this.Parent.Width * 0.9), (int)(this.Parent.Height * 0.8));

            // Show the popup form as a dialog within the main window
            popupForm.ShowDialog(this);
        }



        public void SearchCtms(string keyword)
        {
            // Lọc danh sách dựa trên từ khóa tìm kiếm
            var filteredCtms = currentCust.Where(ctm =>
               ctm.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                //ctm.Role.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                ctm.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                ctm.Address.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            // Cập nhật lại DataGridView với dữ liệu đã lọc
            SetCtmsData(filteredCtms);
        }
        private void ctmManagement_Load(object sender, EventArgs e)
        {
            controller.LoadData();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            controller.LoadData();
        }
    }
}
