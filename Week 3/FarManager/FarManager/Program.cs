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
        public void Show(string path)
        {
            dir = new DirectoryInfo(path);
            
            FileSystemInfo[] fsi = dir.GetFileSystemInfos();
            size = fsi.Length;
            
            
           
                for (int i = 0; i < size; i++)
                {
                    Color(fsi[i], i);
                    Console.WriteLine(fsi[i].Name);

                }
            
        }

        public void Start(string path)
        {
            
            
            FileSystemInfo fs = null;
            while (1==1)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    
                    if (cursor ==0)
                    {
                        cursor = size - 1;
                        
                    }
                    else
                    {
                        
                        cursor--;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    
                  
                    if (cursor == size - 1)
                    {
                        cursor = 0;
                       
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
                        FileStream fss = new FileStream(fs.FullName, FileMode.Open, FileAccess.Read);
                        StreamReader str = new StreamReader(fss);
                        string s = "";
                        while (!str.EndOfStream)
                        {
                            s += str.ReadLine();
                        }

                        Console.Clear();
                        Console.WriteLine(s);
                        Console.ReadKey();
                        Console.Clear();
                        fss.Close();
                        str.Close();
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
                    Console.Clear();
                    Console.WriteLine("Enter the new name: ");
                    string newname = Console.ReadLine();
                    string pathh = new DirectoryInfo(fs.FullName).Parent.FullName;
                    if (fs.GetType() == typeof(FileInfo))
                    {
                        File.Move(fs.FullName, pathh + "/" + newname);
                    }
                    else
                        Directory.Move(fs.FullName, pathh + "/" + newname);
                        
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
