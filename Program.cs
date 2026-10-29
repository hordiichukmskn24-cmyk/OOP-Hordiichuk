using System.Text;

namespace Lab12App;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== 1. ТЕСТУВАННЯ З ТИПОМ int ===");
        List<int> numbers = new() { 15, 3, 8, 3, 42, 8, 10, 15 };

        var evenNumbers = FunctionalUtils.Filter(numbers, n => n % 2 == 0);
        Console.Write("Парні числа (Filter): ");
        FunctionalUtils.ForEach(evenNumbers, n => Console.Write($"{n} "));
        Console.WriteLine();

        var sortedNumbers = FunctionalUtils.OrderBy(numbers, n => n);
        Console.Write("Відсортовані числа (OrderBy): ");
        FunctionalUtils.ForEach(sortedNumbers, n => Console.Write($"{n} "));
        Console.WriteLine();

        Console.WriteLine("\n=== 2. ТЕСТУВАННЯ З ТИПОМ string ===");
        List<string> words = new() { "Apple", "Banana", "Apricot", "Blueberry", "Avocado" };

        var groupedByFirstLetter = FunctionalUtils.GroupBy(words, w => w[0]);
        Console.WriteLine("Групування слів за першою літерою (GroupBy):");
        foreach (var group in groupedByFirstLetter)
        {
            Console.WriteLine($" Літера '{group.Key}': {string.Join(", ", group.Value)}");
        }

        Console.WriteLine("\n=== 3. ТЕСТУВАННЯ З ВЛАСНИМ КЛАСОМ Person ===");
        List<Person> people = new()
        {
            new Person("Олексій", "IT", 25, 2500),
            new Person("Марія", "HR", 25, 2000),
            new Person("Іван", "IT", 20, 1800),
            new Person("Олена", "HR", 30, 3100),
            new Person("Дмитро", "IT", 25, 2200)
        };

        var itDepartment = FunctionalUtils.Filter(people, p => p.Category == "IT");
        Console.WriteLine("Працівники відділу IT (Filter):");
        FunctionalUtils.ForEach(itDepartment, p => Console.WriteLine($" - {p}"));

        var names = FunctionalUtils.Map(people, p => p.Name);
        Console.Write("\nСписок імен (Map Person -> string): ");
        FunctionalUtils.ForEach(names, name => Console.Write($"{name}; "));
        Console.WriteLine();

        var groupedByDept = FunctionalUtils.GroupBy(people, p => p.Category);
        Console.WriteLine("\nГрупування людей за відділом (GroupBy):");
        foreach (var group in groupedByDept)
        {
            Console.WriteLine($" Відділ {group.Key}:");
            FunctionalUtils.ForEach(group.Value, p => Console.WriteLine($"   * {p}"));
        }

        var sortedPeople = FunctionalUtils.ThenBy(people, p => p.Age, p => p.Salary);
        Console.WriteLine("\nСортування за віком, а потім за зарплатою (OrderBy + ThenBy):");
        FunctionalUtils.ForEach(sortedPeople, p => Console.WriteLine($" - {p}"));
    }
}
