using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    public class Products
    {
        public int ProductId;
        public string ProductName;
        public double Price;

        public Products(int pid,string pname,double price)
        {
            ProductId = pid;
            ProductName = pname;
            Price = price;
        }


        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
        }


    }
    class Question2
    {
        static void Main()
        {
            Products[] products = new Products[10];

            

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for product {i + 1}:");

                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                products[i] = new Products(id, name, price);
            }

            for (int i = 0; i < products.Length - 1; i++)
            {
                for (int j = i + 1; j < products.Length; j++)
                {
                    if (products[i].Price > products[j].Price)
                    {
                        Products temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }

            Console.WriteLine("Products sorted by price:");
            foreach (Products product in products)
            {
                product.Display();
            }

            Console.ReadLine();
        }
    }
}






