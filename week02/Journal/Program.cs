using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.WriteLine("Your answer: ");
                    string userResponse = Console.ReadLine();

                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry newEntry = new Entry(currentDate, randomPrompt, userResponse);

                    journal.AddEntry(newEntry);
                }
                else if (choice == 2)
                {
                    journal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Type the file name to save:");
                    string fileName = Console.ReadLine();
                    journal.SaveToFile(fileName);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Type the file name to load:");
                    string fileName = Console.ReadLine();
                    journal.LoadFromFile(fileName);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Quiting the program. See you soon!");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
