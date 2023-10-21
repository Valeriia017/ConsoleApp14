using System;

class Employee
{
    public int Id { get; set; }
    public int YearOfEmployment { get; set; }
    public double Salary { get; set; }
    public double Bonus { get; set; }

    public Employee(int id, int yearOfEmployment, double salary)
    {
        Id = id;
        YearOfEmployment = yearOfEmployment;
        Salary = salary;
    }

    public virtual void Print()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Ідентифікаційний код: {Id}, Рік прийняття на роботу: {YearOfEmployment}, Оклад: {Salary}, Премія: {Bonus}");
    }

    public virtual void CalculateBonus(int currentYear)
    {
        Console.WriteLine($"Співробітник");
        if (currentYear - YearOfEmployment < 5)
        {
            Bonus = Salary * 0.1;
        }
        else if (currentYear - YearOfEmployment >= 5 && currentYear - YearOfEmployment <= 10)
        {
            Bonus = Salary * 0.15;
        }
        else
        {
            Bonus = Salary * 0.2;
        }
    }
}

class Vip : Employee
{
    public bool IsVip { get; set; }

    public Vip(int id, int yearOfEmployment, double salary, bool isVip) : base(id, yearOfEmployment, salary)
    {
        IsVip = isVip;
    }
    public override void CalculateBonus(int currentYear)
    {
        Console.WriteLine($"VIP");
        if (currentYear - YearOfEmployment < 5)
       {
         Bonus = Salary * 0.2;
       }
       else if (currentYear - YearOfEmployment >= 5 && currentYear - YearOfEmployment <= 10)
       {
         Bonus = Salary * 0.3;
       }
       else
       {
         Bonus = Salary * 0.5;
       }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Employee employee = new Employee(1234, 2018, 5000);
        employee.CalculateBonus(2023);
        employee.Print();

        Console.WriteLine();

        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            int id = random.Next(1000, 9999);
            int yearOfEmployment = random.Next(2010, 2023);
            double salary = random.Next(3000, 10000);

            if (i == 0)
            {
                employee = new Employee(id, yearOfEmployment, salary);
                employee.CalculateBonus(2023);
                employee.Print();
            }
            else if (i == 1)
            {
                Vip vipEmployee = new Vip(id, yearOfEmployment, salary, true);
                vipEmployee.CalculateBonus(2023);
                vipEmployee.Print();
            }
            else
            {
                Vip nonVipEmployee = new Vip(id, yearOfEmployment, salary, false);
                nonVipEmployee.CalculateBonus(2023);
                nonVipEmployee.Print();
            }

            Console.WriteLine();
        }
    }
}