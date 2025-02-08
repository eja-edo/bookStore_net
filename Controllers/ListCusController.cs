using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Views.Forms;
using BookStore.Views.UserControls;
using System.Collections.Generic;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class ListCusController
    {
        private ctmManagement listCustomer;
        public ListCusController(ctmManagement listCustomer)
        {
            this.listCustomer = listCustomer;
        }
        public void LoadData()
        {
            // Lấy dữ liệu sản phẩm từ ProductDAO
            //ProductDAO productDAO = new ProductDAO();
            listCustomer.currentCust = CustDAO.GetCustomer(); // Lấy 10 sản phẩm (hoặc tham số phù hợp)
            // Gọi phương thức SetProductData để điền dữ liệu vào DataGridView
            //Debug.WriteLine("LoadData: currentCust = " + listCustomer.currentCust[0].Name);
            listCustomer.SetCtmsData(listCustomer.currentCust);
        }
    }
}
