using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string q = @"C:\Users\user1\Desktop\PP2\Week 2\Task4\Task4\text1.txt";    //  Пути для создания 
            string w = @"C:\Users\user1\Desktop\PP2\Week 2\Task4\Task4\text2.txt";    //     файлов
            string asd = "KBTU is the best!!!";
            StreamWriter dd = new StreamWriter(q);
            dd.Write(asd);
            dd.Close();
            File.Copy(q, w);   //  Копируем  в новый файл
            File.Delete(q);   //  Удаляем первый файл
        }
    }
}
