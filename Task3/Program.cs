using System;
using System.IO;
using System.IO.Enumeration;

namespace Task3
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
            string pathToDirectory = "C:/Users/Dzh/Desktop/Папка для 8 модуля";
            double catalogSize = 0;
            catalogSize = sizeFolder(pathToDirectory, ref catalogSize);
            if (DelFailDir.Exists)
            {
                if (catalogSize != 0)
                {
                    Console.WriteLine("Исходный размер каталога {0} -- {1} байт ", pathToDirectory, catalogSize);
                }
  
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
        static double sizeFolder(string folder, ref double catalogSize) //метод для подсчета
        {
            try
            {
                DirectoryInfo Fol = new DirectoryInfo(folder);
                DirectoryInfo[] dir = Fol.GetDirectories();
                FileInfo[] fi = Fol.GetFiles();
                foreach (FileInfo f in fi)
                {
                    catalogSize = catalogSize + f.Length; //складываем
                }
                foreach (DirectoryInfo df in dir)
                {
                    sizeFolder(df.FullName, ref catalogSize); // рекурсивно вызываем метод
                }
                return Math.Round((double)(catalogSize), 1);
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Папка не существует. Ошибка: " + ex.Message);
                return 0;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Нет доступа. Ошибка: " + ex.Message);
                return 0;
            }

        }
    }
}


