using BookStore.Models.ModelViews;
using BookStore.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Data
{
    public class DetailEmpDAO
    {
        public InfoEmployee GetEmployeeById(int userId)
        {
            InfoEmployee employee = null;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    using (var command = new SqlCommand("GetEmployeeById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new InfoEmployee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    first_Name = reader.GetString(reader.GetOrdinal("FirstName")),
                                    last_Name = reader.GetString(reader.GetOrdinal("LastName")),
                                    urlImg = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl")),
                                    email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                                    phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null : reader.GetString(reader.GetOrdinal("phone")),
                                    Address = new Address
                                    {
                                        line = reader.IsDBNull(reader.GetOrdinal("AddressLine")) ? null : reader.GetString(reader.GetOrdinal("AddressLine")),
                                        city = reader.IsDBNull(reader.GetOrdinal("city")) ? null : reader.GetString(reader.GetOrdinal("city")),
                                        province = reader.IsDBNull(reader.GetOrdinal("province")) ? null : reader.GetString(reader.GetOrdinal("province"))
                                    },
                                    role = reader.GetString(reader.GetOrdinal("Role"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving employee data: {ex.Message}");
            }

            return employee;
        }

        public static bool InsertUser(InfoEmployee employee)
        {
            try
            {
                // Mã hóa mật khẩu
                string salt;
                string hashedPassword = SecurePasswordHasher.HashPassword(employee.password, out salt);

                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm các tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@Username", employee.username);
                        command.Parameters.AddWithValue("@UrlImg", employee.urlImg ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", employee.first_Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", employee.last_Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Email", employee.email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Sex", employee.sex);
                        command.Parameters.AddWithValue("@Role", employee.role);
                        command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                        command.Parameters.AddWithValue("@Phone", employee.phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Salary", employee.salary);

                        // Thêm các thông tin địa chỉ nếu có
                        command.Parameters.AddWithValue("@AddressLine", employee.Address?.line ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@City", employee.Address?.city ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Province", employee.Address?.province ?? (object)DBNull.Value);

                        // Thực thi câu lệnh SQL
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Nếu có ít nhất một dòng bị ảnh hưởng, tức là đã thêm thành công
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ghi log nếu cần
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }
    }
}
