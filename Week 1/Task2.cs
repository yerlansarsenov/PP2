using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        class Student  // Создаем класс с именем "Student"
        {
            private string name;  //  имя студента
            private string id;  //  ID студента
            private int yearofstudy;  //  год обучения студента
            public Student(string name, string id)  //  Создаем конструктор с двумя параметрами
            {
                this.name = name;   //  вводится имя     this пишется чтобы компилятор не перепутал переменные
                this.id = id;  //  вводится id         
            }
            public void Increment()  //  Метод для инкрементирования года обучения обьекта Студента
            {
                yearofstudy++;
            }
            public int YearofStudy  // Это делается для  доступа в приватному свойству yearofstudy
            {
                get
                {
                    return yearofstudy;
                }
                set
                {
                    yearofstudy = value;
                }
            }
        }
        static void Main(string[] args)
        {
            Student s = new Student("Yerlan", "18BD110739");  //  создаем обьект класса Студент
            s.YearofStudy = 1;  //  по умолчанию значение равно 1
            s.Increment();  //  после мметода значение инкрементируется (+1), то есть равно 2
            Console.WriteLine(s.YearofStudy);  //  Показываю, что метод Increment работает (Вывод: 2)

        }
    }
}
