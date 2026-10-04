using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private Random _random;

    public GratitudeActivity()
        : base(
            "Gratitude",
            "This activity will help you focus on the positive things in your life by guiding you to think about people, experiences, and opportunities you are grateful for.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a person who has made a positive difference in your life.",
            "Think of an experience that you are grateful to have had.",
            "Think of something you have learned that has helped you grow.",
            "Think of a place where you feel peaceful or happy.",
            "Think of an opportunity you are grateful for."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine($"--- {GetRandomPrompt()} ---");
            Console.WriteLine("Take some time to think about it.");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}