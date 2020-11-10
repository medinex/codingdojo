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
            _secret = secret;
            var secredGuessed = new string('-', secret.Length);
            _secredGuessed = new StringBuilder(secredGuessed);

        }
        public string Guess(char letter)
        {
            for (int i = 0; i < _secret.Length; i++)
            {
                if (_secret[i] == letter)
                {
                    _secredGuessed[i] = letter;
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
