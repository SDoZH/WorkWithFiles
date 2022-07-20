using System;
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
            FileStream();
        }
        public static void СreateFile()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var student = new Student("Евгений", "Группа1", new DateTime(2007, 5, 29));
                // сериализация
                using (var fs = new FileStream("C:/Users/Dzh/Desktop/Students.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, student);
                }
                // десериализация
                using (var fs = new FileStream("C:/Users/Dzh/Desktop/Students.dat", FileMode.OpenOrCreate))
                {
                    var newStudent = (Student)formatter.Deserialize(fs);
                    using StreamWriter sw = new StreamWriter("C:/Users/Dzh/Desktop/Students/Group1.txt");
                    sw.WriteLine($"Имя: {newStudent.Name} --- Group: {student.Group} -- Birthday - {newStudent.DateOfBirth}");
                    Console.WriteLine($"Имя: {newStudent.Name} --- Group: {newStudent.Group} -- Birthday - {newStudent.DateOfBirth}");
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
        public static void FileStream()
        {

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


