namespace Lab12App;

public class Person
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Age { get; set; }
    public double Salary { get; set; }

    public Person(string name, string category, int age, double salary)
    {
        Name = name;
        Category = category;
        Age = age;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{Name} (Категорія: {Category}, Вік: {Age}, З/П: ${Salary})";
    }
}