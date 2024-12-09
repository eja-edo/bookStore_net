using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Utilities;

namespace BookStore.Models.Data
{
    public class CategoriesDAO
    {
        public static List<string> GetSuggestedCategories(string searchTerm)
        {
            List<string> categoryNames = new List<string>();

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo command để gọi thủ tục
                    using (SqlCommand cmd = new SqlCommand("GetSuggestedProductCategories", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                        // Thực thi thủ tục và đọc kết quả
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categoryNames.Add(reader["CategoryName"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (hiển thị hoặc ghi lại lỗi)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return categoryNames;
        }
    }
}
