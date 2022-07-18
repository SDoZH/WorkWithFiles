using System;
using System.IO;
using System.IO.Enumeration;

namespace Task1
{
    class Program
    {
        public static void Main()
        {
            DelCatalogs30();
        }
        static void DelCatalogs30()
        {
            var DelFailDir = new DirectoryInfo("C:/Users/Dzh/Desktop/Папка для 8 модуля");
            string dirName = "C:/Users/Dzh/Desktop/Папка для 8 модуля";
            if (DelFailDir.Exists)
            {
                Console.WriteLine("Папка существует");
                Console.WriteLine("Папки:");
                DateTime OpenDateDir = Directory.GetLastAccessTime(dirName); //Получим время открытия папок
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории в папке
                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine("{0} последнее использование {1}", d, OpenDateDir);

                Console.WriteLine("Файлы:");

                string[] files = Directory.GetFiles(dirName);// Получим все файлы в папке
                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);

                foreach (FileInfo file in DelFailDir.GetFiles())
                {
                    try
                    {
                        var timeSpan = file.LastAccessTime;
                        Console.WriteLine(timeSpan.ToString());
                        timeSpan.Add(TimeSpan.FromMinutes(30));
                        file.Delete();
                    }
                    catch
                    {
                        Console.WriteLine("Нет подходящих для удаления файлов ");
                    }
                }
                foreach (DirectoryInfo dir in DelFailDir.GetDirectories())
                {
                    var timeSpan = dir.LastAccessTime;
                    Console.WriteLine(timeSpan.ToString());
                    var timeSpan1 = DateTime.Now;
                    var timeSpan2 = TimeSpan.FromMinutes(30);
                    var duras = timeSpan1 - timeSpan;
                    dir.Delete(true);

                }
            }
        }
    }
}

