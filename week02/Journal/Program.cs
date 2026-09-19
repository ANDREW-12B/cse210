using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Please choose an option: ");

            string choice = Console.ReadLine();

            Console.WriteLine();

            if (choice == "1")
            {
                WriteNewEntry(journal);
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                Console.WriteLine();
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string[] prompts =
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "What is something I learned today?",
            "What is one thing I could improve tomorrow?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);

        Console.WriteLine($"Prompt: {prompts[index]}");
        Console.Write("Response: ");

        string response = Console.ReadLine();

        Entry entry = new Entry();
        entry._date = DateTime.Now.ToShortDateString();
        entry._prompt = prompts[index];
        entry._response = response;

        journal.AddEntry(entry);

        Console.WriteLine("Entry added successfully.");
        Console.WriteLine();
    }
}