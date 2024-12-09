using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookStore.Utilities;
using BookStore.Models.ModelViews;
using BookStore.Models.Entity;

namespace BookStore.Models.Data
{
    internal class OrderDAO
    {
        public static (int CustomerID, int OrderID) AddOrder(ModelViews.Order order)
        {
            try
            {
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("AddOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục, xử lý giá trị null nếu cần
                        command.Parameters.AddWithValue("@CustomerID", order.IdCustomer.HasValue ? (object)order.IdCustomer.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentMethod", order.paymentMethod ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Discount", order.discount);
                        command.Parameters.AddWithValue("@TotalAmount", order.total);
                        command.Parameters.AddWithValue("@Note", order.note ?? (object)DBNull.Value);

                        // Đọc kết quả trả về từ thủ tục
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int returnedCustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
                                int orderID = reader.GetInt32(reader.GetOrdinal("OrderID"));
                                return (returnedCustomerID, orderID);
                            }
                            else
                            {
                                throw new Exception("No data returned from stored procedure.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the order.", ex);
            }
        }


        //thêm item order
        public static void AddOrderItems(int orderId, List<OrderItem> orderItems)
        {
            try
            {
                using (SqlConnection connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    foreach (var item in orderItems)
                    {
                        try
                        {
                            using (SqlCommand command = new SqlCommand("AddOrderItem", connection))
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                // Thêm tham số cho thủ tục
                                command.Parameters.AddWithValue("@OrderID", orderId);
                                command.Parameters.AddWithValue("@ProductID", item.ProductId);
                                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                command.Parameters.AddWithValue("@price", item.UnitPrice);

                                // Thực thi thủ tục
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"An error occurred while adding order item with ProductID = {item.ProductId}.", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding order items.", ex);
            }
        }

        public static List<Order> GetOrderDetails()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new DatabaseConnection().GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetOrderDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Thực thi thủ tục
                    SqlDataReader reader = command.ExecuteReader();

                    // Duyệt qua các dòng kết quả
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            IdOrder = reader.GetInt32(reader.GetOrdinal("OrderID")),
                            cretateDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                            IdCustomer = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                            paymentMethod = reader.GetString(reader.GetOrdinal("method")),
                            note = reader.GetString(reader.GetOrdinal("Note")),
                            total = reader.GetDecimal(reader.GetOrdinal("TotalAmount"))
                        };

                        orders.Add(order);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log hoặc xử lý ngoại lệ ở đây
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return orders;
        }

    }
}
