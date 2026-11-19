using System;
using System.Collections.Generic;
using System.Linq;

namespace lab16v4
{
    // ==========================================
    // 1. Класи сутностей (Варіант 4)
    // ==========================================
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    // ==========================================
    // 2. Custom Extension Method (Метод розширення)
    // ==========================================
    public static class CompanyExtensions
    {
        // Обчислює загальну кількість співробітників у колекції компаній
        public static int TotalEmployees(this IEnumerable<Company> companies)
        {
            return companies.Sum(c => c.Employees.Count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Лабораторна робота №16 | Варіант 4 | Виконав: Гордійчук\n");

            // ==========================================
            // Тестові дані (5 компаній, 11 співробітників, 14 проєктів)
            // ==========================================
            var companies = new List<Company>
            {
                new Company
                {
                    Id = 1, Name = "SoftServe", Employees = new List<Employee>
                    {
                        new Employee { Id = 1, Name = "Олександр Коваль", Projects = new List<Project>
                        {
                            new Project { Id = 101, Title = "FinTech Mobile App" },
                            new Project { Id = 102, Title = "Cloud Migration" }
                        }},
                        new Employee { Id = 2, Name = "Марія Шевченко", Projects = new List<Project>
                        {
                            new Project { Id = 103, Title = "AI Chatbot Platform" }
                        }},
                        new Employee { Id = 3, Name = "Дмитро Бондар", Projects = new List<Project>
                        {
                            new Project { Id = 104, Title = "E-Commerce Backend" }
                        }}
                    }
                },
                new Company
                {
                    Id = 2, Name = "EPAM Systems", Employees = new List<Employee>
                    {
                        new Employee { Id = 4, Name = "Ірина Мельник", Projects = new List<Project>
                        {
                            new Project { Id = 105, Title = "Healthcare CRM" },
                            new Project { Id = 106, Title = "Data Analytics Dashboard" }
                        }},
                        new Employee { Id = 5, Name = "Андрій Ткаченко", Projects = new List<Project>
                        {
                            new Project { Id = 107, Title = "Logistics Tracker" }
                        }}
                    }
                },
                new Company
                {
                    Id = 3, Name = "GlobalLogic", Employees = new List<Employee>
                    {
                        new Employee { Id = 6, Name = "Олена Савченко", Projects = new List<Project>
                        {
                            new Project { Id = 108, Title = "Automotive Infotainment" }
                        }},
                        new Employee { Id = 7, Name = "Віктор Мороз", Projects = new List<Project>
                        {
                            new Project { Id = 109, Title = "Smart Home IoT" },
                            new Project { Id = 110, Title = "Security Audit Tool" }
                        }}
                    }
                },
                new Company
                {
                    Id = 4, Name = "Luxoft", Employees = new List<Employee>
                    {
                        new Employee { Id = 8, Name = "Наталія Лисенко", Projects = new List<Project>
                        {
                            new Project { Id = 111, Title = "Banking Core System" }
                        }},
                        new Employee { Id = 9, Name = "Сергій Кравченко", Projects = new List<Project>
                        {
                            new Project { Id = 112, Title = "Payment Gateway" }
                        }}
                    }
                },
                new Company
                {
                    Id = 5, Name = "Ajax Systems", Employees = new List<Employee>
                    {
                        new Employee { Id = 10, Name = "Тарас Поліщук", Projects = new List<Project>
                        {
                            new Project { Id = 113, Title = "Hub OS Firmware" }
                        }},
                        new Employee { Id = 11, Name = "Юлія Романюк", Projects = new List<Project>
                        {
                            new Project { Id = 114, Title = "Ajax PRO Desktop" }
                        }}
                    }
                }
            };

            // ==========================================
            // 3.1. Запит SelectMany: Всі проєкти всіх співробітників всіх компаній
            // ==========================================
            Console.WriteLine("=== 1. SelectMany: Усі проєкти всіх компаній ===");
            var allProjects = companies
                .SelectMany(company => company.Employees)   // Розгортаємо співробітників
                .SelectMany(employee => employee.Projects)  // Розгортаємо проєкти
                .ToList();

            foreach (var project in allProjects)
            {
                Console.WriteLine($" - [{project.Id}] {project.Title}");
            }

            // ==========================================
            // 3.2. Custom Extension: TotalEmployees()
            // ==========================================
            Console.WriteLine("\n=== 2. Custom Extension: Загальна кількість співробітників ===");
            int totalEmployeesCount = companies.TotalEmployees();
            Console.WriteLine($"Загальна кількість співробітників у всіх компаніях: {totalEmployeesCount}");

            // ==========================================
            // 3.3. Пагінація (Skip, Take): По 2 компанії на сторінку
            // ==========================================
            Console.WriteLine("\n=== 3. Пагінація: Компанії (по 2 на сторінку) ===");
            int pageSize = 2;
            int totalCompanies = companies.Count;
            int totalPages = (int)Math.Ceiling(totalCompanies / (double)pageSize);

            for (int page = 1; page <= totalPages; page++)
            {
                Console.WriteLine($"\n--- Сторінка {page} з {totalPages} ---");

                var companiesOnPage = companies
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                foreach (var company in companiesOnPage)
                {
                    Console.WriteLine($" * Компанія: {company.Name} (Співробітників: {company.Employees.Count})");
                }
            }
        }
    }
}