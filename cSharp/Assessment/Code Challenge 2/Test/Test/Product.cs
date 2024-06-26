using System;

namespace Test
{
    class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Product(int productId, string productName, int price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProductName: {ProductName}, Price: {Price}";
        }
    }

    class StudentProgram
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[10];

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for Product {i + 1}:");

                Console.Write("ProductId: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("ProductName: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                int price = int.Parse(Console.ReadLine());

                products[i] = new Product(productId, productName, price);
            }
            Array.Sort(products);

            Console.WriteLine("\nSorted Products by Price:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.ReadLine();
        }
    }
}
