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
        public static bool Polyndrom(string q)   // булевая функция для проверки на полиндромность
        {
            bool qw = true;   
            for(int i = 0; i <= q.Length/2; i++)    // пробегаемся до середины текста и проверяем первый и последний элемент на сходство
            {
                if (q[i] != q[q.Length - 1 - i])   //  если не равны то текст является не полиндромом, функция возвращает значение false
                {
                    qw = false;
                    return qw;
                }
            }
            return qw;    // если же все элементы равны, то функция возвращает значение true
        }
        static void Main(string[] args)
        {
            string file = File.ReadAllText(@"C:\Users\user1\Desktop\PP2\Week 2\Task1\ConsoleApp1\text.txt");   // стринговая переменная file принимает значение текста в данной path
            if (Polyndrom(file))    // проверяем текст на полиндромность
            {
                Console.WriteLine("Yes");   // если полиндром выводим yes, иначе no
            }
            else Console.WriteLine("No");

            Console.ReadKey();   // ЧТОБЫ КОНСОЛЬ НЕ ЗАКРЫЛАСЬ СРАЗУ
        }
    }
}
