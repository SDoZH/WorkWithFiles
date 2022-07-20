﻿using System;
using System.IO;
using System.Collections.Generic;
namespace Task4

{
    class Program
    {
        public static void Main()
        {
            СreateFile();
            ReadFile();
        }
        public static void СreateFile()
        {
            string path = "C:/Users/Dzh/Desktop/Students.dat";
            ///записываем данные по студентам в файл
            Student[] students =
             {
             new Student("Коля", "1","30.03.1990"),
             new Student("Гриша", "2","22.03.1990"),
             new Student("Оля", "3","19.03.1990"),
             new Student("Галя", "1","14.03.1990"),
             new Student("Вадим", "2","18.03.1990"),
             new Student("Петя", "3","10.03.1990"),
             };
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                // записываем в файл значение каждого свойства объекта
                foreach (Student student in students)
                {
                    writer.Write(student.Name);
                    writer.Write(student.Group);
                    writer.Write(student.DateOfBirth);
                }
                Console.WriteLine("Файл был создан");
            }
        }
        public static void ReadFile()
        {
            List<Student> students = new List<Student>();

            ///читаем из файла все значения
            using (BinaryReader reader = new BinaryReader(File.Open("C:/Users/Dzh/Desktop/Students.dat", FileMode.Open)))
            {

                while (reader.PeekChar() > -1)
                {
                    string name = reader.ReadString();
                    string group = reader.ReadString();
                    string dateOfBirth = reader.ReadString();

                    students.Add(new Student(name, group, dateOfBirth));
                }
            }
            // выводим содержимое списка people на консоль
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}  Group: {student.Group} DateOfBirth: {student.DateOfBirth} ");
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string DateOfBirth { get; set; }
        public Student(string name, string group, string dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
}

