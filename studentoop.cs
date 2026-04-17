using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    private static int _nextId = 1;
    private double _gpa;

    public int StudentId { get; private set; }
    public string FullName { get; set; }
    public string Faculty { get; set; }

    public double GPA
    {
        get => _gpa;
        set => _gpa = (value >= 0.0 && value <= 4.0) ? value : 0.0;
    }

    public Student(string name, double gpa, string faculty)
    {
        StudentId = _nextId++;
        FullName = name;
        GPA = gpa;
        Faculty = faculty;
    }

    public override string ToString()
    {
        return $"ID: {StudentId:D3} | {FullName} | GPA: {GPA} | Faculty: {Faculty}";
    }
}

class Registry
{
    private Student[] students = new Student[100];
    private int count = 0;

    public void Add(Student s)
    {
        if (count < 100) students[count++] = s;
    }

    public Student FindById(int id)
    {
        for (int i = 0; i < count; i++)
            if (students[i].StudentId == id) return students[i];
        return null;
    }

    public void FindByName(string name)
    {
        for (int i = 0; i < count; i++)
            if (students[i].FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(students[i]);
    }

    public void GetTopStudents(int n)
    {
        var top = students.Take(count).OrderByDescending(s => s.GPA).Take(n);
        foreach (var s in top) Console.WriteLine(s);
    }

    public void PrintAll()
    {
        for (int i = 0; i < count; i++) Console.WriteLine(students[i]);
    }
}

class Program
{
    static void Main()
    {
        Registry registry = new Registry();

        registry.Add(new Student("Alice", 3.2, "CS"));
        registry.Add(new Student("Bob", 2.5, "CS"));
        registry.Add(new Student("Carl", 2.9, "CS"));
        registry.Add(new Student("James", 3.5, "CS"));
        registry.Add(new Student("Chester", 3.1, "CS"));
        registry.Add(new Student("Timur", 2.7, "CS"));
        registry.Add(new Student("Kevin", 2.4, "CS"));
        registry.Add(new Student("Jonathan", 3.9, "CS"));
        registry.Add(new Student("Michael", 2.8, "CS"));
        registry.Add(new Student("Alex", 3.5, "CS"));
        registry.Add(new Student("Josuke", 3.2, "CS"));
        registry.Add(new Student("Arnold", 3.3, "CS"));
        registry.Add(new Student("Steve", 1.9, "CS"));
        registry.Add(new Student("Swarthcz", 4.0, "CS"));
        registry.Add(new Student("Hector", 3.7, "CS"));
        registry.Add(new Student("Joseph", 3.5, "CS"));

        while (true)
        {
            Console.WriteLine("\n1. Add\n2. Find ID\n3. Find Name\n4. Top N\n5. All\n6. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Name: "); string n = Console.ReadLine();
                Console.Write("GPA: "); double g = double.Parse(Console.ReadLine());
                Console.Write("Faculty: "); string f = Console.ReadLine();
                registry.Add(new Student(n, g, f));
            }
            else if (choice == "2")
            {
                Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
                Console.WriteLine(registry.FindById(id)?.ToString() ?? "Not Found");
            }
            else if (choice == "3")
            {
                Console.Write("Name: "); string sn = Console.ReadLine();
                registry.FindByName(sn);
            }
            else if (choice == "4")
            {
                Console.Write("N: "); int n = int.Parse(Console.ReadLine());
                registry.GetTopStudents(n);
            }
            else if (choice == "5") registry.PrintAll();
            else if (choice == "6") break;
        }
    }
}