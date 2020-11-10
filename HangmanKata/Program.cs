using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman hangman = new Hangman("DEVELOPER");
            Console.WriteLine("Type in your guess :)");
            var guess = Console.ReadLine()[0];
            hangman.Guess(guess);
        }
    }
}
