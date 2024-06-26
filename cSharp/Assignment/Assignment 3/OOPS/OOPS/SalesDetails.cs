using System;

namespace OOPS
{
    class SalesDetails
    {
        public int SalesNo { get; set; }
        public int ProductNo { get; set; }
        public int Price { get; set; }
        public DateTime DateOfSale { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; private set; }

        public SalesDetails(int salesNo, int productNo, int price, DateTime dateOfSale, int quantity)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            DateOfSale = dateOfSale;
            Quantity = quantity;
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = Quantity * Price;
        }

        public void ShowData()
        {
            Console.WriteLine("Sales No: " + SalesNo);
            Console.WriteLine("Product No: " + ProductNo);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Date of Sale: " + DateOfSale.ToShortDateString());
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Total Amount: " + TotalAmount);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine();

            Console.WriteLine("Enter the Number of sales: ");
            int salesNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Product Number: ");
            int productNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Date of Sale (yyyy-MM-dd): ");
            DateTime dateOfSale = DateTime.Parse(Console.ReadLine());

            SalesDetails sale = new SalesDetails(salesNo, productNo, price, dateOfSale, quantity);

            sale.ShowData();
            Console.ReadLine();
        }
    }
}
