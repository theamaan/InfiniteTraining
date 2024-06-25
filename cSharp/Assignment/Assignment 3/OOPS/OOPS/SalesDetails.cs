using System;

namespace OOPS
{
    class SalesDetails
    {
        public int SalesNo { get; private set; }
        public int ProductNo { get; private set; }
        public int Price { get; private set; }
        public DateTime DateOfSale { get; private set; }
        public int Quantity { get; private set; }
        public int TotalAmount { get; private set; }

        public SalesDetails(int salesNo, int productNo, int price, DateTime dateOfSale, int quantity)
        {
            this.SalesNo = salesNo;
            this.ProductNo = productNo;
            this.Price = price;
            this.DateOfSale = dateOfSale;
            this.Quantity = quantity;
            this.TotalAmount = 0; // Initialize TotalAmount to 0
        }

        public void Sales()
        {
            this.TotalAmount = this.Quantity * this.Price;
        }

        public void ShowData()
        {
            Console.WriteLine("Sales No: " + this.SalesNo);
            Console.WriteLine("Product No: " + this.ProductNo);
            Console.WriteLine("Price: " + this.Price);
            Console.WriteLine("Date of Sale: " + this.DateOfSale.ToString("d"));
            Console.WriteLine("Quantity: " + this.Quantity);
            Console.WriteLine("Total Amount: " + this.TotalAmount);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Sales Number: ");
                int salesNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Product Number: ");
                int productNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Price: ");
                int price = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Date of Sale (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();
                DateTime dateOfSale;
                while (!DateTime.TryParse(dateInput, out dateOfSale))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in yyyy-mm-dd format: ");
                    dateInput = Console.ReadLine();
                }

                Console.WriteLine("Enter Quantity: ");
                int qty = Convert.ToInt32(Console.ReadLine());

                // Create a SalesDetails object with the provided input
                SalesDetails sale = new SalesDetails(salesNo, productNo, price, dateOfSale, qty);

                // Calculate the TotalAmount
                sale.Sales();

                // Display the sale details
                sale.ShowData();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input format is not valid: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
