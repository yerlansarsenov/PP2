using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Mark
    {
        public string letter;
        public int point;
        public Mark()
        {

        }
        public void GetLetter()
        {
            if(point>=96 && point <= 100)
            {
                letter = "A";
            }
            if (point >= 90 && point <= 95)
            {
                letter = "A-";
            }
            if (point >= 86 && point <= 89)
            {
                letter = "B+";
            }
            if (point >= 80 && point <= 85)
            {
                letter = "B";
            }
            if (point >= 76 && point <= 79)
            {
                letter = "B-";
            }
            if (point >= 70 && point <= 75)
            {
                letter = "C+";
            }
            if (point >= 66 && point <= 69)
            {
                letter = "C";
            }
            if (point >= 60 && point <= 65)
            {
                letter = "C-";
            }
            if (point >= 56 && point <= 59)
            {
                letter = "D+";
            }
            if (point >= 50 && point <= 55)
            {
                letter = "D-";
            }
            if (point>=0 && point <= 50)
            {
                letter = "F";
            }

        }
        public override string ToString()
        {
            return point + " " + letter;
        }
    }
}
