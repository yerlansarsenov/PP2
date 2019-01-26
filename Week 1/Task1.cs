using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static bool Prime(int n)   // буленовая Функция проверяющяя простое ли число
        {
            bool b=true;
            if (n <= 1)
            {
                b = false;
            }
            for(int i = 2; i < n ; i++)
            {
              if (n % i == 0) // Если найдется число на которое делится проверяющееся число, то функция возвращает false, то есть число не простое
                {
                    b = false;
                    return b;
                }
            }
            return b;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());  // Вводим количество элементов массива
            int[] ar = new int[n];
            string s = Console.ReadLine(); // Вводим элементы массива через строку
            string[] ss = s.Split(' ');  // разделяем каждое число на отдельные элементы массива
            for (int i = 0; i < ss.Length; i++)  // Конвертируем string-овые числа в integer
            {
                ar[i] = int.Parse(ss[i]);
            }
            List<int> b = new List<int>();
            // обьявляем интовый массив
            foreach (int q in ar)  // пробегаемся по массиву
            {
                if (Prime(q))  // проверяем простые числа и вводим их в другой массив
                {
                    b.Add(q);
                }
            }
            Console.WriteLine(b.ToArray().Length); // Выводим количество простых чисел 
            for(int i = 0; i < b.ToArray().Length; i++) // Выводим все простые числа через пробел
            {
                Console.Write(b[i] + " ");
            }
            Console.ReadLine(); ////////   ЭТО ЧТОБЫ КОНСОЛЬ НЕ ЗАКРЫВАЛАСЬ СРАЗУ
        }
    }
}
