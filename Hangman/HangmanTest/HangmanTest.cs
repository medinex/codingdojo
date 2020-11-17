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

        [Test]
        public void MultipleGuessesShouldSolveTheSecret()
        {
            Hangman h = new Hangman("secret");
            Assert.AreEqual("-e--e-", h.Guess('e')); 
            Assert.AreEqual("se--e-", h.Guess('s'));
            Assert.AreEqual("se-re-", h.Guess('r')); 
            Assert.AreEqual("secre-", h.Guess('c'));
            Assert.AreEqual("secret", h.Guess('t'));
        }

        [Test]
        public void OneGuessShouldReduceRemainingAttemptsByOne()
        {
            Hangman h = new Hangman("secret");
            h.Guess('e'); Assert.AreEqual(9, h.GetRemainingAttempts(), "guess e -> -e--e-");
            h.Guess('s'); Assert.AreEqual(8, h.GetRemainingAttempts(), "guess s -> se--e-");
            h.Guess('r'); Assert.AreEqual(7, h.GetRemainingAttempts(), "guess s -> se-re-");
            h.Guess('c'); Assert.AreEqual(6, h.GetRemainingAttempts(), "guess s -> secre-");
            h.Guess('t'); Assert.AreEqual(5, h.GetRemainingAttempts(), "guess s -> secret");
        }

        [Test]
        public void NoMoreGuessingPossibleOnceNoAttemptIsLeft()
        {
            Hangman h = new Hangman("abc");
            
            for (int c = 9; c > 0; c--)
            {
                h.Guess('x'); Assert.AreEqual(c, h.GetRemainingAttempts(), "attempt " + c + " guess x -> ---");
            }
            
            h.Guess('x'); Assert.AreEqual(0, h.GetRemainingAttempts(), "guess x -> ---");
            h.Guess('x'); Assert.AreEqual(0, h.GetRemainingAttempts(), "guess x -> ---");
        }
    }
}