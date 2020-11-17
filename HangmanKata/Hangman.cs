using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HangmanKata
{
    public class Hangman
    {
        private string _searchedWord { get; set; }
        public string GuessedWord { get; set; } = String.Empty;
        public int LimitGuess { get; } = 10;
        private int _attempts = 0;

        public Hangman(string secret)
        {
            _searchedWord = secret;
            GuessedWord = new String('-', _searchedWord.Length);
        }

        public string Guess(char letter)
        {
            if (_searchedWord.Contains(letter))
            {
                if(_attempts > LimitGuess)
                {
                    return "You lost.";
                }
                _attempts++;

                char[] wordArray = _searchedWord.ToCharArray();
                string pattern = letter.ToString().ToUpper();

                List<int> posArray = new List<int>();

                foreach (Match m in Regex.Matches(_searchedWord, pattern))
                {
                    posArray.Add(m.Index);
                }

                var guessedArray = GuessedWord.ToCharArray();

                for (int i = 0; i < posArray.Count; i++)
                {
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
