using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Records
    {
        public string name;
        public int score;
        public Records()
        {
            
        }
        public override string ToString()
        {
            return name + " " + score;
        }
    }
}
