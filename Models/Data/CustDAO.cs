using BookStore.Models.ModelViews;
using BookStore.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Data
{
    public class CustDAO
    {
        public static List<ItemCust> GetCustomer()
        {
            List<ItemCust> customers = new List<ItemCust>();
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("GetCustomerInformation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var customer = new ItemCust
                                {
                                    // Kiểm tra và lấy giá trị nếu không phải NULL
                                    Id = reader.IsDBNull(reader.GetOrdinal("CustomerID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                   
                                    Name = reader.IsDBNull(reader.GetOrdinal("FullName")) ? string.Empty : reader.GetString(reader.GetOrdinal("FullName")),
                                    
                                    Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? string.Empty : reader.GetString(reader.GetOrdinal("phone")),
                                    
                                    Address = reader.IsDBNull(reader.GetOrdinal("address_line")) ? string.Empty : reader.GetString(reader.GetOrdinal("address_line")),

                                    City = reader.IsDBNull(reader.GetOrdinal("city")) ? string.Empty : reader.GetString(reader.GetOrdinal("city")),

                                    Provice = reader.IsDBNull(reader.GetOrdinal("province")) ? string.Empty : reader.GetString(reader.GetOrdinal("province")),

                                    Create_date = reader.IsDBNull(reader.GetOrdinal("created_at")) ? string.Empty : reader.GetDateTime(reader.GetOrdinal("created_at")).ToString("yyyy-MM-dd"),

                                    Score = reader.IsDBNull(reader.GetOrdinal("LoyaltyPoints")) ? 0 : reader.GetInt32(reader.GetOrdinal("LoyaltyPoints"))
                                };

                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error(Không lấy được dữ liệu khách hàng): {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            return customers;

        }

            public static bool AddCustomer(string fullName, string phone, string addressLine, string city, string province)
            {
                try
                {
                    using (var connection = new DatabaseConnection().GetConnection())
                    {
                        using (SqlCommand command = new SqlCommand("AddCustomer", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số vào stored procedure
                            command.Parameters.AddWithValue("@FullName", fullName);
                            command.Parameters.AddWithValue("@Phone", phone);
                            command.Parameters.AddWithValue("@AddressLine", addressLine);
                            command.Parameters.AddWithValue("@City", city);
                            command.Parameters.AddWithValue("@Province", province);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            // Nếu có dòng bị ảnh hưởng, tức là khách hàng đã được thêm thành công
                            return rowsAffected > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error(Không thêm được khách hàng mới): {ex.Message}\nStackTrace: {ex.StackTrace}");
                    return false;
                }
            }
        }
    }

