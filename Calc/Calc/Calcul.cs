using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Calcul
    {
        public double first;
        public double second;
        public double result;
        public double memory;
        public string operation;
        public void calculate(bool radian)
        {
            switch (operation)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                case "lg":
                    result = System.Math.Log10(first);
                    break;
                case "M+":
                    memory += first;
                    result = memory;
                    break;
                case "M-":
                    memory -= first;
                    result = memory;
                    break;
                case "sin":
                    if (radian)
                    {
                        result = System.Math.Sin(first);
                    }
                    else
                    {
                        double q = (first * System.Math.PI) / 180;
                        result = System.Math.Sin(q);
                    }
                    break;
                case "cos":
                    if (radian)
                    {
                        result = System.Math.Cos(first);
                    }
                    else
                    {
                        double q = (first * System.Math.PI) / 180;
                        result = System.Math.Cos(q);
                    }
                    break;
                case "X^Y":
                    result = System.Math.Pow(first, second);
                    break;
            }
        }
        public Calcul()
        {

        }
    }
}
