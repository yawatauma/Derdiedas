using System;
using System.Linq;
using System.IO;

namespace Derdiedas
{
	class Program
	{
		public static void Main()
		{
            string[] wordList = File.ReadAllLines(@"C:\Users\zo7d\source\repos\Derdiedas\Derdiedas\wordlist.txt");
            // starting page asks for search or entry
            bool keepLooping = true;
            while (keepLooping)
            {
                Console.WriteLine("Enter new word or look up existing entry");
                string inputWord = Console.ReadLine().ToLower();
                bool onlyLegitCharacters = true;
                foreach (char c in inputWord)
                {
                    if (!"abcdefghijklmnopqrstuvwxyzäöüß".Contains(c))
                    {
                        Console.WriteLine("Word can only contain the 26 letters of the latin alphabet and the 4 extra German letters");
                        Console.WriteLine(Environment.NewLine);
                        onlyLegitCharacters = false;
                        break;
                    }

                }
                if (onlyLegitCharacters)
                {
                    Console.WriteLine(inputWord);
                }

                bool alreadyInList = false;
                foreach (var line in wordList)
                {
                    if (line.ToLower().Contains(inputWord) && line.Length == inputWord.Length + 4)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine(Environment.NewLine);
                        alreadyInList = true;
                        break;
                    }
                }
                if (alreadyInList)
                {
                    Console.WriteLine("Input word is not in the list. To add, select from der, die, or das (1, 2, 3 or m, f, n)");
                    string genderInput = Console.ReadLine();
                    if (genderInput.Length == 1 && "123mfn".Contains(genderInput))
                    {

                    }
                    else
                    {
                        Console.WriteLine("Invalid input." + Environment.NewLine);
                    }
                    Char firstLetterToCapitalize = Char.ToUpper(inputWord[0]);

                    File.AppendAllText(@"C:\Users\zo7d\source\repos\Derdiedas\Derdiedas\wordlist.txt", inputWord)
                }


            }
			// display last search
			// list of previously searched words?

			// make a list into which Nouns will be fed 
			// 
		}
	}
}