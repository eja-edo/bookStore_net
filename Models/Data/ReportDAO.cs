using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ModelViews;
using BookStore.Utilities;

namespace BookStore.Models.Data
{
    internal class ReportDAO
    {

        public static List<MonthlyRevenueReport> GetMonthlyRevenueReport(int year)
        {
            var result = new List<MonthlyRevenueReport>();

            // Khởi tạo danh sách mặc định 12 tháng với giá trị 0
            for (int i = 1; i <= 12; i++)
            {
                result.Add(new MonthlyRevenueReport
                {
                    Month = i,
                    OrderCount = 0,
                    TotalRevenue = 0
                });
            }

            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetMonthlyRevenueReport", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Year", year);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Lấy dữ liệu từ kết quả của Stored Procedure
                            int month = reader.GetInt32(reader.GetOrdinal("Month"));
                            int orderCount = reader.GetInt32(reader.GetOrdinal("OrderCount"));
                            decimal totalRevenue = reader.GetDecimal(reader.GetOrdinal("TotalRevenue"));

                            // Cập nhật giá trị cho tháng tương ứng trong danh sách
                            var report = result.Find(r => r.Month == month);
                            if (report != null)
                            {
                                report.OrderCount = orderCount;
                                report.TotalRevenue = totalRevenue;
                            }
                        }
                    }
                }
            }

            return result;
        }


        // Phương thức lấy dữ liệu từ thủ tục GetTodayRevenue
        public static (int OrderCount, decimal TotalRevenue) GetTodayRevenue()
        {
            int orderCount = 0;
            decimal totalRevenue = 0;

            try
            {
                // Thay đổi chuỗi kết nối theo cấu hình của bạn
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetTodayRevenue", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thực thi thủ tục
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đọc dữ liệu trả về từ thủ tục
                                orderCount = reader.IsDBNull(reader.GetOrdinal("OrderCount"))
                                    ? 0
                                    : reader.GetInt32(reader.GetOrdinal("OrderCount"));

                                totalRevenue = reader.IsDBNull(reader.GetOrdinal("TotalRevenue"))
                                    ? 0
                                    : reader.GetDecimal(reader.GetOrdinal("TotalRevenue"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần thiết
                Console.WriteLine($"Error: {ex.Message}");
            }

            return (orderCount, totalRevenue);
        }


        public static List<BestSellingProduct> GetBestSellingProducts(string period)
        {
            List<BestSellingProduct> bestSellingProducts = new List<BestSellingProduct>();

            try
            {
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("GetBestSellingProducts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@TimeRange", period); // Truyền tham số period

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bestSellingProducts.Add(new BestSellingProduct
                                {
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                    TotalQuantitySold = reader.GetInt32(reader.GetOrdinal("TotalQuantitySold"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }

            return bestSellingProducts;
        }

        // Phương thức chuyển đổi từ tên period thành giá trị tương ứng với SQL
        private static string GetPeriodValue(string period)
        {
            switch (period)
            {
                case "Tuần này":
                    return "WEEK";
                case "Tháng này":
                    return "MONTH";
                case "Năm này":
                    return "YEAR";
                default:
                    return "WEEK"; // Mặc định là tuần này
            }
        }

    }
}
