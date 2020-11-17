using System;
using System.Text;

namespace Hangman
{
    public class Hangman
    {
        string _secret;
        string _solvedSecret;
        int _attempts = 10;

        public Hangman(string secret) {
            _secret = secret;
            _solvedSecret = new String('-',secret.Length);
        }
        
        public string Guess(char letter) {

            if(_attempts <= 0)
            {
                return _solvedSecret;
            }

            int len = _secret.Length;
            StringBuilder str = new StringBuilder(_solvedSecret);
            string caseInSensitiveSecret = _secret.ToUpper();
            string caseInSensitiveLetter = letter.ToString().ToUpper();

            for (int c=0; c<len; c++)
            {
                if (caseInSensitiveSecret[c].ToString() == caseInSensitiveLetter)
                {
                    str[c] = _secret[c];
                }
            }

            _solvedSecret = str.ToString();
            _attempts--;

            return _solvedSecret;
        }

        public int GetRemainingAttempts()
        {
            return _attempts;
        }
    }

}
