using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FarManager
{
    class FarManager
    {
        public int cursor;
        DirectoryInfo dir;
        public int size;
        public FarManager()
        { 
            cursor = 0;
            
        }
        public void Color(FileSystemInfo fs,int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Red;
            } else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
            } else if (fs.GetType() == typeof(FileInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            
        }
        public void Show(string path,int kk)
        {
            dir = new DirectoryInfo(path);
            
            FileSystemInfo[] fsi = dir.GetFileSystemInfos();
            size = fsi.Length;
            
            
           
                for (int i = 0; i < 10; i++)
                {
                    Color(fsi[i+kk], i+kk);
                    Console.WriteLine(fsi[i+kk].Name);

                }
            
        }

        public void Start(string path)
        {
            int kk = 0;
            
            FileSystemInfo fs = null;
            while (1==1)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path,kk);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    
                    if (cursor < 0)
                    {
                        cursor = size - 1;
                        kk ++;
                    }
                    else
                    {
                        kk ++;
                        cursor--;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    
                    if(cursor > 8)
                    {
                        kk++;
                    }
                    if (cursor == size - 1)
                    {
                        cursor = 0;
                        kk = 0;
                    }
                    else
                    {
                        cursor++;

                    }
                }
                if (key.Key == ConsoleKey.O)
                {
                    for(int i = 0; i < dir.GetFileSystemInfos().Length; i++)
                    {
                        if (cursor == i)
                        {
                            fs = dir.GetFileSystemInfos()[i];
                            break;
                        }
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        dir = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    } else if(fs.GetType() == typeof(FileInfo))
                    {
                        StreamReader str = new StreamReader(fs.FullName);
                        string s = "";
                        while (!str.EndOfStream)
                        {
                            s += str.ReadLine();
                        }
                        
                    }
                }
                if(key.Key== ConsoleKey.D)
                {
                    for (int i = 0; i < dir.GetFileSystemInfos().Length; i++)
                    {
                        if (cursor == i)
                        {
                            fs = dir.GetFileSystemInfos()[i];
                            break;
                        }
                    }
                    fs.Delete();
                }
                if(key.Key == ConsoleKey.R)
                {
                    for(int i = 0; i < dir.GetFileSystemInfos().Length; i++)
                    {
                        if (i == cursor)
                        {
                            fs = dir.GetFileSystemInfos()[i];
                            break;
                        }
                    }
                    string newname = Console.ReadLine();
                    if (fs.GetType() == typeof(FileInfo))
                    {

                        File.Move(fs.Name, newname);
                    }
                }
                if(key.Key == ConsoleKey.I)
                {
                    cursor = 0;
                    dir = dir.Parent;
                    path = dir.FullName;
                }
                if (key.Key == ConsoleKey.E)
                {
                    return;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FarManager fr = new FarManager();
            string path = @"C:\Users\user1\Desktop\ict";
            fr.Start(path);
            
        }
    }
}
