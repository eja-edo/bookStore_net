using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Views.Forms;
using BookStore.Views.UserControls;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    public class ListEmpController
    {
        private eplManagement listProduct;
        public ListEmpController(eplManagement listProduct)
        {
            this.listProduct = listProduct;
        }
        public void LoadData()
        {
            // Lấy dữ liệu sản phẩm từ ProductDAO
            //ProductDAO productDAO = new ProductDAO();
            listProduct.currentEmps = EmployeeDAO.GetEmployees(); // Lấy 10 sản phẩm (hoặc tham số phù hợp)

            // Gọi phương thức SetProductData để điền dữ liệu vào DataGridView
            listProduct.SetEmpsData(listProduct.currentEmps);
        }
    }
}

// Define an interface for the view to implement
