using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public static bool Polyndrom(string q)
        {
            bool qw = true;
            for(int i = 0; i <= q.Length/2; i++)
            {
                if (q[i] != q[q.Length - 1 - i])
                {
                    qw = false;
                    return qw;
                }
            }
            return qw;
        }
        static void Main(string[] args)
        {
            string file = File.ReadAllText(@"C:\Users\user1\Desktop\PP2\Week 2\ConsoleApp1\ConsoleApp1\text.txt");
            if (Polyndrom(file))
            {
                Console.WriteLine("Yes");
            }
            else Console.WriteLine("No");

            Console.ReadKey();
        }
    }
}
