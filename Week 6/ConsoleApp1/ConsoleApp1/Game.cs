using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
       // Coordinate cor;
        public ConsoleColor color;
        public char c;
        public List<Coordinate> cors;
        public Game(int x, int y, ConsoleColor color, char c)
        {
            //cor.x = x;
            //cor.y = y;
            this.color = color;
            this.c = c;
            cors = new List<Coordinate> { 
            
                new Coordinate(x, y)
            };
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(Coordinate cor in cors)
            {
                Console.SetCursorPosition(cor.x, cor.y);
                Console.Write(c);
            }
        }

        public bool Collision(Game game)
        {
            foreach(Coordinate cor in game.cors)
            {
                if(cors[0].x == cor.x && cors[0].y == cor.y)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
