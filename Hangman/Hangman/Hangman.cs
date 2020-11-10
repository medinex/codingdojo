using System;

namespace Hangman
{
    public class Hangman
    {
        string _secret;

        public Hangman(string secret) {
            _secret = secret;
        }
        
        public string Guess(char letter) {

            int len = _secret.Length;
            string solvedSecret = "";
            string caseInSensitiveSecret = _secret.ToUpper();
            string caseInSensitiveLetter = letter.ToString().ToUpper();

            for (int c=0; c<len; c++)
            {
                if (caseInSensitiveSecret[c].ToString() == caseInSensitiveLetter)
                {
                    solvedSecret += letter;
                }
                else
                {
                    solvedSecret += "-";
                }
            }

            return solvedSecret;
        }
    }

}
