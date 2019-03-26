using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Snake:Game
    {
        enum Direction
        {
            NONE,
            RIGHT,
            LEFT,
            UP,
            DOWN
        }
       // public List<Coordinate> cors;
        public Snake(int x,int y,char c, ConsoleColor color) : base(x,y,color,c)
        {
           // Coordinate cor = new Coordinate(x,y);
          //  cors.Add(cor);
        }
        
        Direction dir = Direction.NONE;
        public void Move()
        {
            

            if(dir == Direction.NONE)
            {
                return;
            }
                for (int i = cors.Count - 1; i > 0; i--)
                {
                    cors[i].x = cors[i - 1].x;
                    cors[i].y = cors[i - 1].y;
                }
                if (dir == Direction.UP)
                {
                    cors[0].y--;
                }
                if (dir == Direction.DOWN)
                {
                        cors[0].y++;
                }
                if (dir == Direction.RIGHT)
                {
                    
                        cors[0].x++;
                    
                }
                if (dir == Direction.LEFT)
                {
                       cors[0].x--;
                    
                }
        }
        public void Direct(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W)
            {
                if (dir != Direction.DOWN)
                {
                    dir = Direction.UP;
                }
            }
            if (key.Key == ConsoleKey.S)
            {
                if (dir != Direction.UP)
                {
                    dir = Direction.DOWN;
                }
            }
            if (key.Key == ConsoleKey.D)
            {
                if (dir != Direction.LEFT)
                {
                    dir = Direction.RIGHT;
                }
            }
            if (key.Key == ConsoleKey.A)
            {
                if (dir != Direction.RIGHT)
                {
                    dir = Direction.LEFT;
                }
            }
        }
        public bool IsSuicide(Snake snake)
        {
            for(int i = 1; i < snake.cors.Count; i++)
            {
                if(snake.cors[0].x==snake.cors[i].x && snake.cors[0].y == snake.cors[i].y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
