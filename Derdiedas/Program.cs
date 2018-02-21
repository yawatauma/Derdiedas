using System;
using System.Linq;
using System.IO;

namespace Derdiedas
{
	class Program
	{
		public static void Main()
		{
            // starting page asks for search or entry
            bool keepLooping = true;
            while (keepLooping)
            {
                string[] wordList = File.ReadAllLines(@"C:\Users\zo7d\source\repos\Derdiedas\Derdiedas\wordlist.txt");

                Console.WriteLine("Enter new word or look up existing entry");
                string inputWord = Console.ReadLine().ToLower();
                bool onlyLegitCharacters = true;
                foreach (char c in inputWord)
                {
                    if (!"abcdefghijklmnopqrstuvwxyzäöüß".Contains(c))
                    {
                        Console.WriteLine("Invalid entry. Was there a character excluded from the German alphabet?");
                        Console.WriteLine(Environment.NewLine);
                        onlyLegitCharacters = false;
                        break;
                    }

                }
                if (!onlyLegitCharacters)
                {
                    continue;
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
                if (!alreadyInList)
                {
                    string newEntryForList = "";
                    Console.WriteLine("Input word is not in the list. To add, select from der, die, or das (1, 2, 3 or m, f, n)");
                    string genderInput = Console.ReadLine();
                    if (genderInput.Length == 1 && "123mfn".Contains(genderInput))
                    {
                        if (genderInput == "1" || genderInput == "m")
                        {
                            newEntryForList = $"der {Char.ToUpper(inputWord[0])}{inputWord.Substring(1)}";
                        }

                        if (genderInput == "2" || genderInput == "f")
                        {
                            newEntryForList = $"die {Char.ToUpper(inputWord[0])}{inputWord.Substring(1)}";
                        }

                        if (genderInput == "3" || genderInput == "n")
                        {
                            newEntryForList = $"das {Char.ToUpper(inputWord[0])}{inputWord.Substring(1)}";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input." + Environment.NewLine);
                    }
                    File.AppendAllText(@"C:\Users\zo7d\source\repos\Derdiedas\Derdiedas\wordlist.txt", Environment.NewLine + newEntryForList);
                }


            }
			// TODO: display last search
			// TODO: list of previously searched words?
            // TODO: allow for multiple genders per noun (modernisation)
		}
	}
}