using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Wall : Game
    {
       
        public Wall(char c, ConsoleColor color) : base(0,0,color,c)
        {
            cors = new List<Coordinate>();
        }
        enum Level
        {
            FIRST,
            SECOND,
            THIRD
        }
        Level level = Level.FIRST;
        public void LoadLevel()
        {
            string lvl = @"C:\Users\user1\Desktop\PP2\Week 6\ConsoleApp1\ConsoleApp1\lvl1.txt";
            if(level == Level.SECOND)
            {
                lvl = @"C:\Users\user1\Desktop\PP2\Week 6\ConsoleApp1\ConsoleApp1\lvl2.txt";
            }
            if(level == Level.THIRD)
            {
                lvl = @"C:\Users\user1\Desktop\PP2\Week 6\ConsoleApp1\ConsoleApp1\lvl3.txt";
            }
            StreamReader st = new StreamReader(lvl);
            string[] str = st.ReadToEnd().Split('\n');
            for(int i = 0; i < str.Length; i++)
            {
                for(int j = 0; j < str[i].Length; j++){
                    if (str[i][j] == '#')
                    {
                        cors.Add(new Coordinate(j, i));
                    }
                }
            }
        }
        public void LevelUp()
        {
            if(level == Level.FIRST)
            {
                level = Level.SECOND;
            }
            if(level == Level.SECOND)
            {
                level = Level.THIRD;
            }
        }
    }
}
