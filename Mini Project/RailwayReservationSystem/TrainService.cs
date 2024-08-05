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
        private readonly string connectionString; //ensure immutability and enhancing code reliability
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

            string query = "INSERT INTO Trains (train_number, train_name, source, destination, price, class_of_travel, status, seats_available) " +
                           "VALUES (@train_number, @train_name, @source, @destination, @price, @class_of_travel, @status, @seats_available)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@train_number", train.TrainNumber); //helps prevent SQL injection
                                                                                     //attacks by ensuring that user
                                                                                     //inputs are treated as parameters
                                                                                     //rather than executable code
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
        public void CancelTickets(int bookingId, int numberOfTickets)
        {
            if (numberOfTickets < 1)
            {
                throw new ArgumentException("You must cancel at least one ticket.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string query = "SELECT seats_booked, train_id FROM Bookings WHERE booking_id = @bookingId AND user_id = @userId";
                    SqlCommand command = new SqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@bookingId", bookingId);
                    command.Parameters.AddWithValue("@userId", currentUser.UserId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int bookedTickets = (int)reader["seats_booked"];
                        int trainId = (int)reader["train_id"];

                        if (bookedTickets < numberOfTickets)
                        {
                            throw new InvalidOperationException("You cannot cancel more tickets than you have booked.");
                        }

                        reader.Close();

                        // Proceed with cancellation
                        string cancelQuery = "INSERT INTO Cancellations (booking_id, cancellation_date, seats_cancelled) VALUES (@bookingId, @cancellationDate, @seatsCancelled); " +
                                             "UPDATE Trains SET seats_available = seats_available + @numberOfTickets WHERE train_id = @trainId; " +
                                             "UPDATE Bookings SET seats_booked = seats_booked - @numberOfTickets WHERE booking_id = @bookingId";

                        SqlCommand cancelCommand = new SqlCommand(cancelQuery, connection, transaction);
                        cancelCommand.Parameters.AddWithValue("@bookingId", bookingId);
                        cancelCommand.Parameters.AddWithValue("@numberOfTickets", numberOfTickets);
                        cancelCommand.Parameters.AddWithValue("@cancellationDate", DateTime.Now);
                        cancelCommand.Parameters.AddWithValue("@trainId", trainId);
                        cancelCommand.Parameters.AddWithValue("@seatsCancelled", numberOfTickets);

                        cancelCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    else
                    {
                        throw new InvalidOperationException("Booking not found.");
                    }
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<BookingHistory> GetBookingHistory()
        {
            List<BookingHistory> bookingHistories = new List<BookingHistory>();

            string query = "SELECT b.booking_id, b.user_id, b.train_id, b.seats_booked, b.booking_date, t.train_name " +
                           "FROM Bookings b " +
                           "JOIN Trains t ON b.train_id = t.train_id " +
                           "WHERE b.user_id = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", currentUser.UserId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BookingHistory history = new BookingHistory
                    {
                        BookingId = (int)reader["booking_id"],
                        UserId = (int)reader["user_id"],
                        TrainId = (int)reader["train_id"],
                        NumberOfTickets = (int)reader["seats_booked"],
                        BookingDate = (DateTime)reader["booking_date"],
                        TrainName = reader["train_name"].ToString()
                    };
                    bookingHistories.Add(history);
                }
            }

            return bookingHistories;
        }


        public List<CancellationHistory> GetCancellationHistory()
        {
            List<CancellationHistory> cancellationHistories = new List<CancellationHistory>();

            string query = "SELECT c.cancellation_id, c.booking_id, b.user_id, c.seats_cancelled, c.cancellation_date, t.train_name " +
                           "FROM Cancellations c " +
                           "JOIN Bookings b ON c.booking_id = b.booking_id " +
                           "JOIN Trains t ON b.train_id = t.train_id " +
                           "WHERE b.user_id = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", currentUser.UserId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CancellationHistory history = new CancellationHistory
                    {
                        CancellationId = (int)reader["cancellation_id"],
                        BookingId = (int)reader["booking_id"],
                        UserId = (int)reader["user_id"],
                        NumberOfTickets = (int)reader["seats_cancelled"], // Corrected column name
                        CancellationDate = (DateTime)reader["cancellation_date"],
                        TrainName = reader["train_name"].ToString()
                    };
                    cancellationHistories.Add(history);
                }
            }

            return cancellationHistories;
        }
    }
}