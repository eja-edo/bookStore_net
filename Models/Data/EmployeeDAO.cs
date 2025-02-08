using BookStore.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Utilities;
using System.Data.Common;

namespace BookStore.Models.Data
{
    public class EmployeeDAO
    {
        public static List<ItemEmp> GetEmployees()
        {
            List<ItemEmp> employees = new List<ItemEmp>();
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("GetEmployeeInformation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new ItemEmp
                                {
                                    // Kiểm tra và lấy giá trị nếu không phải NULL
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                                    Role = reader.IsDBNull(reader.GetOrdinal("Role")) ? string.Empty : reader.GetString(reader.GetOrdinal("Role")),
                                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? string.Empty : reader.GetString(reader.GetOrdinal("Phone")),
                                    Salary = reader.IsDBNull(reader.GetOrdinal("Salary")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Salary")),
                                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? string.Empty : reader.GetString(reader.GetOrdinal("Address"))
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            return employees;
        }

        public static bool DeleteUserById(int userId)
        {
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteUserById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số UserId vào thủ tục
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Thực thi thủ tục
                        int rowsAffected = command.ExecuteNonQuery();

                        // Nếu có dòng bị ảnh hưởng, tức là người dùng đã được xóa thành công
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log hoặc xử lý lỗi tùy theo yêu cầu
                Console.WriteLine($"Lỗi khi xóa người dùng: {ex.Message}");
                return false;
            }
        }
    }
}
