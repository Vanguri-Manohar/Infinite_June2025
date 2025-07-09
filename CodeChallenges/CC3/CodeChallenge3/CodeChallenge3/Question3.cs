using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeChallenge3
{
    class Question3
    {
        public static void WriteStream()
        {
            FileStream fs = new FileStream("OurFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Enter the string :");
            string str = Console.ReadLine();
            sw.Write(str);
            sw.Flush();
            sw.Close();
        }

        public static void ReadStream()
        {
            FileStream fs = new FileStream("OurFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine("{0}", str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        static void Main()
        {
            WriteStream();
            ReadStream();

            Console.Read();
        }
    }
}
