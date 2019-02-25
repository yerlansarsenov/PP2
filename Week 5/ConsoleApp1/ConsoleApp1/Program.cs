using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        public static void Serialization(Complex com)
        {

            FileStream file = new FileStream("saveit.xml", FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(Complex));
            xml.Serialize(file, com);
            file.Close();
        }
        public static void Deserialization(Complex com)
        {
            FileStream file = new FileStream("saveit.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(Complex));
            while (true)
            {
                try
                {
                    com = xml.Deserialize(file) as Complex;
                    com.Print();
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    file.Close();
                }
            }
        }
        static void Main(string[] args)
        {
            Complex c = new Complex();
            c.a = int.Parse(Console.ReadLine());
            c.b = int.Parse(Console.ReadLine());
            Serialization(c);
            Complex b = new Complex();
            Deserialization(b);
            Console.ReadKey();
        }
    }
}
