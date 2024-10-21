using System;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace MyApp
{

    internal class Program
    {
        static bool CheckPalindrom(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int j = 0;
            string word = "";



            string[] data = File.ReadAllText("przyklad.txt").Split('\n', StringSplitOptions.TrimEntries).SkipLast(1).ToArray();
            int counterNumber = 0;
            foreach (var line in data)
            {
                foreach (var sight in line)
                {
                    if (int.TryParse(sight.ToString(), out _))
                    {
                        counterNumber += 1;
                    }
                }

            }
            Console.WriteLine(counterNumber);

            for (int i = 19; i < data.Length; i += 20)
            {
                word += data[i][j];
                j += 1;


            }
            Console.WriteLine(word);
            int[] array1 = new int[5];
            string result = "";
            foreach (var line in data)
            {
                string wordWithLastSightAddedtoFirstCell = line[line.Length - 1] + line;
                string wordWithFirstSightAddedtoLastCell = line + line[0];

                if (CheckPalindrom(wordWithFirstSightAddedtoLastCell))
                {
                    result += wordWithFirstSightAddedtoLastCell[wordWithFirstSightAddedtoLastCell.Length / 2];
                }
                if (CheckPalindrom(wordWithLastSightAddedtoFirstCell))
                {
                    result += wordWithLastSightAddedtoFirstCell[wordWithLastSightAddedtoFirstCell.Length / 2];
                }
            }

            Console.WriteLine(result);


            string pair = "";
            string password3 = "";
            int counterX = 0;
            foreach (var line in data)
            {
                if (counterX == 3)
                {
                    break;
                }
                pair = "";
                for (int i = 0; i < line.Length; i += 1)
                {

                    if (!char.IsDigit(line[i]))
                        continue;
                    pair += line[i];
                    if (pair.Length != 2)
                        continue;

                    int ASCIINumberResult = int.Parse(pair);
                    if (ASCIINumberResult >= 65 && ASCIINumberResult <= 90)
                    {
                        password3 += (char)ASCIINumberResult;
                    }
                    if (ASCIINumberResult == 'X')
                    {
                        counterX++;
                    }
                    else
                    {
                        counterX = 0;
                    }
                    pair = "";

                    if (counterX == 3)
                    {
                        break;
                    }


                }
            }

            Console.WriteLine(password3);

        }
    }
}
