using System;
using System.IO;
using System.IO.Enumeration;

namespace Task2
{

    class Program
    {
        static void Main(string[] args)
        {
            string pathToDirectory = "C:/Users/Dzh/Desktop/Папка для 8 модуля";
            double catalogSize = 0;
            catalogSize = sizeFolder(pathToDirectory, ref catalogSize); 
            if (catalogSize != 0)
            {
                Console.WriteLine("Размер {0} \nсоставляет {1} байт ", pathToDirectory, catalogSize);
            }
            else
            {
                Console.WriteLine("Каталог {0} пуст.", pathToDirectory);
            }
            Console.ReadLine();
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
                return Math.Round((double) (catalogSize), 1);
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
