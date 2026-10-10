using System;

namespace Lab1
{
    public class Teacher
    {
        private string _name;
        private string _subject;
        private int _experience;

        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value) ? value : "Невідомо";
        }

        public string Subject
        {
            get => _subject;
            set => _subject = !string.IsNullOrWhiteSpace(value) ? value : "Невідомо";
        }

        public int Experience
        {
            get => _experience;
            set => _experience = value >= 0 ? value : 0;
        }

        public Teacher(string name, string subject, int experience)
        {
            Name = name;
            Subject = subject;
            Experience = experience;
        }

        public void Introduce()
        {
            Console.WriteLine($"Вітання! Мене звати {Name}. Я викладаю предмет \"{Subject}\". Мій стаж роботи: {Experience} років.");
        }

        ~Teacher()
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Teacher teacher1 = new Teacher("Олександр Іванович", "Об'єктно-орієнтоване програмування", 12);
            Teacher teacher2 = new Teacher("Марія Петрівна", "Вища математика", 5);
            Teacher teacher3 = new Teacher("Василь Степанович", "Комп'ютерні мережі", 20);

            teacher1.Introduce();
            teacher2.Introduce();
            teacher3.Introduce();
        }
    }
}