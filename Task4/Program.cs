using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
        public static void Main()
        {
            DeserializeData(); //"C:/Users/Dzh/Desktop/Students.dat"
        }

        public static void DeserializeData()
        {
            string path = "C:/Users/Dzh/Desktop/Students.dat";
            string[] readText = File.ReadAllLines(path);
           
            BinaryFormatter formatter = new BinaryFormatter();
            // десериализация
            using (var fs = new FileStream("Students.dat", FileMode.OpenOrCreate))
            {
                var newStudent = (Student)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newStudent.Name} --- Возраст: {newStudent.Group} --- Дата рождения: {newStudent.DateOfBirth}");
            }
            Console.ReadLine();
        }


        class Student
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


    }
}
