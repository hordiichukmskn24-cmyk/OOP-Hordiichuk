using System;
using System.Collections.Generic;

namespace Lab6v4
{
    public class Animal
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"[Animal] {Name} видає невизначений звук.");
        }

        public string GetSpecies()
        {
            return "Невідомий біологічний вид (General Animal)";
        }
    }

    public class Dog : Animal
    {
        public string Breed { get; set; }

        public Dog(string name, int age, string breed) 
            : base(name, age)
        {
            Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"[Dog] Собака {Name} ({Breed}) гавкає: Гав-гав!");
        }

        public void Fetch()
        {
            Console.WriteLine($"Собака {Name} радісно біжить і приносить м'ячик!");
        }

        public new string GetSpecies()
        {
            return "Собака свійський (Canis lupus familiaris)";
        }
    }

    public class Cat : Animal
    {
        public bool IsIndoor { get; set; }

        public Cat(string name, int age, bool isIndoor) 
            : base(name, age)
        {
            IsIndoor = isIndoor;
        }

        public override void MakeSound()
        {
            string location = IsIndoor ? "домашній" : "вуличний";
            Console.WriteLine($"[Cat] Кiт {Name} ({location}) нявкає: Мяу-мяу!");
        }

        public void Purr()
        {
            Console.WriteLine($"Кiт {Name} солодко муркоче: Мурр-мурр...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== 1. СТВОРЕННЯ ОБ'ЄКТІВ ТА УНІКАЛЬНІ МЕТОДИ ===");
            Animal genericAnimal = new Animal("Незрозуміле створіння", 5);
            Dog dog = new Dog("Рекс", 3, "Німецька вівчарка");
            Cat cat = new Cat("Мурчик", 2, true);

            genericAnimal.MakeSound();
            dog.MakeSound();
            dog.Fetch();
            cat.MakeSound();
            cat.Purr();

            Console.WriteLine("\n=== 2. ДЕМОНСТРАЦІЯ ПОЛІМОРФІЗМУ (override) ===");
            List<Animal> animals = new List<Animal> { genericAnimal, dog, cat };

            foreach (var animal in animals)
            {
                animal.MakeSound();
            }

            Console.WriteLine("\n=== 3. ДЕМОНСТРАЦІЯ РІЗНИЦІ МІЖ override ТА new ===");
            Dog dogObj = new Dog("Барон", 4, "Лабрадор");
            Animal animalRef = dogObj;

            Console.WriteLine("--- Виклик MakeSound() (override) ---");
            Console.Write("Через посилання Dog:    ");
            dogObj.MakeSound();
            Console.Write("Через посилання Animal: ");
            animalRef.MakeSound();

            Console.WriteLine("\n--- Виклик GetSpecies() (new) ---");
            Console.WriteLine($"Через посилання Dog:    {dogObj.GetSpecies()}");
            Console.WriteLine($"Через посилання Animal: {animalRef.GetSpecies()}");
        }
    }
}