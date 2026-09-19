using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetFileString());
            }
        }

        Console.WriteLine("Journal saved successfully.");
        Console.WriteLine();
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("The file could not be found.");
            Console.WriteLine();
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length >= 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._response = parts[2];

                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully.");
        Console.WriteLine();
    }
    public void Search(string searchTerm)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry._prompt.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry._response.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No journal entries matched your search.");
            Console.WriteLine();
        }
    }
}