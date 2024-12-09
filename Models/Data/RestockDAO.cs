using BookStore.Models.Entity;
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
    public class RestockDAO
    {
        public static List<RestockOrder> GetRestockOrders()
        {
            List<RestockOrder> restockOrders = new List<RestockOrder>();

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("GetRestockOrderDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Mở kết nối với cơ sở dữ liệu
                        connection.Open();

                        // Thực thi thủ tục và lấy dữ liệu từ SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Đọc dữ liệu và thêm vào danh sách
                                restockOrders.Add(new RestockOrder
                                {
                                    RestockOrderID = reader.GetInt32(reader.GetOrdinal("RestockOrderID")),
                                    RestockDate = reader.GetDateTime(reader.GetOrdinal("RestockDate")),
                                    SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                                    TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                                    Status = reader.GetString(reader.GetOrdinal("Status"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (có thể ghi log hoặc hiển thị thông báo lỗi)
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }

            return restockOrders;
        }
    }
}
