using System;

// Класс для работы с парой чисел 
public class Pair
{
    public double A { get; set; }
    public double B { get; set; }

    public Pair(double a, double b)
    {
        A = a;
        B = b;
    }

    // Умножение на число
    public Pair Multiply(double number)
    {
        return new Pair(A * number, B * number);
    }

    // Сложение пар
    public static Pair operator +(Pair p1, Pair p2)
    {
        return new Pair(p1.A + p2.A, p1.B + p2.B);
    }

    // Вывод информации
    public void Print()
    {
        Console.WriteLine($"({A}, {B})");
    }
}

// Класс-наследник для работы с деньгами
public class Money : Pair
{
    public Money(double rubles, double kopecks) : base(rubles, kopecks)
    {
        // Нормализация копеек
        while (B >= 100)
        {
            B -= 100;
            A += 1;
        }
    }

    // Переопределение сложения для денег
    public static Money operator +(Money m1, Money m2)
    {
        return new Money(m1.A + m2.A, m1.B + m2.B);
    }

    // Операция вычитания
    public static Money operator -(Money m1, Money m2)
    {
        double totalKopecks1 = m1.A * 100 + m1.B;
        double totalKopecks2 = m2.A * 100 + m2.B;
        double result = totalKopecks1 - totalKopecks2;

        return new Money(0, result);
    }

    // Умножение денежной суммы на число
    public new Money Multiply(double number)
    {
        double totalKopecks = A * 100 + B;
        double result = totalKopecks * number;

        return new Money(0, result);
    }

    // Вывод денежной суммы
    public new void Print()
    {
        Console.WriteLine($"{A} руб. {B} коп.");
    }
}

        Console.WriteLine("Работа с комплексными числами:");
        Pair complex1 = new Pair(3, 2); // 3 + 2i
        Pair complex2 = new Pair(1, 4); // 1 + 4i

        Console.Write("Комплекс1: ");
        complex1.Print();

        Console.Write("Комплекс2: ");
        complex2.Print();

        Pair sum = complex1 + complex2;
        Console.Write("Сумма: ");
        sum.Print();

        Pair multiplied = complex1.Multiply(2);
        Console.Write("Умножение Комплекс1 на 2: ");
        multiplied.Print();

        Console.WriteLine("\nРабота с деньгами:");
        Money money1 = new Money(10, 50); // 10 руб. 50 коп.
        Money money2 = new Money(5, 75);  // 5 руб. 75 коп.

        Console.Write("Деньги1: ");
        money1.Print();

        Console.Write("Деньги2: ");
        money2.Print();

        Money moneySum = money1 + money2;
        Console.Write("Сумма: ");
        moneySum.Print();

        Money moneyDiff = money1 - money2;
        Console.Write("Разность: ");
        moneyDiff.Print();

        Money moneyMult = money1.Multiply(3);
        Console.Write("Умножение Деньги1 на 3: ");
        moneyMult.Print();
