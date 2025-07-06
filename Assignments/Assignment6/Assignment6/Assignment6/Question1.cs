using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Books
    {
        string BookName;
        string Authorname;

        public Books(string BookName, string Authorname)
        {
            this.BookName = BookName;
            this.Authorname = Authorname;
        }

        public void display()
        {
            Console.WriteLine($"The BookName is {BookName} and The Author name is {Authorname}");
        }
    }

    public class BookShelf
    {
        private Books[] bookArray = new Books[5];

        public object this[int index]
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
                    bookArray[index] = (Books)value;
                else
                    throw new IndexOutOfRangeException("Invalid index");
            }
        }

        public void DisplayBooks()
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                {
                    bookArray[i].display();
                }
                else
                    Console.WriteLine($"Slot {i + 1}: Empty");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BookShelf shelf = new BookShelf();

            shelf[0] = new Books("The Alchemist", "Paulo Coelho");
            shelf[1] = new Books("Clean Code", "Robert C. Martin");
            shelf[2] = new Books("1984", "George Orwell");
            shelf[3] = new Books("To Kill a Mockingbird", "Harper Lee");
            shelf[4] = new Books("The Pragmatic Programmer", "Andrew Hunt");

            shelf.DisplayBooks();

            Console.ReadLine();
        }
    }
}
