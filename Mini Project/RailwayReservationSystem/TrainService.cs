using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // 'user' or 'admin'
    }
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainNumber { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public string ClassOfTravel { get; set; }
        public string Status { get; set; }
        public int SeatsAvailable { get; set; }
    }
    class TrainService
    {
        private readonly string connectionString;
        private readonly User currentUser;
        public TrainService(string connectionString, User currentUser)
        {
            this.connectionString = connectionString;
            this.currentUser = currentUser;
        }
        public void AddTrain(Train train)
        {
            if (currentUser.Role != "admin")
            {
                throw new UnauthorizedAccessException("Only admins can add trains.");
            }

            string query = "INSERT INTO Trains (train_number, train_name, source, destination, price, class_of_travel, status, seats_available) VALUES (@train_number, @train_name, @source, @destination, @price, @class_of_travel, @status, @seats_available)";
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
        public List<Train> SearchTrains(string source, string destination, string classOfTravel)
        {
            List<Train> trains = new List<Train>();
            string query = "SELECT * FROM Trains WHERE source = @source AND destination = @destination AND class_of_travel = @classOfTravel AND status = 'active'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@source", source);
                command.Parameters.AddWithValue("@destination", destination);
                command.Parameters.AddWithValue("@classOfTravel", classOfTravel);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    trains.Add(new Train
                    {
                        TrainId = (int)reader["train_id"],
                        TrainNumber = reader["train_number"].ToString(),
                        TrainName = reader["train_name"].ToString(),
                        Source = reader["source"].ToString(),
                        Destination = reader["destination"].ToString(),
                        Price = (decimal)reader["price"],
                        ClassOfTravel = reader["class_of_travel"].ToString(),
                        Status = reader["status"].ToString(),
                        SeatsAvailable = (int)reader["seats_available"]
                    });
                }
            }
            return trains;
        }
        public void BookTickets(int trainId, int numberOfTickets)
        {
            if (numberOfTickets < 1 || numberOfTickets > 3)
            {
                throw new ArgumentException("You can book between 1 and 3 tickets.");
            }

            string query = "SELECT seats_available, status FROM Trains WHERE train_id = @trainId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@trainId", trainId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int seatsAvailable = (int)reader["seats_available"];
                    string status = reader["status"].ToString();

                    if (status != "active")
                    {
                        throw new InvalidOperationException("The train is not active.");
                    }

                    if (seatsAvailable < numberOfTickets)
                    {
                        throw new InvalidOperationException("Not enough seats available.");
                    }

                    reader.Close();

                    // Proceed with booking
                    string bookQuery = "INSERT INTO Bookings (train_id,user_id,booking_date ,seats_booked,status) VALUES (@TrainId, @UserId, @BookingDate, @SeatsBooked, 'confirmed');" +
                                       "UPDATE Trains SET seats_available = seats_available - @numberOfTickets WHERE train_id = @trainId";
                    SqlCommand bookCommand = new SqlCommand(bookQuery, connection);
                    bookCommand.Parameters.AddWithValue("@UserId", currentUser.UserId);
                    bookCommand.Parameters.AddWithValue("@TrainId", trainId);
                    bookCommand.Parameters.AddWithValue("@SeatsBooked", numberOfTickets);
                    bookCommand.Parameters.AddWithValue("@NumberOfTickets", numberOfTickets);
                    bookCommand.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                    bookCommand.ExecuteNonQuery();
                }
                else
                {
                    throw new InvalidOperationException("Train not found.");
                }
            }
        }
    }
}
