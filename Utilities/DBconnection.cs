using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Utilities
{
    public class DatabaseConnection
    {
        // Read the connection string from app.config
        private readonly string connectionString;

        public DatabaseConnection()
        {
            try
            {
                connectionString = "Server=DESKTOP-FKLCNTQ\\MLANHEM;Database=bookStoreManager_db;User Id=sa;Password=anmisoi12;TrustServerCertificate=True;"; // Replace "YourConnectionStringName" with the name of your connection string in app.config
                if (connectionString == null)
                {
                    throw new ConfigurationErrorsException("Connection string not found in app.config");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                // Handle configuration errors appropriately - log them and potentially throw a custom exception
                Console.WriteLine($"Error loading connection string from config: {ex.Message}");
                throw; // Or handle it differently based on your application's needs
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }

        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}