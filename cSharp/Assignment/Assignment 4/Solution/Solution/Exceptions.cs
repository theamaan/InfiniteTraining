using System;

namespace Solution
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

 
    public class BankAccount
    {
        public string AccountHolder { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            Balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New Balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for the withdrawal.");
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawn: {amount:C}. New Balance: {Balance:C}");
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current Balance: {Balance:C}");
        }
    }

    class Exceptions
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter account holder's name: ");
                string accountHolder = Console.ReadLine();
                Console.Write("Enter initial balance: ");
                decimal initialBalance = decimal.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(accountHolder, initialBalance);

                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. Exit");
                    Console.Write("Option: ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter amount to deposit: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
                            account.Deposit(depositAmount);
                            break;
                        case 2:
                            Console.Write("Enter amount to withdraw: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                            account.Withdraw(withdrawAmount);
                            break;
                        case 3:
                            account.CheckBalance();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values for amounts.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
