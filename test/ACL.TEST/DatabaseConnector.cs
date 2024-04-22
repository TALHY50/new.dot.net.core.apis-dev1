
using MySql.Data.MySqlClient;
using DotNetEnv;
using Microsoft.AspNetCore.Hosting.Server;
using MySqlConnector;
using SharedLibrary.Models;
using ACL.Database.Models;

namespace ACL.Tests
{
    public class DatabaseConnector
    {
        private string connectionString;
        public DatabaseConnector()
        {
            var server = "127.0.0.1";
            var database = "acl_db";
            var userName = "root";
            var password = "";
            this.connectionString = $"server={server};database={database};User ID={userName};Password={password};" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public List<AclRole> ConnectAndQueryDatabase()
        {
            List<AclRole> roles = new List<AclRole>();
            using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
               
                try
                {
                    connection.Open();
                   
                    string query = "SELECT * FROM acl_roles";
                    using (var command = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                roles.Add(new AclRole { Id = reader.GetUInt64("id"), Name = reader.GetString("name"), Title = reader.GetString("title") });
                            }
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    // Handle exception
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    connection.Close();
                }
                
            }
            return roles;
        }
    }
}