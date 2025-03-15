using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries;

    // Constructor to inicialize the entry list
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to add a new entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine("Entry added to the Journal!");
    }

    // Method to display all entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found in the Journal.");
        }
        else
        {
            Console.WriteLine("Journal's entry:");
            foreach (var entry in _entries)
            {
                entry.Display();
                Console.WriteLine(); // Spacement between the entries
            }
        }
    }

    // Method to save the entries in a file
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Entries saved in the file susscefully");
    }

    // Method to load entries from a file
    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear(); // Clear existing entries before loading new ones
            string[] lines = File.ReadAllLines(file);

            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(loadedEntry);
                }
            }

            Console.WriteLine("Entries loaded from file successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
