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

        public static DateTime UpdateProductDetails(DetailProductView productDetails)
        {
            DateTime lastUpdated = DateTime.MinValue;

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
                        command.Parameters.AddWithValue("@StockLevel", productDetails.StockLevel ?? 0);  // Xử lý giá trị nullable
                        command.Parameters.AddWithValue("@Price", productDetails.Price);
                        command.Parameters.AddWithValue("@desc", productDetails.description);

                        // Thực thi stored procedure và lấy kết quả LastUpdated
                        object result = command.ExecuteScalar();

                        // Kiểm tra và gán giá trị LastUpdated
                        if (result != DBNull.Value)
                        {
                            lastUpdated = Convert.ToDateTime(result);
                        }
                    }

                    // Cập nhật hình ảnh sản phẩm
                    using (SqlCommand command = new SqlCommand("UpdateProductImages", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters for product images
                        command.Parameters.AddWithValue("@ProductID", productDetails.ProductID);

                        // Chuyển đổi danh sách hình ảnh thành chuỗi URL phân cách bởi dấu phẩy
                        string imageUrls = ConvertImagesToUrlString(productDetails.ListUrl);
                        command.Parameters.AddWithValue("@ImageURLs", imageUrls);

                        // Execute the image update
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    throw new Exception("An error occurred while updating product details.", ex);
                }
            }

            return lastUpdated;
        }


        private static string ConvertImagesToUrlString(Queue<string> productImages)
        {
            // Lọc những URL không hợp lệ và lấy các URL hợp lệ
            List<string> urls = productImages
                .Where(url => !string.IsNullOrEmpty(url)) // Lọc các URL hợp lệ
                .ToList();

            // Ghép các URL thành chuỗi phân cách bởi dấu phẩy
            return string.Join(",", urls);
        }

        public static void UpdateBookInfo(int bookId, string isbn, string publisher, int publishYear, int pageCount)
        {
            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateBookInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số vào thủ tục
                        command.Parameters.Add(new SqlParameter("@BookID", SqlDbType.Int)).Value = bookId;
                        command.Parameters.Add(new SqlParameter("@ISBN", SqlDbType.NVarChar, 20)).Value = isbn;
                        command.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.NVarChar, 255)).Value = publisher;
                        command.Parameters.Add(new SqlParameter("@PublishYear", SqlDbType.Int)).Value = publishYear;
                        command.Parameters.Add(new SqlParameter("@PageCount", SqlDbType.Int)).Value = pageCount;

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi
                    Console.WriteLine("Lỗi khi cập nhật thông tin sách: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
