using System;
using System.Collections.Generic;

namespace Lab8Polymorphism
{
    public class Device
    {
        public string Brand { get; set; }

        public Device(string brand)
        {
            Brand = brand;
        }

        public virtual string PerformAction()
        {
            return $"{Brand}: пристрій виконує базову дію.";
        }
    }

    public class Printer : Device
    {
        public int PagesPerMinute { get; set; }

        public Printer(string brand, int pagesPerMinute) : base(brand)
        {
            PagesPerMinute = pagesPerMinute;
        }

        public override string PerformAction()
        {
            return $"Принтер {Brand} друкує сторінки зі швидкістю {PagesPerMinute} стор/хв.";
        }
    }

    public class Scanner : Device
    {
        public int DPI { get; set; }

        public Scanner(string brand, int dpi) : base(brand)
        {
            DPI = dpi;
        }

        public override string PerformAction()
        {
            return $"Сканер {Brand} сканує документ із роздільною здатністю {DPI} DPI.";
        }
    }

    public class Monitor : Device
    {
        public double ScreenSize { get; set; }

        public Monitor(string brand, double screenSize) : base(brand)
        {
            ScreenSize = screenSize;
        }

        public override string PerformAction()
        {
            return $"Монітор {Brand} (діагональ {ScreenSize}\") відображає зображення.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Device> devices = new List<Device>
            {
                new Printer("HP", 30),
                new Scanner("Epson", 1200),
                new Monitor("Dell", 27.0),
                new Printer("Canon", 20),
                new Monitor("ASUS", 32.0)
            };

            List<string> performedActions = new List<string>();

            Console.WriteLine("=== Перебір пристроїв та поліморфний виклик методів ===\n");

            foreach (var device in devices)
            {
                string actionResult = device.PerformAction();
                performedActions.Add(actionResult);

                Console.WriteLine($"Пристрій: {device.GetType().Name} | Бренд: {device.Brand}");
                Console.WriteLine($"  -> Дія: {actionResult}");
                Console.WriteLine(new string('-', 60));
            }

            Console.WriteLine("\n=== Агрегація: Список усіх дій, виконаних пристроями ===");
            Console.WriteLine($"Усього виконано дій: {performedActions.Count}\n");

            for (int i = 0; i < performedActions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {performedActions[i]}");
            }
        }
    }
}