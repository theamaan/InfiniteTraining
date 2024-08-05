using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace RailwayReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ICS-LT-H3J9R73\SQLEXPRESS;Initial Catalog=railwayReservationSystem;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Database connection successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Console.WriteLine("Are you an admin or a user? (admin/user):");
            string userType = Console.ReadLine().Trim().ToLower();
            if (userType == "admin")
            {
                HandleAdminOperations(connectionString);
            }
            else if (userType == "user")
            {
                HandleUserOperations(connectionString);
            }
            else
            {
                Console.WriteLine("Invalid input. Please restart the application and enter 'admin' or 'user'.");
            }

            Console.Read();
        }

        static void HandleAdminOperations(string connectionString)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            User currentUser = new User { Role = "admin" };
            AdminService adminService = new AdminService(connectionString, currentUser);

            if (adminService.ValidateAdminCredentials(username, password))
            {
                Console.WriteLine("Admin authenticated successfully.");
                DisplayAdminMenu(adminService);
            }
            else
            {
                Console.WriteLine("Invalid admin credentials.");
            }
        }

        static void DisplayAdminMenu(AdminService adminService)
        {
            Console.WriteLine("Admin Functions:");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Update Train");
            Console.WriteLine("3. Delete Train");
            Console.WriteLine("4. Update User Role");
            Console.WriteLine("5. Delete User");

            int adminChoice = int.Parse(Console.ReadLine());

            switch (adminChoice)
            {
                case 1:
                    AddTrain(adminService);
                    break;
                case 2:
                    UpdateTrain(adminService);
                    break;
                case 3:
                    DeleteTrain(adminService);
                    break;
                case 4:
                    UpdateUserRole(adminService);
                    break;
                case 5:
                    DeleteUser(adminService);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void AddTrain(AdminService adminService)
        {
            Train newTrain = new Train();

            Console.WriteLine("Enter train number:");
            newTrain.TrainNumber = Console.ReadLine();
            Console.WriteLine("Enter train name:");
            newTrain.TrainName = Console.ReadLine();
            Console.WriteLine("Enter source station:");
            newTrain.Source = Console.ReadLine();
            Console.WriteLine("Enter destination station:");
            newTrain.Destination = Console.ReadLine();
            Console.WriteLine("Enter price:");
            newTrain.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter class of travel:");
            newTrain.ClassOfTravel = Console.ReadLine();
            Console.WriteLine("Enter status (active/inactive):");
            newTrain.Status = Console.ReadLine();
            Console.WriteLine("Enter seats available:");
            newTrain.SeatsAvailable = int.Parse(Console.ReadLine());

            try
            {
                adminService.AddTrain(newTrain);
                Console.WriteLine("Train added successfully.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        static void UpdateTrain(AdminService adminService)
        {
            Console.WriteLine("Enter train ID to update:");
            int updateTrainId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new train name:");
            string newTrainName = Console.ReadLine();
            Console.WriteLine("Enter new source station:");
            string newSource = Console.ReadLine();
            Console.WriteLine("Enter new destination station:");
            string newDestination = Console.ReadLine();
            Console.WriteLine("Enter new price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter new class of travel:");
            string newClassOfTravel = Console.ReadLine();
            Console.WriteLine("Enter new status:");
            string newStatus = Console.ReadLine();
            Console.WriteLine("Enter new number of available seats:");
            int newSeatsAvailable = int.Parse(Console.ReadLine());

            Train updatedTrain = new Train
            {
                TrainId = updateTrainId,
                TrainName = newTrainName,
                Source = newSource,
                Destination = newDestination,
                Price = newPrice,
                ClassOfTravel = newClassOfTravel,
                Status = newStatus,
                SeatsAvailable = newSeatsAvailable
            };

            try
            {
                adminService.UpdateTrain(updatedTrain);
                Console.WriteLine("Train details updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void DeleteTrain(AdminService adminService)
        {
            Console.WriteLine("Enter train ID to delete:");
            int deleteTrainId = int.Parse(Console.ReadLine());

            try
            {
                adminService.DeleteTrain(deleteTrainId);
                Console.WriteLine("Train deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void UpdateUserRole(AdminService adminService)
        {
            Console.WriteLine("Enter user ID to update role:");
            int updateUserId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new role (user/admin):");
            string newRole = Console.ReadLine();

            try
            {
                adminService.UpdateUserRole(updateUserId, newRole);
                Console.WriteLine("User role updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void DeleteUser(AdminService adminService)
        {
            Console.WriteLine("Enter user ID to delete:");
            int deleteUserId = int.Parse(Console.ReadLine());

            try
            {
                adminService.DeleteUser(deleteUserId);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void HandleUserOperations(string connectionString)
        {
            UserService userService = new UserService(connectionString);
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            int choice = int.Parse(Console.ReadLine());
            User loggedInUser = null;

            switch (choice)
            {
                case 1:
                    RegisterUser(userService);
                    break;
                case 2:
                    loggedInUser = LoginUser(userService);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (loggedInUser != null)
            {
                DisplayUserMenu(connectionString, loggedInUser);
            }
        }

        static void RegisterUser(UserService userService)
        {
            Console.WriteLine("Enter username:");
            string regUsername = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string regPassword = Console.ReadLine();
            Console.WriteLine("Enter role (user/admin):");
            string regRole = Console.ReadLine();

            User newUser = new User
            {
                Username = regUsername,
                Password = regPassword,
                Role = regRole
            };

            userService.RegisterUser(newUser);
            Console.WriteLine("User registered successfully.");
        }

        static User LoginUser(UserService userService)
        {
            Console.WriteLine("Enter username:");
            string loginUsername = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string loginPassword = Console.ReadLine();

            try
            {
                User loggedInUser = userService.LoginUser(loginUsername, loginPassword);
                Console.WriteLine($"Welcome, {loggedInUser.Username}!");
                return loggedInUser;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static void DisplayUserMenu(string connectionString, User loggedInUser)
        {
            TrainService trainService = new TrainService(connectionString, loggedInUser);

            Console.WriteLine("1. Search Trains");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Cancel Tickets");
            Console.WriteLine("4. View Booking History");
            Console.WriteLine("5. View Cancellation History");
            int userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    SearchTrains(trainService);
                    break;
                case 2:
                    BookTickets(trainService);
                    break;
                case 3:
                    CancelTickets(trainService);
                    break;
                case 4:
                    ViewBookingHistory(trainService);
                    break;
                case 5:
                    ViewCancellationHistory(trainService);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void SearchTrains(TrainService trainService)
        {
            Console.WriteLine("Enter source station:");
            string source = Console.ReadLine();
            Console.WriteLine("Enter destination station:");
            string destination = Console.ReadLine();
            Console.WriteLine("Enter class of travel:");
            string classOfTravel = Console.ReadLine();

            List<Train> trains = trainService.SearchTrains(source, destination, classOfTravel);

            if (trains.Count > 0)
            {
                foreach (var train in trains)
                {
                    Console.WriteLine($"Train ID: {train.TrainId}, Train Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, Price: {train.Price}, Class: {train.ClassOfTravel}, Status: {train.Status}, Seats Available: {train.SeatsAvailable}");
                }
            }
            else
            {
                Console.WriteLine("No trains found matching your criteria.");
            }
        }

        static void BookTickets(TrainService trainService)
        {
            Console.WriteLine("Enter train ID:");
            int trainId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of tickets:");
            int numberOfTickets = int.Parse(Console.ReadLine());

            try
            {
                trainService.BookTickets(trainId, numberOfTickets);
                Console.WriteLine("Tickets booked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void CancelTickets(TrainService trainService)
        {
            Console.WriteLine("Enter booking ID:");
            int bookingId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of tickets to cancel:");
            int numberOfTickets = int.Parse(Console.ReadLine());

            try
            {
                trainService.CancelTickets(bookingId, numberOfTickets);
                Console.WriteLine("Tickets cancelled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void ViewBookingHistory(TrainService trainService)
        {
            List<BookingHistory> bookingHistories = trainService.GetBookingHistory();

            if (bookingHistories.Count > 0)
            {
                foreach (var booking in bookingHistories)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingId}, Train ID: {booking.TrainId}, Number of Tickets: {booking.NumberOfTickets}, Booking Date: {booking.BookingDate}, Train Name: {booking.TrainName}");
                }
            }
            else
            {
                Console.WriteLine("No booking history available.");
            }
        }

        static void ViewCancellationHistory(TrainService trainService)
        {
            List<CancellationHistory> cancellationHistories = trainService.GetCancellationHistory();

            if (cancellationHistories.Count > 0)
            {
                foreach (var cancellation in cancellationHistories)
                {
                    Console.WriteLine($"Cancellation ID: {cancellation.CancellationId}, Booking ID: {cancellation.BookingId}, Cancellation Date: {cancellation.CancellationDate}, Train Name: {cancellation.TrainName}, Number of Tickets: {cancellation.NumberOfTickets}");
                }
            }
            else
            {
                Console.WriteLine("No cancellation history available.");
            }
        }
    }
}