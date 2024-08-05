using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public class AdminService
    {
        private readonly string connectionString;
        private readonly User currentUser;
        public AdminService(string connectionString, User currentUser)
        {
            this.connectionString = connectionString;
            this.currentUser = currentUser;
        }
        public bool ValidateAdminCredentials(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            string query = "SELECT 1 FROM Users WHERE username = @username AND password = @password AND role = 'admin'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", hashedPassword);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }


        public void AddTrain(Train train)
        {
            if (currentUser.Role != "admin")
            {
                throw new UnauthorizedAccessException("Only admins can add trains.");
            }

            string query = "INSERT INTO Trains (train_number, train_name, source, destination, price, class_of_travel, status, seats_available) " +
                           "VALUES (@train_number, @train_name, @source, @destination, @price, @class_of_travel, @status, @seats_available)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@train_number", train.TrainNumber);
                command.Parameters.AddWithValue("@train_name", train.TrainName);
                command.Parameters.AddWithValue("@source", train.Source);
                command.Parameters.AddWithValue("@destination", train.Destination);
                command.Parameters.AddWithValue("@price", train.Price);
                command.Parameters.AddWithValue("@class_of_travel", train.ClassOfTravel);
                command.Parameters.AddWithValue("@status", train.Status);
                command.Parameters.AddWithValue("@seats_available", train.SeatsAvailable);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        // Method to update train details
        public void UpdateTrain(Train train)
        {
            string query = "UPDATE Trains SET train_name = @train_name, source = @source, destination = @destination, price = @price, class_of_travel = @class_of_travel, status = @status, seats_available = @seats_available WHERE train_id = @train_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@train_name", train.TrainName);
                command.Parameters.AddWithValue("@source", train.Source);
                command.Parameters.AddWithValue("@destination", train.Destination);
                command.Parameters.AddWithValue("@price", train.Price);
                command.Parameters.AddWithValue("@class_of_travel", train.ClassOfTravel);
                command.Parameters.AddWithValue("@status", train.Status);
                command.Parameters.AddWithValue("@seats_available", train.SeatsAvailable);
                command.Parameters.AddWithValue("@train_id", train.TrainId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a train
        public void DeleteTrain(int trainId)
        {
            string query = "DELETE FROM Trains WHERE train_id = @train_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@train_id", trainId);

                connection.Open();
                command.ExecuteNonQuery();//allows you to run arbitrary SQL statements without returning a result set
            }
        }

        // Method to manage user roles (update user role)
        public void UpdateUserRole(int userId, string newRole)
        {
            string query = "UPDATE Users SET role = @role WHERE user_id = @user_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@role", newRole);
                command.Parameters.AddWithValue("@user_id", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a user
        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE user_id = @user_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
