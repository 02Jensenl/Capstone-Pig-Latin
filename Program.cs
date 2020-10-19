using System;
using System.Linq;

namespace CapstonePigLatin2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!\nPlease enter a word to translate.");

            bool translateAgain = true;
            while (translateAgain == true)
            {
                string userWord = Console.ReadLine().ToLower().Trim();
                
                char[] inputArray = userWord.ToCharArray();
                int firstVowelIndex = FirstVowel(inputArray);
                string pigLatin = "";
                
                bool charValid = true;
                foreach (var letter in userWord) 
                {
                    if (char.IsDigit(letter) || char.IsPunctuation(letter) || char.IsSymbol(letter) || char.IsWhiteSpace(letter))
                    {
                        charValid = false;
                        Console.WriteLine("Error.\nMust contain one word with no numbers, special characters, or punctuation");
                        Continue();
                    }
                }
                if (charValid && firstVowelIndex == 0) 
                {
                    pigLatin = userWord + "way";
                    Console.WriteLine($"Translation: {pigLatin}");
                }
                else if (charValid && firstVowelIndex == -1) 
                {
                    pigLatin = userWord;
                    if (pigLatin == "")
                    {
                        Console.WriteLine("Must enter a word.");
                    }
                    else
                    {
                        Console.WriteLine("Must contain vowel to properly translate.");
                        Console.WriteLine($"Translation: {pigLatin}");
                    }
                }
                else if (charValid)
                {
                    string pretranslated = userWord.Substring(firstVowelIndex);
                    string posttranslated = userWord.Substring(0, firstVowelIndex) + "ay";
                    pigLatin = pretranslated + posttranslated;
                    Console.WriteLine($"Translation: {pigLatin}");
                }

                translateAgain = Continue();
            }
        }
        public static bool Continue()
        {
            bool playAgain;
            Console.WriteLine("Enter a new word? (y/n): ");
            
            string answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")
            {
                playAgain = true;
                Console.WriteLine("Enter a word below.");
            }
            else if (answer == "n" || answer == "N")
            {
                playAgain = false;
                Console.WriteLine("Thank you for using the Pig Latin Translator.");
            }
            else
            {
                Console.WriteLine("Input not vaild. Please try again.");
                playAgain = Continue();
            }
            return playAgain;
        }
        public static bool IsVowel(char v)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            

            foreach (char vowel in vowels)
            
            {
                if (vowel == v)
                
                {
                    return true;
                }
            }
            return false;
        }
        public static int FirstVowel(char[] userInput)
        {
            for (int i = 0; i < userInput.Length; i++)
            
            {
                char letter = userInput[i];
                
                if (IsVowel(letter))
                
                {
                    return i;
                    
                }
            }
            Console.WriteLine("Error. Please try again");
            return -1;
            
        }
    }
}
