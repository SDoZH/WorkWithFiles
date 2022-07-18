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
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории в папке
                    foreach (string d in dirs) // Выведем их все
                        Console.WriteLine("{0}", d);

                    Console.WriteLine("Файлы:");

                    string[] files = Directory.GetFiles(dirName);// Получим все файлы в папке
                    foreach (string s in files)   // Выведем их все
                        Console.WriteLine(s);

                    foreach (FileInfo file in DelFailDir.GetFiles())
                    {
                        var timeSpan = file.LastAccessTime;
                        var timeSpan1 = DateTime.Now;
                        var timeSpan2 = TimeSpan.FromMinutes(30);
                        var duras = timeSpan1 - timeSpan;
                        if (duras >= timeSpan2)
                        { file.Delete(); }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Нет файлов,которые не используются более 30 мин.");
                            Console.WriteLine($"Прошло {duras} времени");
                            break;
                        }
                    }

                    foreach (DirectoryInfo dir in DelFailDir.GetDirectories())
                    {
                        var timeSpan = dir.LastAccessTime;
                        var timeSpan1 = DateTime.Now;
                        var timeSpan2 = TimeSpan.FromMinutes(30);
                        var duras = timeSpan1 - timeSpan;
                        if (duras >= timeSpan2)
                        {
                            dir.Delete(true);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Нет папок,которыене используются более 30 мин");
                            Console.WriteLine($"Прошло {duras} времени");
                            break;
                        }
                    }

                }

            }
        }
    }



