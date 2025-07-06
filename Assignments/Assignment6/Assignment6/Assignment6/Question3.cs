using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Assignment6
{
    class Program3
    {
        static void Main()
        {
            
            try
            {
                int lineCount = File.ReadAllLines("C:\\Users\\saisatyam\\Desktop\\Csharp\\StringArrayFile.bin").Length;
                Console.WriteLine("Number of lines in the file: " + lineCount);

                // To read the number of Characters
                string content = File.ReadAllText("C:\\Users\\saisatyam\\Desktop\\Csharp\\StringArrayFile.bin");
                Console.WriteLine(content.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}




//C:\\Users\\saisatyam\\Desktop\\Csharp\\StringArrayFile.bin