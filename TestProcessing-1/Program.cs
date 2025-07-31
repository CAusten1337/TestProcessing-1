using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProcessing_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the file:");
            string filePath = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
            var wordCounts = new Dictionary<string, int>();

            // for loop to loop through each line in the array
            for (int i=0; i < lines.Length; i++)
            {
                // Cleans the lines
                string cleanedLine = Regex.Replace(lines[i],@"[^\w\s]", "").ToLower();

                //Splits the now line back into words
                string[] words = cleanedLine.Split(' ');

                //loops though each word from the split line
                for (int j = 0; j < words.Length; j++)
                {
                    string word = words[j];
                    // ingnoring the empty strings
                    if (word != "")
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word] = wordCounts[word] + 1;
                        }
                        else
                        {
                            //adds the new word
                            wordCounts.Add(word, 1);
                        }
                    }
                }
            }

            Console.WriteLine("Done");

            //prin
            foreach (var entry in wordCounts)
            {
                //interpolated
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine($"\nTotal unique words = {wordCounts.Count}");
            Console.ReadKey();
        }
    }
}
