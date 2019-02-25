using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        public static void Serialization(List<Mark> marks)
        {
            FileStream file = new FileStream("save.xml",FileMode.Create,FileAccess.ReadWrite);
           // foreach(Mark mark in marks)
            
                XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
                
                xs.Serialize(file, marks);
            
                
            file.Close();
        }
        public static void Deserialization(List<Mark> marks)
        {
            FileStream file = new FileStream("save.xml",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
           
                
                   marks  = xs.Deserialize(file) as List<Mark>;
                    

                 for(int i = 0; i < marks.ToArray().Length; i++)
            {
                marks[i].GetLetter();
                Console.WriteLine(marks[i]);
            }
            
            file.Close();
        }
        
        static void Main(string[] args)
        {
            List<Mark> marks = new List<Mark>();
            List<Mark> otherMarks = new List<Mark>();
            Console.WriteLine("Enter the mark (in %):");
            Mark mark = new Mark();
            mark.point = int.Parse(Console.ReadLine());
            marks.Add(mark);
            Mark mark2 = new Mark();
            Console.WriteLine("Enter the second mark (in %):");
            mark2.point = int.Parse(Console.ReadLine());
            marks.Add(mark2);
            Serialization(marks);
            Deserialization(otherMarks);
           
           
            Console.ReadKey();
        }
    }
}
