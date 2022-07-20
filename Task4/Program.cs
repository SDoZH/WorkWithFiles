using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
        public static void Main()
        {
            CreateFolder();
            СreateFile();
        }
        public static void СreateFile()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Student[] students =
                 {
             new Student("Евгений", "Группа1", new DateTime(2009, 5, 29)),
             new Student("Паша", "Группа1", new DateTime(2007, 5, 29)),
             new Student("Ваня", "Группа2", new DateTime(2008, 5, 29)),
             new Student("Гриша", "Группа1", new DateTime(2007, 5, 29)),
             new Student("Света", "Группа3", new DateTime(2005, 5, 29)),
             new Student("Вова", "Группа2", new DateTime(2007, 5, 30)),
             };

                // сериализация
                using (var fs = new FileStream("C:/Users/Dzh/Desktop/Students.dat", FileMode.OpenOrCreate))
                {
                    foreach (Student student in students)
                    {
                        formatter.Serialize(fs, students);
                    }
                    Console.WriteLine("Создан фаил Students.dat и записаны студенты ");
                }
              
                // десериализация
                using (var fs = new FileStream("C:/Users/Dzh/Desktop/Students.dat", FileMode.Open))
                {
                    foreach (Student student in students)
                    {
                     formatter.Deserialize(fs);
                    }
                   
                    using StreamWriter sw = new StreamWriter("C:/Users/Dzh/Desktop/Students/Group1.txt");
                    foreach (Student student in students) 
                    { if(student.Group =="Группа1")
                        sw.WriteLine($"Name: {student.Name} DateOfBirth: {student.DateOfBirth} "); 
                    }     
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void CreateFolder()
        {
            try
            {
                DirectoryInfo newDirectory = new DirectoryInfo("C:/Users/Dzh/Desktop/Students");
                if (!newDirectory.Exists)
                    newDirectory.Create();
                Console.WriteLine("Папка создана.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
    public class List
    {

    }
}
