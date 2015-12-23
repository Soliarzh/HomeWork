using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCounterForEPAM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load a string from the file
            string fileName = "EPAMText.txt";
            string inputString = File.ReadAllText(fileName);

            //Display initial text
            Console.WriteLine();
            Console.WriteLine("The file 'EPAMText.txt' contains following text: ");
            Console.Write(inputString);

            // Put all the text to lowercase
            inputString = inputString.ToLower();

            // trim all chars that are not letters
            string[] trimChars = { "\n", "\t", "\r", "!", "@", "#", "$", "%", "^",
                                     "&", "*", "(", ")", "_", "-", "+", "=", "{",
                                     "}", "[", "]", ";", ":", "'", "'", "/", "?",
                                     ".", ",", "<", ">",
                                     "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            
            foreach (string character in trimChars)
            {
                inputString = inputString.Replace(character, "");
            }

            // Make a list of words dividing the string by spaces
            List<string> wordList = inputString.Split(' ').ToList();
            
            // Make a dictionary
                Dictionary<string, int> dict = new Dictionary<string, int>();

            // Ruth throuth the all words in list ...
			foreach (string word in wordList)
			{
                // If the word is at least 1 char lenght ...
                if (word.Length >= 1)
                {
            // ...check the word is in the dictionary
                    if (dict.ContainsKey(word))
                    {
            // If yes then increment the count
                        dict[word]++;
                    }
                    else
                    {
            // Otherwise add it to dictionary first time
                        dict[word] = 1;
                    }
                }
            }

			// Sort our dictionary by value
            var dictSorted = (from a in dict orderby a.Value descending select a).ToDictionary(p => p.Key, p => p.Value);

			// show most frequently occurred words
			int qty = 1;
                //Display some description of the program
            Console.WriteLine();
            Console.WriteLine("Words usage frequency is following: ");
			Console.WriteLine();
            foreach (KeyValuePair<string, int> p in dictSorted)
			{
				// Output
                Console.WriteLine(qty + "\t" + p.Key + "\t" + p.Value);
                qty++;

				// display top 500
                if (qty > 500)
				{
					break;
				}
			}

			// Wait before exit
			Console.ReadKey();
            }
        }
    }

  