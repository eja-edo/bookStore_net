using BookStore.Models.Data;
using BookStore.Models.Entity;
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
        private DetailProductView _product; // Thông tin sản phẩm
        private BookViewModel _book;        // Thông tin sách (nếu là sách)


        public void setEnListImg(String urlImg)
        {
            _product.ListUrl.Enqueue(urlImg);
        }
        public UpdateProductController(UpdateProduct view)
        {
            _view = view;
            _product = new DetailProductView();
            _book = new BookViewModel();
        }

        public void LoadProductDetails(int productId)
        {
            // Lấy thông tin cơ bản về sản phẩm từ DAO
            DetailProductView productDetails = ProductDAO.GetProductDetailsBase(productId);
            if (productDetails != null)
            {
                // Lưu dữ liệu vào _product
                _product = productDetails;

                // Nếu sản phẩm thuộc loại "Sách", lấy thêm thông tin sách
                if (_product.CategoryName == "Sách")
                {
                    _book = ProductDAO.GetBookDetails(productId) ?? new BookViewModel();
                }
                else
                {
                    _book = null; // Không có thông tin sách
                }

                // Cập nhật view dựa trên _product và _book
                UpdateViewFromData();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        private void UpdateViewFromData()
        {
            // Cập nhật thông tin sản phẩm vào view
            _view.SetProductId(_product.ProductID.ToString());
            _view.SetProductName(_product.Name ?? "Không có tên sản phẩm");
            _view.SetPrice(Format.formatPrice(_product.Price));
            _view.SetStock(_product.StockLevel.HasValue ? _product.StockLevel.Value.ToString() : "0");
            _view.SetCategory(_product.CategoryName ?? "Không có thể loại");
            _view.SetDescription(_product.description ?? "");
            _view.SetCreateDate(_product.createDate);
            _view.SetYearUpdate(_product.updateDate);

            // Cập nhật hình ảnh sản phẩm
            _view.AddImagesToFlowLayoutPanel(_product.ListUrl);

            // Cập nhật thông tin sách nếu là sách
            if (_product.CategoryName == "Sách")
            {
                _view.setLayOutBook();
                _view.SetISBN(_book.ISBN ?? "N/A");
                _view.SetPublisher(_book.Publisher ?? "N/A");
                _view.SetPublishYear(_book.PublishingYear?.ToString() ?? "N/A");
                _view.SetPageCount(_book.PageCount?.ToString() ?? "N/A");

                // Cập nhật danh sách tác giả
                _view.SetAuthors(_book.Authors);
            }
            else
            {
                _view.setLayoutProduct();
            }
        }

        //public void Click_UpdateProduct()
        //{
        //    try
        //    {  
        //        // Get data from UI elements
        //        int productId = _view.ProductId; // Replace txtProductId with your TextBox ID
        //        string name = _view.GetProductName();          // Replace txtProductName with your TextBox ID
        //        string description = _view.GetDescription(); // Replace txtProductDescription with your TextBox ID
        //        decimal price = _view.getPrice();
        //        // Call the DAO method to update the product
        //        int i = ProductDAO.UpdateProduct(productId, name, price, description);
        //        // Update UI to reflect changes or show a success message
        //        MessageBox.Show($"Product updated successfully!{i}");
        //        // Optionally, refresh your product list in the UI.
        //    }
        //    catch (FormatException ex)
        //    {
        //        MessageBox.Show($"Invalid input: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred: {ex.Message}"); //More general error handling
        //    }
        //}

        public void click_updateProdcut()
        {
            if(_view.isUpdate)
            {
                if(_view.isNew)
                {

                }
                else
                {
                    _product.Name = _view.GetProductName();
                    _product.Price = _view.getPrice();
                    _product.StockLevel = _view.getStock();
                    _product.CategoryName = _view.GetCategory();
                    _product.Price = _view.getPrice();
                    _product.description = _view.GetDescription();
                    if (_product.CategoryName != "Sách")
                    {
                        _product.updateDate = ProductDAO.UpdateProductDetails(_product);
                        _view.SetYearUpdate(_product.updateDate);
                    }
                    else
                    {

                    }
                }
            }else
            {
                _view.isUpdate = true;
                _view.setIsUpdate();
            }

        }
    }
}