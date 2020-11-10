using Hangman;
using NUnit.Framework;

namespace Hangman
{
    public class HangmanTest
    {

        [TestCase("secret","x","------")]
        [TestCase("apple", "x", "-----")]
        public void GuessWrongLetterShouldReturnDashedString(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }

        [TestCase("secret", "e", "-e--e-")]
        [TestCase("apple", "e", "----e")]
        [TestCase("apple", "a", "a----")]
        public void GuessCorrectLetterShouldReturnStringWithRevealedChar(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }

        [TestCase("secret", "C", "--c---")]
        [TestCase("apple", "p", "-pp--")]
        [TestCase("apple", "L", "---l-")]
        public void GuessedLetterIsFoundRegardlessTheCase(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }
    }
}