using System;
using System.Collections.Generic;
 
class Program
{
    static void Main()
    {
        List<string> questions = new List<string>
        {
            "What is the capital of France?",
            "Who wrote 'To Kill a Mockingbird'?",
            "What is the square root of 144?",
            "Who painted the Mona Lisa?",
            "What is the largest planet in our solar system?"
        };
 
        Random random = new Random();
        int index = random.Next(questions.Count);
 
        Console.WriteLine("Random Question: " + questions[index]);
    }
}