using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static string Space(int a)     // функция для создания иерархии
        {
            string s = "      ";
            string q = "";
            for(int i = 0; i < a; i++)  // а раз выводим "      "
            {
                q += s;
            }
            return q;
        }
        static void qweqwe(DirectoryInfo dir, int a)
        {
            FileInfo[] files = dir.GetFiles();    // все файлы папки вводим в массив
            DirectoryInfo[] dires = dir.GetDirectories();   // также все папки папки вводим в массив
            foreach(FileInfo file in files)
            {
                //   выводим названия всех содержимых файлов
                Console.Write(Space(a));  // функция для создания некой иерархии
                Console.WriteLine(file.Name);
            }
            foreach(DirectoryInfo dire in dires)
            {
                Console.Write(Space(a));
                Console.WriteLine(dire.Name);   // выводим названия папки, и сразу вызываем эту же функцию
                qweqwe(dire, a+1);              //  уже для данной папки, получается своего рода рекурсия
                    // каждый раз прибавляем значение а, чтобы получилась иерархия
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\user1\Desktop\ict");    // создаем переменную класса DirectoryInfo
            qweqwe(dir, 0);   //  функция для отображения содержимого папки
            Console.ReadKey();   // ЧТОБЫ  КОНСОЛЬ НЕ ЗАКРЫЛАСЬ СРАЗУ
        }
    }
}
