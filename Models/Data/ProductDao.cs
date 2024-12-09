using BookStore.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ModelViews;
using BookStore.Models.Entity;

namespace BookStore.Models.Data
{
    public class ProductDAO
    {
        // Hàm hỗ trợ xử lý giá trị NULL một cách an toàn trong DataReader
        private static T GetValueOrDefault<T>(SqlDataReader reader, string columnName, T defaultValue = default)
        {
            int ordinal = reader.GetOrdinal(columnName);
            return reader.IsDBNull(ordinal) ? defaultValue : reader.GetFieldValue<T>(ordinal);
        }

        // lấy danh sách thông tin cơ bản của sản phẩm
        public static List<ProductViewModel> GetProduct(int sl, int? CategoryID)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            try
            {
                using (var connection = new DatabaseConnection().GetConnection()) // Lấy một kết nối mới cho mỗi phương thức.
                using (SqlCommand command = new SqlCommand("getProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sl", sl);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID); // toán tử null-coalescing cho việc xử lý null rõ ràng hơn

                    connection.Open(); // Mở kết nối ở đây trước khối using

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productViewModels.Add(new ProductViewModel
                            {
                                UrlImg = GetValueOrDefault(reader, "ProductImage", ""),
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                StockLevel = GetValueOrDefault(reader, "StockLevel", 0), // Xử lý StockLevel null
                                CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy sản phẩm: {ex.Message}"); // Ghi log tốt hơn
            }
            return productViewModels;
        }

        //Lấy thông tin chi tiết của sản phẩm
        public static DetailProductView GetProductDetailsBase(int productId)
        {
            DetailProductView productDetail = null;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("getProductDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", productId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productDetail = new DetailProductView
                                {
                                    ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                    Name = reader.GetString(reader.GetOrdinal("ProductName")),
                                    Price = reader.GetDecimal(reader.GetOrdinal("ProductPrice")),
                                    StockLevel = reader.GetInt32(reader.GetOrdinal("StockLevel")),
                                    createDate = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                    updateDate = reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                                    CategoryName = GetValueOrDefault(reader, "CategoryName", (string)null),
                                    description = GetValueOrDefault(reader, "ProductDescription", (string)null)
                                };
                            }
                        }
                    }

                    // Lấy danh sách ảnh nếu productDetail đã được khởi tạo
                    if (productDetail != null)
                    {
                        productDetail.ListUrl = GetProductImageUrls(productId, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy chi tiết sản phẩm: {ex.Message}");
            }

            return productDetail;
        }

        //Lấy thông tin chi tiết của của sách
        public static BookViewModel GetBookDetails(int productId)
        {
            BookViewModel bookDetail = null;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("getBookDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", productId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bookDetail = new BookViewModel
                                {
                                    ISBN = GetValueOrDefault(reader, "ISBN", (string)null),
                                    Publisher = GetValueOrDefault(reader, "Publisher", (string)null),
                                    PublishingYear = GetValueOrDefault(reader, "PublishYear", (int?)null),
                                    PageCount = GetValueOrDefault(reader, "PageCount", (int?)null),
                                };
                            }
                        }
                    }

                    // Lấy danh sách tác giả
                    if (bookDetail != null)
                    {
                        bookDetail.Authors = GetAuthorsByBookId(productId, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy chi tiết sách: {ex.Message}");
            }

            return bookDetail;
        }

        //lấy danh sách hình ảnh 
        private static Queue<string> GetProductImageUrls(int productId, SqlConnection connection)
        {
            // Khởi tạo danh sách hình ảnh
            List<ProductImage> imagesList = new List<ProductImage>();

            try
            {
                using (SqlCommand command = new SqlCommand("getListImgProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Đọc URL và IndexImg từ kết quả truy vấn
                            imagesList.Add(new ProductImage
                            {
                                Url = GetValueOrDefault(reader, "url", (string)null),
                                Index = reader.GetInt32(reader.GetOrdinal("IndexImg"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách ảnh: {ex.Message}");
            }

            // Sắp xếp danh sách theo IndexImg (tăng dần)
            imagesList.Sort((x, y) => x.Index.CompareTo(y.Index));

            // Khởi tạo Queue và thêm các URL vào Queue theo thứ tự IndexImg
            Queue<string> imagesQueue = new Queue<string>();
            foreach (var image in imagesList)
            {
                imagesQueue.Enqueue(image.Url);
            }

            return imagesQueue;
        }


        //lấy thông tin của tác giả theo id sách
        private static List<BookAuthor> GetAuthorsByBookId(int bookId, SqlConnection connection)
        {
            List<BookAuthor> authors = new List<BookAuthor>();

            try
            {
                using (SqlCommand command = new SqlCommand("getBookAuthors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", bookId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookAuthor author = new BookAuthor();
                            author.NameAuthor = GetValueOrDefault(reader, "Name", (string)null);
                            author.Role = GetValueOrDefault(reader, "Role", (string)null);
                            authors.Add(author);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách tác giả: {ex.Message}");
            }

            return authors;
        }

        public static bool UpdateProductDetails(DetailProductView productDetails, out DateTime? lastUpdated)
        {
            lastUpdated = null; // Khởi tạo lastUpdated là null

            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                try
                {
                    connection.Open();

                    // Cập nhật thông tin sản phẩm
                    using (SqlCommand command = new SqlCommand("UpdateProductInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho thông tin sản phẩm
                        command.Parameters.AddWithValue("@ProductID", productDetails.ProductID);
                        command.Parameters.AddWithValue("@ProductName", productDetails.Name);
                        command.Parameters.AddWithValue("@CategoryName", productDetails.CategoryName);
                        command.Parameters.AddWithValue("@StockLevel", productDetails.StockLevel ?? 0); // Xử lý giá trị nullable
                        command.Parameters.AddWithValue("@Price", productDetails.Price);
                        command.Parameters.AddWithValue("@desc", productDetails.description);

                        // Thực thi stored procedure và lấy kết quả LastUpdated
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            lastUpdated = Convert.ToDateTime(result); // Gán giá trị cho lastUpdated nếu có kết quả
                        }
                    }

                    // Cập nhật hình ảnh sản phẩm
                    using (SqlCommand command = new SqlCommand("UpdateProductImages", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho hình ảnh sản phẩm
                        command.Parameters.AddWithValue("@ProductID", productDetails.ProductID);

                        // Chuyển đổi danh sách hình ảnh thành chuỗi URL phân cách bởi dấu phẩy
                        string imageUrls = ConvertImagesToUrlString(productDetails.ListUrl);

                        command.Parameters.AddWithValue("@ImageURLs", imageUrls);

                        // Thực thi việc cập nhật hình ảnh
                        command.ExecuteNonQuery();
                    }

                    return true; // Nếu tất cả thực hiện thành công, trả về true
                }
                catch (Exception ex)
                {
                    // Log hoặc xử lý lỗi
                    Console.WriteLine($"Error: {ex.Message}");
                    return false; // Trả về false nếu có lỗi
                }
            }
        }



        private static string ConvertImagesToUrlString(Queue<string> productImages)
        {
            return string.Join(",", productImages);
        }

        public static bool UpdateBookInfo(int bookID, BookViewModel bookViewModel)
        {
            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                try
                {
                    connection.Open();

                    // Gọi thủ tục UpdateBookInfo
                    using (var command = new SqlCommand("UpdateBookInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", bookID);
                        command.Parameters.AddWithValue("@ISBN", bookViewModel.ISBN ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Publisher", bookViewModel.Publisher ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PublishYear", bookViewModel.PublishingYear ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PageCount", bookViewModel.PageCount ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }

                    // Xóa các tác giả hiện tại liên quan đến BookID
                    DeleteAuthorsByBookID(bookID, connection);

                    // Thêm các tác giả mới
                    foreach (var author in bookViewModel.Authors)
                    {
                        UpdateBookAuthor(bookID, author, connection);
                    }

                    return true; // Trả về true nếu thực hiện thành công
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi tùy theo yêu cầu
                    Console.WriteLine($"Error updating book info: {ex.Message}");
                    return false; // Trả về false nếu có lỗi
                }
            }
        }


        private static void DeleteAuthorsByBookID(int bookID, SqlConnection connection)
        {
            using (var command = new SqlCommand("DeleteAuthorsByBookID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookID", bookID);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateBookAuthor(int bookID, BookAuthor author, SqlConnection connection)
        {
            using (var command = new SqlCommand("UpdateBookAuthor", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookID", bookID);
                command.Parameters.AddWithValue("@AuthorName", $"{author.NameAuthor}");
                command.Parameters.AddWithValue("@Role", author.Role);

                command.ExecuteNonQuery();
            }
        }

        //insert dữ liệu sản phẩm
        public static int? AddProduct(DetailProductView product)
        {
            int? newProductId = null;

            try
            {
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("AddProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@CategoryName", product.CategoryName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Name", product.Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Description", product.description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@StockLevel", 0);
                        command.Parameters.AddWithValue("@ReorderLevel", 0); // Nếu không sử dụng, để null
                        command.Parameters.AddWithValue("@ImageUrls", string.Join(",", product.ListUrl) ?? (object)DBNull.Value);

                        connection.Open();

                        // Thực thi và đọc kết quả trả về (ProductID)
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                newProductId = reader["ProductID"] != DBNull.Value
                                    ? Convert.ToInt32(reader["ProductID"])
                                    : null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi (nếu cần)
                Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
                throw;
            }

            return newProductId;
        }


        // Thủ tục xóa sản phẩm
        public static bool DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo đối tượng SqlCommand để gọi thủ tục lưu trữ
                    using (SqlCommand command = new SqlCommand("DeleteProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@ProductID", productId);

                        // Bắt đầu giao dịch
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            // Gán giao dịch cho command
                            command.Transaction = transaction;

                            try
                            {
                                // Thực thi thủ tục
                                command.ExecuteNonQuery();

                                // Commit giao dịch sau khi thực thi thành công
                                transaction.Commit();
                                return true;
                            }
                            catch (Exception)
                            {
                                // Rollback nếu có lỗi
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần thiết
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public static List<ProductViewModel> SearchProducts(string input)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            // Khởi tạo các tham số với giá trị mặc định là null
            int? productCode = null;
            string? productName = null;
            
            decimal? unitPrice = null;
            string? categoryName = null;

            // Kiểm tra và chuyển đổi input thành kiểu dữ liệu phù hợp
            if (int.TryParse(input, out int parsedProductCode))
            {
                productCode = parsedProductCode;
            }

            if (decimal.TryParse(input, out decimal parsedUnitPrice))
            {
                unitPrice = parsedUnitPrice;
            }

            if (input != "")
            {
                productName = input;
                categoryName = input;
            }

            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                try
                {
                    connection.Open();

                    // Tạo một SqlCommand cho thủ tục SearchProducts
                    SqlCommand command = new SqlCommand("SearchProducts", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số vào thủ tục
                    command.Parameters.AddWithValue("@ProductCode", (object)productCode ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProductName", (object)productName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UnitPrice", (object)unitPrice ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CategoryName", (object)categoryName ?? DBNull.Value);

                    // Thực thi thủ tục và lấy dữ liệu
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductViewModel product = new ProductViewModel
                        {
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            UrlImg = reader.GetString(reader.GetOrdinal("ProductImage")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            StockLevel = reader.GetInt32(reader.GetOrdinal("StockLevel")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                        };

                        products.Add(product);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return products;
        }


    }
}
