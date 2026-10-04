using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Start Gratitude Activity");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                GratitudeActivity activity = new GratitudeActivity();
                activity.Run();
            }
            else if (choice == "5")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program.");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}

/*
 * Creativity / Exceeding Requirements:
 * I added a fourth activity called Gratitude Activity.
 * This activity gives users additional prompts to focus on
 * positive people, experiences, opportunities, and blessings.
 */