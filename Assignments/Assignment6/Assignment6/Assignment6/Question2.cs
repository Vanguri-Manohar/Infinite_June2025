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
    class Program2
    {
        static void WriteBinary()
        {
            Console.Write("Enter the number of strings to write: ");
            int count = int.Parse(Console.ReadLine());

            string[] messages = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter string {i + 1}: ");
                messages[i] = Console.ReadLine();
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open("C:\\Users\\saisatyam\\Desktop\\Csharp\\StringArrayFile.bin", FileMode.Create)))
            {
                writer.Write(messages.Length); // Write the number of strings
                foreach (string message in messages)
                {
                    writer.Write(message);
                }
            }
        }

        static void ReadBinary()
        {
            using (BinaryReader reader = new BinaryReader(File.Open("C:\\Users\\saisatyam\\Desktop\\Csharp\\StringArrayFile.bin", FileMode.Open)))
            {
                int count = reader.ReadInt32(); // Read the number of strings
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("String " + (i + 1) + ": " + reader.ReadString());
                }
            }
        }

        static void Main()
        {
            WriteBinary();
            ReadBinary();
            Console.ReadLine();
        }
    }



}
