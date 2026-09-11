using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeText = Console.ReadLine();
        int grade = int.Parse(gradeText);

        string letter;

        // Determine the letter grade.
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the + or - sign.
        string sign = "";
        int lastDigit = grade % 10;

        if (letter == "A")
        {
            // There is no A+.
            if (grade < 100 && lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Display the final grade.
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine whether the student passed.
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Keep working hard and you'll do better next time.");
        }
    }
}