using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Food:Game
    {
        Coordinate cor;
        public Food(int x,int y,ConsoleColor color,char c):base(x,y,color,c)
        {
            cor = new Coordinate(x, y);
        }
        public void Create()
        {
            
            Random r = new Random();
            cor.x = r.Next(0, 67);
            cor.y = r.Next(0, 25);
            cors[0].x = cor.x;
            cors[0].y = cor.y;
        }
    }
}
