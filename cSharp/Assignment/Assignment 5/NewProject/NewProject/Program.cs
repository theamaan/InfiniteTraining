using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author Name: {AuthorName}");
        }
    }

    class BookShelf
    {
        private Books[] bookArray = new Books[5]; // Array to hold Books objects

        // Indexer to get and set Books objects
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < bookArray.Length)
                {
                    return bookArray[index];
                }
                throw new IndexOutOfRangeException("Index out of range");
            }
            set
            {
                if (index >= 0 && index < bookArray.Length)
                {
                    bookArray[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Creating BookShelf object
            BookShelf bookShelf = new BookShelf();

            // Adding books to the bookshelf using the indexer
            bookShelf[0] = new Books("To Kill a Mockingbird", "Harper Lee");
            bookShelf[1] = new Books("Wallbanger", "Alice Clayton");
            bookShelf[2] = new Books("Credence", "Penelope Douglas");
            bookShelf[3] = new Books("Pride and Prejudice", "Jane Austen");
            bookShelf[4] = new Books("The Catcher in the Rye", "J.D. Salinger");

            // Displaying the details of books
            for (int i = 0; i < 5; i++)
            {
                bookShelf[i].Display();
            }
            Console.ReadLine();
        }
    }
}
