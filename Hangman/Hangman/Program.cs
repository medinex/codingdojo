using System;
using System.Text;

namespace HangmanGame
{
    public class Hangman
    {
        private string _secret = "";
        private StringBuilder _secredGuessed;
        public Hangman(string secret)
        {
            _secret = secret.ToLower();
            var secredGuessed = new string('-', secret.Length);
            _secredGuessed = new StringBuilder(secredGuessed);

        }
        public string Guess(char letter)
        {
            var lowerLetter = Char.ToLower(letter);
            for (int i = 0; i < _secret.Length; i++)
            {
                if (_secret[i] == lowerLetter)
                {
                    _secredGuessed[i] = lowerLetter;
                }
            }

            return _secredGuessed.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
