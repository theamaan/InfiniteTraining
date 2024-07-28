using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    class UserService
    {
        private readonly string connectionString;
        public UserService(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void RegisterUser(User user)
        {
            string query = "INSERT INTO Users (username, password, role) VALUES (@username, @password, @role)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", HashPassword(user.Password)); // Hash the password
                command.Parameters.AddWithValue("@role", user.Role);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public User LoginUser(string username, string password)
        {
            string query = "SELECT user_id, username, role FROM Users WHERE username = @username AND password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", HashPassword(password)); // Hash the password for comparison

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        UserId = (int)reader["user_id"],
                        Username = reader["username"].ToString(),
                        Role = reader["role"].ToString()
                    };
                }
                else
                {
                    throw new UnauthorizedAccessException("Invalid username or password.");
                }
            }
        }

        private string HashPassword(string password)
        {
            // Implement a hashing function (e.g., using SHA-256)
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
