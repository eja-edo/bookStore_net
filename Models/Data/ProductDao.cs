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
        public static DetailProductView GetProductDetailsBase(int productId)
        {
            DetailProductView productDetail = null;

            try
            { 
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("getProductDetails", connection))
                    {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", productId);
                    connection.Open();
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
                    //Lấy hình ảnh - Giờ đây sử dụng đối tượng kết nối đã lấy trong GetProductDetailsBase.
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


        public static BookViewModel GetBookDetails(int productId)
        {
            BookViewModel bookDetail = null;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
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
                                    ISBN = reader.IsDBNull(reader.GetOrdinal("ISBN")) ? null : reader.GetString(reader.GetOrdinal("ISBN")),
                                    Publisher = reader.IsDBNull(reader.GetOrdinal("Publisher")) ? null : reader.GetString(reader.GetOrdinal("Publisher")),
                                    PublishingYear = reader.IsDBNull(reader.GetOrdinal("PublishYear")) ? null : reader.GetInt32(reader.GetOrdinal("PublishYear")),
                                    PageCount = reader.IsDBNull(reader.GetOrdinal("PageCount")) ? null : reader.GetInt32(reader.GetOrdinal("PageCount"))
                                };
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
            }

            return bookDetail;
        }


        private static List<string> GetProductImageUrls(int productId, SqlConnection connection)
        {
            List<string> imageUrls = new List<string>();

            using (SqlCommand command = new SqlCommand("getListImgProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", productId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        imageUrls.Add(reader.GetString(reader.GetOrdinal("url")));
                    }
                }
            }

            return imageUrls;
        }


        public static List<BookAuthor> GetBookAuthors(int bookId)
        {
        List<BookAuthor> authors = new List<BookAuthor>();

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                    using (SqlCommand command = new SqlCommand("getBookDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Loại là thủ tục
                        command.Parameters.AddWithValue("@id", bookId);    // Truyền tham số

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var author = new BookAuthor
                                {
                                    AuthorID = reader.GetInt32(reader.GetOrdinal("AuthorID")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Role = reader.GetString(reader.GetOrdinal("Role"))
                                };
                                authors.Add(author);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving authors: {ex.Message}");
                // Xử lý ngoại lệ (log lỗi, throw exception, v.v.)
            }
        return authors;
        }


        public static int UpdateProduct(int productId, string name, decimal price, string description)
        {
            int rowsAffected = 0;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                using (SqlCommand command = new SqlCommand("updateProduct", connection))
                {
                    System.Diagnostics.Debug.WriteLine(1);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@productID", SqlDbType.Int).Value = productId;
                    command.Parameters.Add("@name", SqlDbType.NVarChar, 255).Value = name;
                    command.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    command.Parameters.Add("@desc", SqlDbType.NVarChar).Value = description;

                    SqlParameter returnParameter = new SqlParameter("@ReturnValue", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnParameter);

                    connection.Open(); 
                    command.ExecuteNonQuery();
                    rowsAffected = Convert.ToInt32(returnParameter.Value);
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Exception: {sqlEx.Message}");
                throw new Exception("Database error during product update.", sqlEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
            return rowsAffected;
        }


    }


}


