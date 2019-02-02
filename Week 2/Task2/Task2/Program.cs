using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        public static bool Prime(int a)
        {
            if (a <= 1)
            {
                return false;
            }
            for(int i = 2; i <= a / 2; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            StreamReader qw = new StreamReader(@"C:\Users\user1\Desktop\PP2\Week 2\Task2\Task2\Text.txt");
            string arr = qw.ReadToEnd();
            string[] arra = arr.Split(' ');
            StreamWriter s = new StreamWriter(@"C:\Users\user1\Desktop\PP2\Week 2\Task2\Task2\output.txt");
           
            for (int i = 0; i < arra.Length; i++)
            {
                int we = int.Parse(arra[i]);
                
              
                if (Prime(we))         
                {
                      s.Write(we);
                    s.Write(" ");               
                }
            }
            s.Close();

           
         
            
        }
    }
}
