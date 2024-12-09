using BookStore.Models.Data;
using BookStore.Models.Entity;
using Guna.UI2.WinForms;
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
    public partial class ListRestock : UserControl
    {
        public ListRestock()
        {
            InitializeComponent();
        }


        // Giả sử bạn đã có GunaDataGridView trên form
        private void LoadRestockOrders()
        {
            List<RestockOrder> restockOrders = RestockDAO.GetRestockOrders();

            // Thiết lập các cột cho GunaDataGridView nếu cần
            dataGridRestocks.Columns.Clear();  // Xóa các cột hiện tại (nếu có)

            dataGridRestocks.Columns.Add("RestockOrderID", "Restock Order ID");
            dataGridRestocks.Columns.Add("RestockDate", "Restock Date");
            dataGridRestocks.Columns.Add("SupplierName", "Supplier Name");
            dataGridRestocks.Columns.Add("TotalAmount", "Total Amount");
            dataGridRestocks.Columns.Add("Status", "Status");

            // Thêm các dòng dữ liệu vào GunaDataGridView
            foreach (var order in restockOrders)
            {
                dataGridRestocks.Rows.Add(order.RestockOrderID, order.RestockDate.ToString("yyyy-MM-dd"), order.SupplierName, order.TotalAmount, order.Status);
            }
        }

        private void ListRestock_Load(object sender, EventArgs e)
        {
            LoadRestockOrders();
        }
    }
}
