using System;
using HangmanKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanKataTest
{
    [TestClass]
    public class HangmanTest
    {
        private Hangman _hangman { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            _hangman = new Hangman("DEVELOPER");
        }

        [TestMethod]
        public void ConstructorShouldReturnNumberOfCharactersAsMinus()
        {
            Hangman hangman = new Hangman("GEHEIMNIS");
            Assert.AreEqual("---------", hangman.GuessedWord);
        }

        [TestMethod]
        public void GuessLetterShouldReturnUnderscores()
        {
            Assert.AreEqual("---------", _hangman.GuessedWord);
        }

        [TestMethod]
        public void GuessLetterDShouldInsertD()
        {
            _hangman.Guess('D');
            Assert.AreEqual("D--------", _hangman.GuessedWord);
        }

        [TestMethod]
        public void GuessLetterEShouldInsertD()
        {
            _hangman.Guess('E');
            Assert.AreEqual("-E-E---E-", _hangman.GuessedWord);
        }

        [TestMethod]
        public void GuessAllLettersShouldInsertLetters()
        {
            _hangman.Guess('D');
            Assert.AreEqual("D--------", _hangman.GuessedWord);

            _hangman.Guess('E');
            Assert.AreEqual("DE-E---E-", _hangman.GuessedWord);

            _hangman.Guess('V');
            Assert.AreEqual("DEVE---E-", _hangman.GuessedWord);

            //NOT MATCHING
            _hangman.Guess('A');
            Assert.AreEqual("DEVE---E-", _hangman.GuessedWord);

            _hangman.Guess('R');
            Assert.AreEqual("DEVE---ER", _hangman.GuessedWord);

            _hangman.Guess('L');
            Assert.AreEqual("DEVEL--ER", _hangman.GuessedWord);

            _hangman.Guess('O');
            Assert.AreEqual("DEVELO-ER", _hangman.GuessedWord);

            _hangman.Guess('P');
            Assert.AreEqual("DEVELOPER", _hangman.GuessedWord);
        }
    }
}
