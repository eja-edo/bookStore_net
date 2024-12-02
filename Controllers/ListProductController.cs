using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Views.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class ListProductController
    {
        private ListProduct listProduct;

        // Constructor nhận đối tượng ListProduct từ ngoài
        public ListProductController(ListProduct listProduct)
        {
            this.listProduct = listProduct;
        }

        public void LoadData()
        {
            // Lấy dữ liệu sản phẩm từ ProductDAO
            //ProductDAO productDAO = new ProductDAO();
            List<ProductViewModel> products = ProductDAO.GetProduct(10, null); // Lấy 10 sản phẩm (hoặc tham số phù hợp)

            // Gọi phương thức SetProductData để điền dữ liệu vào DataGridView
            listProduct.SetProductData(products);
        }

    }
}