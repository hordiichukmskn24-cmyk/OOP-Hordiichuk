using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace lab17v4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Func<Exception, bool> shouldRetryPolicy = ex =>
                ex is FileNotFoundException || ex is HttpRequestException;

            Console.WriteLine("=== Сценарій 1: FileProcessor.ReadImage ===");
            var fileProcessor = new FileProcessor();
            try
            {
                byte[] localImage = RetryHelper.ExecuteWithRetry(
                    operation: () => fileProcessor.ReadImage("assets/avatar.png"),
                    retryCount: 4,
                    initialDelay: TimeSpan.FromMilliseconds(200),
                    shouldRetry: shouldRetryPolicy
                );
                Console.WriteLine($"Результат: Зображення прочитано з диска ({localImage.Length} байт).\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Фінальний збій: {ex.Message}\n");
            }

            Console.WriteLine("=== Сценарій 2: NetworkClient.DownloadImage ===");
            var networkClient = new NetworkClient();
            try
            {
                byte[] remoteImage = RetryHelper.ExecuteWithRetry(
                    operation: () => networkClient.DownloadImage("https://cdn.example.com/banner.jpg"),
                    retryCount: 3,
                    initialDelay: TimeSpan.FromMilliseconds(300),
                    shouldRetry: shouldRetryPolicy
                );
                Console.WriteLine($"Результат: Зображення завантажено з мережі ({remoteImage.Length} байт).\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Фінальний збій: {ex.Message}\n");
            }

            Console.WriteLine("=== Сценарій 3: Перевірка shouldRetry (ArgumentException) ===");
            try
            {
                RetryHelper.ExecuteWithRetry(
                    operation: () => fileProcessor.ReadImage(""),
                    retryCount: 3,
                    initialDelay: TimeSpan.FromMilliseconds(200),
                    shouldRetry: shouldRetryPolicy
                );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Очікуване негайне переривання без повторних спроб: {ex.Message}");
            }
        }
    }
}
