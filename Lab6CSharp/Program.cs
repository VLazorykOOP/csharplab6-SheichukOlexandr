using System;

// Завдання 1
abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine($"{GetType().Name} конструктор викликаний.");
    }

    ~Person()
    {
        Console.WriteLine($"{GetType().Name} деструктор викликаний.");
    }

    public virtual void Show()
    {
        Console.WriteLine($"iм'я: {Name}, Вiк: {Age}");
    }
}

class Employee : Person
{
    public string Position { get; set; }

    public Employee(string name, int age, string position) : base(name, age)
    {
        Position = position;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Посада: {Position}");
    }
}

class Worker : Employee
{
    public string Factory { get; set; }
    public int Experience { get; set; }

    public Worker(string name, int age, string factory, int experience) : base(name, age, "Робiтник")
    {
        Factory = factory;
        Experience = experience;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Фабрика: {Factory}, Досвiд: {Experience}");
    }
}

class Engineer : Employee
{
    public string Education { get; set; }

    public Engineer(string name, int age, string position, string education) : base(name, age, position)
    {
        Education = education;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Освiта: {Education}");
    }
}

// Завдання 2
interface Function
{
    double Calculate(double x);
}

class Line : Function
{
    private double a;
    private double b;

    public Line(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public double Calculate(double x)
    {
        return a * x + b;
    }
}

class Kub : Function
{
    private double a;
    private double b;
    private double c;

    public Kub(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double Calculate(double x)
    {
        return a * x * x + b * x + c;
    }
}

class Hyperbola : Function
{
    public double Calculate(double x)
    {
        return 1 / x;
    }
}

// Завдання 3
enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Lab6");
            Console.WriteLine("Виберiть завдання:");
            Console.WriteLine("1. Завдання 1 - розв'язок задачi з персонажами");
            Console.WriteLine("2. Завдання 2 - Побудувати iєрархiю iз iнтерфейсом, який успадковує iнтерфейси .NET");
            Console.WriteLine("3. Завдання 3 - додавання стандартних iнтерфейсiв .NET");
            Console.WriteLine("4. Вихiд");
            Console.WriteLine("");
            Console.Write("Виберiть завдання --> ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неправильний ввiд. Будь ласка, введiть номер завдання.");
                continue;
            }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильний вибiр. Будь ласка, виберiть номер завдання зi списку.");
                    break;
            }
            Console.WriteLine("\nНатиснiть будь-яку кнопку для продовження...");
            Console.ReadKey(); // Чекає натискання будь-якої кнопки
        }
    }

    static void Task1()
    {
        Console.WriteLine("");
        Employee employee = new Employee("Петро", 40, "Менеджер");
        employee.Show();
        Console.WriteLine("");
        Worker worker = new Worker("Олександр", 35, "Завод", 5);
        worker.Show();
        Console.WriteLine("");
        Engineer engineer = new Engineer("Василь", 45, "Програмiст", "Вища");
        engineer.Show();
    }

    static void Task2()
    {
        Function[] functions = new Function[3];
        functions[0] = new Line(2, 3);
        functions[1] = new Kub(1, 2, 3);
        functions[2] = new Hyperbola();

        Console.Write("Введiть значення x: ");
        double x;
        if (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Неправильне значення x.");
            return;
        }
        foreach (var function in functions)
        {
            Console.WriteLine($"Значення функцiї в точцi x={x}: {function.Calculate(x)}");
        }
    }

    static void Task3()
    {
        foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
        {
            Console.WriteLine(day);
        }
    }
}
