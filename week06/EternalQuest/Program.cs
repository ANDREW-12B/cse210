using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Level: {(score / 500) + 1}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.WriteLine();

            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListGoals();
                    break;

                case "2":
                    CreateGoal();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    SaveGoals();
                    break;

                case "5":
                    LoadGoals();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thank you for playing Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your Goals:");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Create New Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select goal type: ");

        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter target number of completions: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully.");
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        ListGoals();

        Console.Write("Which goal did you accomplish? ");
        int number = int.Parse(Console.ReadLine());

        if (number < 1 || number > goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = goals[number - 1];

        int pointsEarned = selectedGoal.RecordEvent();
        score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");

        // Creativity feature: level system based on score.
        int level = (score / 500) + 1;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"You are now Level {level}!");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter output = new StreamWriter("goals.txt"))
        {
            output.WriteLine(score);

            foreach (Goal goal in goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals file was found.");
            return;
        }

        string[] lines = File.ReadAllLines("goals.txt");

        if (lines.Length == 0)
        {
            Console.WriteLine("The saved file is empty.");
            return;
        }

        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));

                bool completed = bool.Parse(parts[4]);

                if (completed)
                {
                    goal.RecordEvent();
                }

                goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));

                goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]));

                int completedCount = int.Parse(parts[6]);

                for (int j = 0; j < completedCount; j++)
                {
                    goal.RecordEvent();
                }

                goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}