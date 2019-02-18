using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        class Snake
        {
            private int xx;
            private int yy;
            private int[] xtail = new int[1000];
            private int[] ytail = new int[1000];
            static Random rand = new Random();
            private int xxx = rand.Next(1,15);
            private int yyy = rand.Next(1,15);
            public enum eDirection { Stop=0, Up, Down, Left, Right}
            private bool quit;
            private int score = 0;
            string mouse = "@";
            string tail = "s";
            string snake = null;
            
            public void Scene(eDirection dir,ConsoleKey key)
            {
                LogicOfGame(dir);
                Console.Clear();
                for (int i = 0; i < 51; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("#");
                }
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine();
                    for(int j = 0; j < 50; j++)
                    {
                        if(j==0 || j == 49)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("#");
                        }
                        if (j == xx && i == yy)
                        {
                            for(int k = 0; k < score; k++)
                            {
                                if(xx==xtail[k] && yy == ytail[k])
                                {
                                    GameOver(key);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(snake);

                        }
                        else if (j == xxx && i == yyy)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(mouse);
                        }
                        else
                        {
                            bool space = false;
                            for(int k = 0; k < score; k++)
                            {
                                if(xtail[k] == j && ytail[k] == i)
                                {
                                    space = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(tail);
                                }
                            }
                            if(!space)
                                Console.Write(" ");
                        }
                    }
                   
                }
                Console.WriteLine();
                for (int i = 0; i < 51; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("#");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Score:   " + score);
            }



       


            public void LogicOfGame(eDirection dir)
            {
                int prevX = xtail[0];
                int prevY = ytail[0];
                int prevXX;
                int prevYY;
                xtail[0] = xx;
                ytail[0] = yy;
                for(int i = 1; i < score; i++)
                {
                    prevXX = xtail[i];
                    prevYY = ytail[i];
                    xtail[i] = prevX;
                    ytail[i] = prevY;
                    prevX = prevXX;
                    prevY = prevYY;
                }
                switch (dir)
                {
                    case eDirection.Up:
                        yy--;
                        break;
                    case eDirection.Down:
                        yy++;
                        break;
                    case eDirection.Left:
                        xx--;
                        break;
                    case eDirection.Right:
                        xx++;
                        break;

                }
            }
                
            public void GameOver(ConsoleKey key)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Game Over MotherFucker");
                Console.WriteLine("Your Fuckin' score is " + score);
                Console.WriteLine("Press any MotherFuckin' button to exit");
                Console.WriteLine("OR press Enter to start again this Fuckin' game");
                key = Console.ReadKey().Key;
                score = 0;
                if (key == ConsoleKey.Enter)
                {
                    Start();
                }
                else quit = true;
            }
            
            public void Start()
            {
                ConsoleKey key = Console.ReadKey().Key;
                snake = "$";
                xx = 25;
                eDirection dir = eDirection.Stop;
                yy = 15;
                quit = false;
                Scene(dir,key);
                
                while (true)
                {
                    
                    if(key == ConsoleKey.W)
                    {
                        if (yy == 0)
                        {
                            GameOver(key);
                            if (quit)
                            {
                                break;
                            }
                        }

                        dir = eDirection.Up;
                        Scene(dir,key);
                    }
                    if (key == ConsoleKey.S)
                    {
                        if (yy == 29)
                        {
                            GameOver(key);
                            if (quit)
                            {
                                break;
                            }
                        }
                        dir = eDirection.Down;
                        Scene(dir,key);
                    }
                    if (key == ConsoleKey.D)
                    {
                        if (xx == 48)
                        {
                            GameOver(key);
                            if (quit)
                            {
                                break;
                            }
                        }
                        dir = eDirection.Right;
                        Scene(dir,key);
                    }
                    if (key == ConsoleKey.A)
                    {
                        if(xx == 0)
                        {
                            GameOver(key);
                            if (quit)
                            {
                                break;
                            }
                        }
                        dir = eDirection.Left;
                        Scene(dir,key);
                    }
                    if(xx==xxx && yy == yyy)
                    {
                        score++;
                        xxx = rand.Next(1, 49);
                        yyy = rand.Next(1, 29);
                        
                    }
                    if (Console.KeyAvailable) key = Console.ReadKey().Key;
                        System.Threading.Thread.Sleep(100);
                    
                }
            }
            public Snake()
                {
                    
                }
        }
        static void Main(string[] args)
        {
            Snake game = new Snake();
            game.Start();
            
        }
    }
}
