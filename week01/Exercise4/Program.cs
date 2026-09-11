using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            string numberText = Console.ReadLine();
            number = int.Parse(numberText);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        if (numbers.Count > 0)
        {
            int sum = 0;

            foreach (int item in numbers)
            {
                sum += item;
            }

            double average = (double)sum / numbers.Count;

            int largest = numbers[0];

            foreach (int item in numbers)
            {
                if (item > largest)
                {
                    largest = item;
                }
            }

            int smallestPositive = 0;

            foreach (int item in numbers)
            {
                if (item > 0)
                {
                    if (smallestPositive == 0 || item < smallestPositive)
                    {
                        smallestPositive = item;
                    }
                }
            }

            numbers.Sort();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");

            if (smallestPositive != 0)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            Console.WriteLine("The sorted list is:");

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}