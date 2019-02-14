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
        public static bool Prime(int a)   //  булевая функция для проверки протое ли число
        {
            if (a <= 1)    // число 1 или меньше сразу же исключается
            {
                return false;
            }
            for(int i = 2; i <= a / 2; i++)   // если число разделяется без остатка на 2 и больше числа то оно составное
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;   // иначе простое
        }
        static void Main(string[] args)
        {
            StreamReader qw = new StreamReader(@"C:\Users\user1\Desktop\PP2\Week 2\Task2\Task2\Text.txt");  // "инструмент" для чтения текста
            string arr = qw.ReadToEnd();   //  переменная  arr принимает значение текста Text
            string[] arra = arr.Split(' ');    // разделяем текст на элементы стрингового массива через пробел
            StreamWriter s = new StreamWriter(@"C:\Users\user1\Desktop\PP2\Week 2\Task2\Task2\output.txt");  // "инструмент" для ввода текста
           
            for (int i = 0; i < arra.Length; i++)   // пробегаемся по количеству элементов массива
            {
                int we = int.Parse(arra[i]);  // конвертируем каждый элемент массива со стринга в интеджер
                
              
                if (Prime(we))         // проверяем простое ли число
                {
                      s.Write(we);   // если простое, то вводим его в текст output
                    s.Write(" ");               
                }
            }
            s.Close();

           
         
            
        }
    }
}
