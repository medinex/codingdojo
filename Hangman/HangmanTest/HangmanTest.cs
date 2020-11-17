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
        [TestCase("APPLE", "l", "---L-")]
        public void GuessedLetterIsFoundRegardlessTheCase(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }

        [TestCase("secret", "e", "-e--e-", 9)]
        [TestCase("secret", "s", "se--e-", 8)]
        [TestCase("secret", "r", "se-re-", 7)]
        [TestCase("secret", "c", "secre-", 6)]
        [TestCase("secret", "t", "secret", 5)]
        public void OneGuessShouldReduceRemainingAttemptsByOne(string secret, char guessedLetter, string solvedSecret, int remainingAttempts)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
            Assert.AreEqual(remainingAttempts, h.GetRemainingAttempts());
        }

        [TestCase("abc", "x", "------", 9)]
        [TestCase("abc", "x", "------", 8)]
        [TestCase("abc", "x", "------", 7)]
        [TestCase("abc", "x", "------", 6)]
        [TestCase("abc", "x", "------", 5)]
        [TestCase("abc", "x", "------", 4)]
        [TestCase("abc", "x", "------", 3)]
        [TestCase("abc", "x", "------", 2)]
        [TestCase("abc", "x", "------", 1)]
        [TestCase("abc", "x", "------", 0)]
        [TestCase("abc", "x", "------", 0)]
        public void NoMoreGuessingPossibleOnceNoAttemptIsLeft(string secret, char guessedLetter, string solvedSecret, int remainingAttempts)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
            Assert.AreEqual(remainingAttempts, h.GetRemainingAttempts());
        }
    }
}