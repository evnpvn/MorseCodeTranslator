using System;

namespace Treehouse
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.Write(":");
                string input = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if(!(input.Contains("-")) || !(input.Contains(".")))
                {
                    string output = MorseCodeTranslator.StringToMorse(input);
                    Console.WriteLine(output);
                }

                else
                {
                    string output = MorseCodeTranslator.MorseToString(input);
                    Console.WriteLine(output);
                }
            }
        }
    }
}