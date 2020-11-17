using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangmanKata
{
    public class Hangman
    {
        public string SearchedWord { get; set; }
        public string GuessedWord { get; set; } = String.Empty;

        public Hangman(string secret)
        {
            SearchedWord = secret;
            GuessedWord = new String('-', SearchedWord.Length);
        }

        public string Guess(char letter)
        {
            if(SearchedWord.Contains(letter))
            {
                char[] wordArray = SearchedWord.ToCharArray();
                string pattern = letter.ToString().ToUpper();

                List<int> posArray = new List<int>();

                foreach (Match m in Regex.Matches(SearchedWord, pattern))
                {
                    posArray.Add(m.Index);
                }

                for (int i = 0; i < posArray.Count; i++)
                {
                    var guessedArray = GuessedWord.ToCharArray();
                    guessedArray[posArray[i]] = letter;
                    GuessedWord = new string(guessedArray);
                }
            }
            else
            {
                return GuessedWord;
            }

            return GuessedWord;
        }
    }
}
