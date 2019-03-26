using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace ConsoleApp1
{
    class Logic
    {
        List<Game> games;
        public bool IsAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public int point;
        public int score;
        public Logic()
        {
            
        }
        public void Start()
        {
            games = new List<Game>();
            snake = new Snake(13, 14, '$', ConsoleColor.Green);
            food = new Food(0, 0, ConsoleColor.Magenta, 'o');
            wall = new Wall('#', ConsoleColor.Yellow);
            wall.LoadLevel();
            
            while (food.Collision(snake) || food.Collision(wall))
            {
                food.Create();
            }
            games.Add(snake);
            games.Add(food);
            games.Add(wall);
            IsAlive = true;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            score = 0;
            point = 50;
            Thread thread = new Thread(MoveSnake);
            thread.Start(key);
            while(IsAlive && key.Key != ConsoleKey.Escape)
            {
                snake.Direct(key);
                
                //wall.Draw();
                if(IsAlive==false)
                {
                    GameOver(score);
                    break;
                    
                }
                
                key = Console.ReadKey();
                if(key.Key == ConsoleKey.Escape)
                {
                    //thread.Abort();
                    return;
                    
                }
            }
            
            
        }
        public void MoveSnake(object data)
        {
           // wall.Draw();
            while (IsAlive)
            {

                ConsoleKeyInfo key = (ConsoleKeyInfo)data;
                if(key.Key == ConsoleKey.Escape)
                {
                    return;
                }
                snake.Move();
                if (snake.Collision(food))
                {
                    snake.cors.Add(new Coordinate(0, 0));
                    score = score + point;
                    while (food.Collision(snake) || food.Collision(wall))
                    {
                        food.Create();
                    }
                    if (snake.cors.Count % 5 == 0)
                    {
                        wall.LevelUp();
                        point += point;
                    }

                }
                if (snake.Collision(wall))
                {
                    IsAlive = false;

                }
                if (snake.IsSuicide(snake))
                {
                    IsAlive = false;
                }
                Draw();
                Console.SetCursorPosition(1,26);
                Console.Write("Score:    " + score);
                Thread.Sleep(60);
               
            }
           GameOver(score);
        }
        public void Draw()
        {
            Console.Clear();
            foreach(Game game in games)
            {
                game.Draw();
                
            }
        }
        public void GameOver(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine(" GAME  OVER!!!");
            Console.SetCursorPosition(20, 11);
            Console.Write("Your score is " + score);
            Console.SetCursorPosition(15, 15);
            
            Console.WriteLine("Press Enter to Restart game");
            Console.SetCursorPosition(15, 16);
            Console.WriteLine("OR Press Spacebar to save your record");
            Console.SetCursorPosition(15, 17);
            Console.WriteLine("OR Press any other key to exit");
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                IsAlive = true;

                Start();
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                Save(score);
                return;

            }
            else return;
        }
        public void Save(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(15, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter Your name:");
            Console.SetCursorPosition(15, 12);
            string name = Console.ReadLine();
            Records record = new Records();
            record.name = name;
            record.score = score;
            FileStream str = new FileStream("records.xml", FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(Records));
            xml.Serialize(str, record);
            str.Close();
        }
    }
}
