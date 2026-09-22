using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the no-argument constructor
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        // Test the one-parameter constructor
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        // Test the two-parameter constructor
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Test getters and setters
        Fraction fraction4 = new Fraction();
        fraction4.SetTop(1);
        fraction4.SetBottom(3);

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        // Display the values using getters
        Console.WriteLine($"Top: {fraction4.GetTop()}");
        Console.WriteLine($"Bottom: {fraction4.GetBottom()}");
    }
}