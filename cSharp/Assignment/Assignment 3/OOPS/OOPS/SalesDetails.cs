using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class SalesDetails
    {
        public int salesNo;
        public int productNo;
        public int price;
        public DateTime dateOfSale;
        public int quantity;
        public int totalAmount;

        public SalesDetails(int salesNo, int productNo, int price, DateTime dateOfSale, int quantity)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.dateOfSale = dateOfSale;
            this.quantity = quantity;
            sales();
        }
        public void sales()
        {
            this.totalAmount = this.quantity * this.price;
        }
        public void ShowData()
        {
            Console.WriteLine("Sales No: " + this.salesNo);
            Console.WriteLine("Product No: " + this.productNo);
            Console.WriteLine("Price: " + this.price);
            Console.WriteLine("Date of Sale: " + dateOfSale.ToShortDateString());
            Console.WriteLine("Quantity: " + this.quantity);
            Console.WriteLine("Total Amount: " + this.totalAmount);
        }
        static void Main(string[] args)
        {

            SalesDetails sale = new SalesDetails(1, 100, 1200, DateTime.Now, 3);

            sale.ShowData();
            Console.ReadLine();

        }
    }
}
