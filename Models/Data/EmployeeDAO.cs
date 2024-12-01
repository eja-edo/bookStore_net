using BookStore.Models.ModelViews;
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
    public class EmployeeDAO
    {
        public static List<ItemEmp> GetEmployees()
        {
            List<ItemEmp> employees = new List<ItemEmp>();
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    System.Diagnostics.Debug.WriteLine(1);
                    using (SqlCommand command = new SqlCommand("GetEmployeeInformation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new ItemEmp
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Role = reader.GetString(reader.GetOrdinal("Role")),
                                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                    Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                                    Address = reader.GetString(reader.GetOrdinal("Address"))
                                });
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
    }
}
