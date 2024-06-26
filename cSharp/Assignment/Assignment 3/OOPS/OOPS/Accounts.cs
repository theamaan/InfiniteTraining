using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Accounts
    {
        public int accountNo;
        public string customerName;
        public string accountType;
        public string transactionType;
        public int amount;
        public int balance;

        public Accounts(int accountNo, string customerName, string accountType, string transactionType, int amount, int balance)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.transactionType = transactionType;
            this.amount = amount;
            this.balance = balance;
        }

        public void UpdateBalance(string transactionType, int amount)
        {
            this.transactionType = transactionType;
            this.amount = amount;
            if (transactionType.Equals("d", StringComparison.OrdinalIgnoreCase))
            {
                Credit(amount);
            }
            else if (transactionType.Equals("w", StringComparison.OrdinalIgnoreCase))
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type");
            }
        }

        public void Credit(int amount)
        {
            balance += amount;
        }

        public void Debit(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void Show()
        {
            Console.WriteLine("Account No: " + accountNo);
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Account Type: " + accountType);
            Console.WriteLine("Transaction Type: " + transactionType);
            Console.WriteLine("Amount: " + amount);
            Console.WriteLine("Balance: " + balance);
        }

        static void Main(string[] args)
        {
            Accounts account = new Accounts(100, "Amaan", "Savings", "d", 0, 10000);


            Console.WriteLine("Initial account data:");
            account.Show();


            Console.WriteLine("\nPerforming a deposit of 500...");
            account.UpdateBalance("d", 500);
            account.Show();


            Console.WriteLine("\nPerforming a withdrawal of 300...");
            account.UpdateBalance("w", 300);
            account.Show();


            Console.WriteLine("\nAttempting an invalid transaction type...");
            account.UpdateBalance("x", 100);
            account.Show();


            Console.WriteLine("\nAttempting a withdrawal of 15000...");
            account.UpdateBalance("w", 15000);
            account.Show();

            Console.ReadLine();

        }
    }
}
