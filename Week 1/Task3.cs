using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        
            static void CompleteArray(int[] ar1, int[] ar2)  //  создаем статичный метод
            {
                for (int i = 0; i < ar1.Length; i++)
                {
                    ar2[2 * i] = ar1[i];     //  каждые два элемента второго массива приобретают значения
                    ar2[2 * i + 1] = ar1[i];   //  каждого элемента первого массива
                }
            }
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());  //  количество элементов первого массива
                string s = Console.ReadLine(); //  вводим первый массив в виде одной строки
                string[] ars = s.Split(' '); // разделяем каждое число массива в виде массива строк
                int[] arr2 = new int[2*n];  //  обьявляем второй массив с двое большим колличеством элементов
                int[] arr1 = new int[n];  // обьявляем первый массив
                for (int i = 0; i < ars.Length; i++)  // все элементы массива строк конвертируем в элементы массива целых чисел 
                {
                    arr1[i] = int.Parse(ars[i]);
                }
                CompleteArray(arr1, arr2);   // метод для заполнения второго массива по требованию задачи
                foreach (int a in arr2)   //  Выводим элементы итогового массива
                {
                    Console.Write(a + " ");
                }
                Console.ReadLine();  // ЧТОБЫ КОНСОЛЬ НЕ ЗАКРЫЛСЯ СРАЗУ
            }
        }
    }

