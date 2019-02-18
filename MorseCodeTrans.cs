using System;
using System.Text;
using System.Collections.Generic;

namespace Treehouse
{
    static class MorseCodeTranslator
    {
        private static Dictionary<char, string> _textToMorse = new Dictionary<char, string>
        {
            {' ', "/"},
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'0', "-----"},
            {',', "--..--"},
            {'.', ".-.-.-"},
            {'?', "..--.."},
            {';', "-.-.-."},
            {':', "---..."},
            {'/', "-..-."},
            {'-', "-....-"},
            {'\'', ".----."},
            {'"', ".-..-."},
            {'(', "-.--."},
            {')', "-.--.-"},
            {'=', "-...-"},
            {'+', ".-.-."},
            {'@', ".--.-."},
            {'!', "-.-.--"},
            {'Á', ".--.-"},
            {'É', "..-.."},
            {'Ö', "---."},
            {'Ä', ".-.-"},
            {'Ñ', "--.--"},
            {'Ü', "..--"}
        };
    
        //a 2nd dictionary for the collection of the reverse morse to text keys and values
        private static Dictionary<string, char> _morseToText = new Dictionary<string, char>();

        //a constructor to flip all keys and values from the original dictionary into the new dictionary
        //since it's a static method this thing is constructed once without being called against an instance
        static MorseCodeTranslator()
        {
            foreach(KeyValuePair<char, string> textToMorse in _textToMorse)
            {
                _morseToText.Add(textToMorse.Value,textToMorse.Key);
            }
        }
        //Method for converting Text string to Morse code
        public static string StringToMorse(string input)
        {
            List<string> output = new List<string>(input.Length);

            foreach(char c in input.ToUpper())
            {
                try
                {
                    string morseCode = _textToMorse[c];
                    output.Add(morseCode);   
                }
                catch(KeyNotFoundException)
                {
                    output.Add("?");
                }  
            }
            return string.Join(" ", output);
        }
        //Method for converting Morse Code to text string
        // ".... .. / . ...- .- -."
        public static string MorseToString(string input)
        {
            List<char> output = new List<char>();
            //Parses out the Morse Code from a single string into an array of strings
            try
            {
                string[] parsedMorse =  input.Split(" ");

                foreach(string morseChar in parsedMorse)
                {
                    //Looks up and grabs the text char value per the morse code key from 2nd Dictionary
                    try
                    {
                        char normalText = _morseToText[morseChar];
                        output.Add(normalText);
                    }
                    catch(KeyNotFoundException)
                    {
                        output.Add('?');
                    }  
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Morse Code");
            }
            return string.Join("", output);    
        }
    }
}