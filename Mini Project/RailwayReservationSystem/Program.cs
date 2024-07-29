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
                Console.WriteLine("Enter user ID:");
                int userId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter role (user/admin):");
                string role = Console.ReadLine();

                User currentUser = new User
                {
                    UserId = userId,
                    Username = username,
                    Role = role
                };

                TrainService trainService = new TrainService(connectionString, currentUser);

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
                    trainService.AddTrain(newTrain);
                    Console.WriteLine("Train added successfully.");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else if (userType == "user")
            {
                UserService userService = new UserService(connectionString);
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                int choice = int.Parse(Console.ReadLine());
                User loggedInUser = null;

                switch (choice)
                {
                    case 1:
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
                        break;

                    case 2:
                        Console.WriteLine("Enter username:");
                        string loginUsername = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string loginPassword = Console.ReadLine();

                        try
                        {
                            loggedInUser = userService.LoginUser(loginUsername, loginPassword);
                            Console.WriteLine($"Welcome, {loggedInUser.Username}!");
                            // Continue with the application flow for logged-in user
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                if (loggedInUser != null)
                {
                    TrainService trainService = new TrainService(connectionString, loggedInUser);

                    Console.WriteLine("1. Search Trains");
                    Console.WriteLine("2. Book Tickets");
                    int userChoice = int.Parse(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter source station:");
                            string source = Console.ReadLine();
                            Console.WriteLine("Enter destination station:");
                            string destination = Console.ReadLine();
                            Console.WriteLine("Enter class of travel:");
                            string classOfTravel = Console.ReadLine();

                            List<Train> trains = trainService.SearchTrains(source, destination, classOfTravel);

                            if (trains.Count > 0)
                            {
                                Console.WriteLine("Available Trains:");
                                foreach (var train in trains)
                                {
                                    string priceFormatted = train.Price.ToString("N2", new CultureInfo("en-IN"));
                                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                                    Console.WriteLine($"{train.TrainName} ({train.TrainNumber}) - {train.ClassOfTravel} - ₹ {priceFormatted} - {train.SeatsAvailable} seats available");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No trains available for the specified criteria.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter train ID to book:");
                            int trainId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter number of tickets to book (max 3):");
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
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please restart the application and enter 'admin' or 'user'.");
            }

            Console.Read();
        }
    }
}
