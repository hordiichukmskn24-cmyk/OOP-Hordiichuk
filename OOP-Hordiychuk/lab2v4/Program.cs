using System;

namespace lab2v4
{
    public class Teacher
    {
        private string _name;
        private string _subject;
        private int _experienceYears;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Subject
        {
            get => _subject;
            set => _subject = value;
        }

        public int ExperienceYears
        {
            get => _experienceYears;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Досвід роботи не може бути від'ємним!");
                }
                _experienceYears = value;
            }
        }

        public Teacher() : this("New Teacher", "General", 3)
        {
        }

        public Teacher(string name, string subject, int experienceYears)
        {
            Name = name;
            Subject = subject;
            ExperienceYears = experienceYears;
        }

        public void Introduce()
        {
            Console.WriteLine($"Викладач: {Name}, Дисципліна: {Subject}, Досвід: {ExperienceYears} років.");
        }

        ~Teacher()
        {
            Console.WriteLine($"[Деструктор] Об'єкт {Name} знищено збирачем сміття.");
        }
    }

    internal class Program
    {
        static void Main()
        {
            CreateAndUseTeachers();

            Console.WriteLine("\n=== Запуск збирача сміття ===");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("=== Роботу завершено ===");
        }

        static void CreateAndUseTeachers()
        {
            Console.WriteLine("=== Створення об'єктів ===");
            Teacher teacher1 = new Teacher();
            Teacher teacher2 = new Teacher("Олена Петрівна", "Математика", 5);
            Teacher teacher3 = new Teacher("Іван Васильович", "Фізика", 15);

            teacher1.Introduce();
            teacher2.Introduce();
            teacher3.Introduce();

            Console.WriteLine("\n=== Перевірка валідації ===");
            try
            {
                teacher2.ExperienceYears = 5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}