using System;
using System.Collections.Generic;
using System.Text;

namespace Lab14V4
{
    public class WebRequestInfo
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public DateTime Timestamp { get; set; }

        public WebRequestInfo(string url, string method = "GET")
        {
            Url = url;
            Method = method;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {Method} -> {Url}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("    ЛАБОРАТОРНА РОБОТА №14 | ВАРІАНТ №4");
            Console.WriteLine("    Студент: Гродійчук Максим");
            Console.WriteLine("    Тема: Обробка веб-запитів (HashSet, Queue, Stack)");
            Console.WriteLine("==================================================\n");

            Console.WriteLine("--- 1. ДЕМОНСТРАЦІЯ HASHSET<T> (Унікальні URL) ---");
            HashSet<string> uniqueUrls = new HashSet<string>();

            string[] incomingUrls = {
                "https://example.com/home",
                "https://example.com/about",
                "https://example.com/home",
                "https://example.com/products",
                "https://example.com/about"
            };

            Console.WriteLine("Спроба додавання URLs до HashSet:");
            foreach (var url in incomingUrls)
            {
                bool added = uniqueUrls.Add(url);
                Console.WriteLine($"  Додаємо '{url}': {(added ? "Успішно" : "Проігноровано (Дублікат)")}");
            }

            Console.WriteLine($"\nВсього унікальних сайтів у базі: {uniqueUrls.Count}");
            Console.WriteLine("Перевірка наявності URL 'https://example.com/home': " + 
                              uniqueUrls.Contains("https://example.com/home"));

            Console.WriteLine("\n--- 2. ДЕМОНСТРАЦІЯ QUEUE<T> (Черга запитів - FIFO) ---");
            Queue<WebRequestInfo> requestQueue = new Queue<WebRequestInfo>();

            requestQueue.Enqueue(new WebRequestInfo("https://example.com/home", "GET"));
            requestQueue.Enqueue(new WebRequestInfo("https://example.com/api/login", "POST"));
            requestQueue.Enqueue(new WebRequestInfo("https://example.com/products", "GET"));

            Console.WriteLine($"Запитів у черзі: {requestQueue.Count}");
            Console.WriteLine($"Наступний запит на обробку (Peek): {requestQueue.Peek()}");

            Console.WriteLine("\nОбробка запитів у порядку надходження (FIFO):");
            while (requestQueue.Count > 0)
            {
                WebRequestInfo currentRequest = requestQueue.Dequeue();
                Console.WriteLine($"  [ОБРОБЛЕНО] {currentRequest}");
            }

            Console.WriteLine("\n--- 3. ДЕМОНСТРАЦІЯ STACK<T> (Історія навігації - LIFO) ---");
            Stack<string> browserHistory = new Stack<string>();

            Console.WriteLine("Користувач переходить по сторінках:");
            browserHistory.Push("https://example.com/home");
            Console.WriteLine("  1. Відкрито: https://example.com/home");
            
            browserHistory.Push("https://example.com/products");
            Console.WriteLine("  2. Відкрито: https://example.com/products");
            
            browserHistory.Push("https://example.com/products/item123");
            Console.WriteLine("  3. Відкрито: https://example.com/products/item123");

            Console.WriteLine($"\nПоточна сторінка (Peek): {browserHistory.Peek()}");

            Console.WriteLine("\nКористувач натискає кнопку 'Назад' (Back):");
            while (browserHistory.Count > 1)
            {
                string leftPage = browserHistory.Pop();
                Console.WriteLine($"  Залишили сторінку: {leftPage}");
                Console.WriteLine($"  Поточна сторінка після повернення: {browserHistory.Peek()}");
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("    РОБОТУ ПРОГРАМИ ЗАВЕРШЕНО УСПІШНО");
            Console.WriteLine("==================================================");
        }
    }
}