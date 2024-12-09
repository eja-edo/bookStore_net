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

        public static InfoEmployee GetUserById(int userId)
        {
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetUserById", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số UserId
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Tạo đối tượng InfoEmployee từ dữ liệu đọc được
                                return new InfoEmployee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    username = reader.GetString(reader.GetOrdinal("Username")),
                                    urlImg = reader.IsDBNull(reader.GetOrdinal("UrlImg")) ? null : reader.GetString(reader.GetOrdinal("UrlImg")),
                                    first_Name = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName")),
                                    last_Name = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName")),
                                    email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    age = reader.GetDateTime("old"),
                                    sex = reader.GetString(reader.GetOrdinal("Sex")),
                                    role = reader.GetString(reader.GetOrdinal("Role")),
                                    phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                                    salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                                    Address = new Address
                                    {
                                        line = reader.IsDBNull(reader.GetOrdinal("AddressLine")) ? null : reader.GetString(reader.GetOrdinal("AddressLine")),
                                        city = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                                        province = reader.IsDBNull(reader.GetOrdinal("Province")) ? null : reader.GetString(reader.GetOrdinal("Province"))
                                    }
                                };
                            }
                            else
                            {
                                return null; // Không tìm thấy user
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null; // Trả về null nếu có lỗi
            }
        }

        public static bool InsertUser(InfoEmployee employee, out int newUserId)
        {
            newUserId = 0; // Khởi tạo giá trị mặc định cho ID mới
            SqlTransaction transaction = null;

            try
            {
                // Mã hóa mật khẩu
                string salt;
                string hashedPassword = SecurePasswordHasher.HashPassword(employee.password, out salt);

                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    // Bắt đầu một giao dịch
                    transaction = connection.BeginTransaction();

                    using (SqlCommand command = new SqlCommand("InsertUser", connection, transaction))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm các tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@Username", employee.username);
                        command.Parameters.AddWithValue("@UrlImg", (object)employee.urlImg ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", (object)employee.first_Name ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", (object)employee.last_Name ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", (object)employee.email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Sex", employee.sex);
                        command.Parameters.AddWithValue("@Role", employee.role);
                        command.Parameters.AddWithValue("@old", employee.age.Date); // Đảm bảo truyền kiểu DateTime
                        command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                        command.Parameters.AddWithValue("@salt", salt);
                        command.Parameters.AddWithValue("@Phone", (object)employee.phone ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Salary", employee.salary);
                        command.Parameters.AddWithValue("@AddressLine", (object)employee.Address?.line ?? DBNull.Value);
                        command.Parameters.AddWithValue("@City", (object)employee.Address?.city ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Province", (object)employee.Address?.province ?? DBNull.Value);

                        // Thêm tham số OUTPUT để nhận ID mới
                        SqlParameter outputParam = new SqlParameter("@NewUserId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        // Thực thi câu lệnh SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Lấy giá trị ID mới từ tham số OUTPUT
                            newUserId = (int)outputParam.Value;

                            // Commit giao dịch nếu thành công
                            transaction.Commit();
                            return true;
                        }
                        else
                        {
                            // Nếu không có dòng nào bị ảnh hưởng, rollback giao dịch
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, rollback giao dịch và ghi log
                transaction?.Rollback();
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


        public static bool UpdateUser(InfoEmployee employee, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm các tham số bắt buộc với kiểu dữ liệu đúng
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = employee.Id });
                        command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar, 50) { Value = employee.username });
                        command.Parameters.Add(new SqlParameter("@UrlImg", SqlDbType.VarChar, 255) { Value = employee.urlImg ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 30) { Value = employee.first_Name ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 30) { Value = employee.last_Name ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = employee.email ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@old", SqlDbType.DateTime) { Value = employee.age });
                        command.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 30) { Value = employee.sex });
                        command.Parameters.Add(new SqlParameter("@Role", SqlDbType.NVarChar, 100) { Value = employee.role });
                        command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 15) { Value = employee.phone ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@Salary", SqlDbType.Decimal) { Value = employee.salary });

                        // Thêm thông tin địa chỉ với kiểu dữ liệu chính xác
                        command.Parameters.Add(new SqlParameter("@AddressLine", SqlDbType.NVarChar, 200) { Value = employee.Address?.line ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 50) { Value = employee.Address?.city ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@Province", SqlDbType.NVarChar, 50) { Value = employee.Address?.province ?? (object)DBNull.Value });

                        // Kiểm tra nếu mật khẩu không null thì mã hóa và thêm vào tham số
                        if (!string.IsNullOrEmpty(employee.password))
                        {
                            string salt;
                            string hashedPassword = SecurePasswordHasher.HashPassword(employee.password, out salt);
                            command.Parameters.Add(new SqlParameter("@HashedPassword", SqlDbType.VarChar, 255) { Value = hashedPassword });
                            command.Parameters.Add(new SqlParameter("@salt", SqlDbType.VarChar, 255) { Value = salt });
                        }
                        else
                        {
                            command.Parameters.Add(new SqlParameter("@HashedPassword", SqlDbType.VarChar, 255) { Value = DBNull.Value });
                            command.Parameters.Add(new SqlParameter("@salt", SqlDbType.VarChar, 255) { Value = DBNull.Value });
                        }

                        // Thực thi câu lệnh SQL
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true; // Cập nhật thành công
                        }
                        else
                        {
                            errorMessage = "No rows were affected.";
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                errorMessage = $"Database error: {sqlEx.Message} (Error Code: {sqlEx.Number})";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"General error: {ex.Message}";
                return false;
            }
        }

    }
}
