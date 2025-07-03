using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Books
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
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Books[] bookArray = new Books[5]; 

        
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < bookArray.Length)
                    return bookArray[index];
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {
                if (index >= 0 && index < bookArray.Length)
                    bookArray[index] = value;
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
        }

        
        public void DisplayAllBooks()
        {
            Console.WriteLine("Books in the shelf:");
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    bookArray[i].Display();
                else
                    Console.WriteLine($"Slot {i + 1}: Empty");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();

            // Assigning books using indexer
            shelf[0] = new Books("The Alchemist", "Paulo Coelho");
            shelf[1] = new Books("Clean Code", "Robert C. Martin");
            shelf[2] = new Books("1984", "George Orwell");
            shelf[3] = new Books("To Kill a Mockingbird", "Harper Lee");
            shelf[4] = new Books("The Pragmatic Programmer", "Andrew Hunt");

           
            shelf.DisplayAllBooks();

            Console.Read();
        }
    }
}
