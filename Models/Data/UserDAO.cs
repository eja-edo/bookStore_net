using BookStore.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Entity;

namespace BookStore.Models.Data
{
    internal class UserDAO
    {
        public static User GetUserByCredentials(string identifier, string inputPassword)
        {
            User user = null;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetPasswordByUserInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho Stored Procedure
                        command.Parameters.AddWithValue("@Identifier", identifier);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy thông tin mật khẩu và salt từ cơ sở dữ liệu
                                string storedHashedPassword = reader["password"].ToString();
                                string salt = reader["salt"].ToString();

                                // Xác minh mật khẩu
                                bool isPasswordValid = SecurePasswordHasher.VerifyPassword(inputPassword, salt, storedHashedPassword);
                                if (isPasswordValid)
                                {
                                    user = GetUserInfo(identifier, storedHashedPassword, salt);
                                    if (user != null)
                                    {
                                        // Lưu thông tin người dùng vào CurrentUser
                                        CurrentUser.Current = user;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Mật khẩu không chính xác.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy người dùng với thông tin đã cung cấp.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi truy vấn cơ sở dữ liệu: {ex.Message}");
                MessageBox.Show($"Lỗi truy vấn cơ sở dữ liệu: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khác: {ex.Message}");
                MessageBox.Show($"Lỗi khác: {ex.Message}");
            }

            return user;
        }

        // Phương thức lấy thông tin người dùng dựa trên identifier (username, phone, email)
        public static User GetUserInfo(string identifier, string password, string salt)
        {
            User user = null;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetUserByIdentifier", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào câu lệnh thủ tục
                        command.Parameters.AddWithValue("@Identifier", identifier);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Salt", salt);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu có kết quả trả về
                            {
                                user = new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    Username = reader["Username"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    old = Convert.ToDateTime(reader["Old"]),
                                    Sex = reader["Sex"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Salary = Convert.ToDecimal(reader["Salary"]),
                                    AddressLine = reader["AddressLine"].ToString(),
                                    City = reader["City"].ToString(),
                                    Province = reader["Province"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

            return user;
        }
    }
}
