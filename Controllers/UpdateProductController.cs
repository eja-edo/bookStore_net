using BookStore.Models.Data;
using BookStore.Models.ModelViews;
using BookStore.Utilities;
using BookStore.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Controllers
{
    internal class UpdateProductController
    {
        private readonly UpdateProduct _view;

        public UpdateProductController(UpdateProduct view)
        {
            _view = view;
        }
        public void LoadProductDetails()
        {
            if (_view.ProductId == null) return;
            int productId = _view.ProductId;
            // Get basic product details
            DetailProductView productDetails = ProductDAO.GetProductDetailsBase(productId);
            if (productDetails != null)
            {
            // Set the basic product details in the view
                    _view.SetProductId(productDetails.ProductID.ToString());
                    _view.SetProductName(productDetails.Name ?? "không có tên sản phẩm");
                    _view.SetPrice(Format.formatPrice(productDetails.Price));
                    _view.SetStock(productDetails.StockLevel.HasValue ? productDetails.StockLevel.Value.ToString() : "0");
                    _view.SetCategory(productDetails.CategoryName ?? "Không có thể loại");
                    _view.SetDescription(productDetails.description ?? "");
                    _view.SetCreateDate(productDetails.createDate);
                    _view.SetYearUpdate(productDetails.updateDate);

                    // Set product images
                    _view.AddImagesToFlowLayoutPanel(productDetails.ListUrl);
                // Check if the product category is "Sách"
                if (productDetails.CategoryName == "Sách")
                {
                    _view.setLayOutBook();
                    // Load book-specific details
                    var bookDetails = ProductDAO.GetBookDetails(productId);
                    if (bookDetails != null)
                    {
                        _view.SetISBN(bookDetails.ISBN ?? "N/A");
                        _view.SetPublisher(bookDetails.Publisher ?? "N/A");
                        _view.SetPublishYear(bookDetails.PublishingYear?.ToString() ?? "N/A");
                        _view.SetPageCount(bookDetails.PageCount?.ToString() ?? "N/A");
                    }

                    // Load authors for the book
                    var authors = ProductDAO.GetBookAuthors(productId);
                    _view.SetAuthors(authors);
                }
                else
                {
                    _view.setLayoutProdcut();
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        public void Click_UpdateProduct()
        {
            if (_view.ProductId == null) return;
            try
            {
                // Get data from UI elements
                int productId = _view.ProductId; // Replace txtProductId with your TextBox ID
                string name = _view.GetProductName();          // Replace txtProductName with your TextBox ID
                string description =_view.GetDescription(); // Replace txtProductDescription with your TextBox ID
                decimal price = _view.getPrice();
                // Call the DAO method to update the product
                ProductDAO.UpdateProduct(productId, name, price, description);
                // Update UI to reflect changes or show a success message
                MessageBox.Show("Product updated successfully!");
                // Optionally, refresh your product list in the UI.
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Invalid input: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}"); //More general error handling
            }
        }
    }
}