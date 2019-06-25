using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker
{
    public class Enigma
    {
        private static string _alphabet = "abcdefghijklmnopqrstuvwxyz ";
        private static string      _key = "!)\"(£*%&><@abcdefghijklmno ";

        public static string Decrypt(string message)
        {
            var sb = new StringBuilder();
            message = message.ToLower();

            foreach (var c in message)
            {
                var pos = _key.IndexOf(c);
                sb.Append(_alphabet[pos]);
            }

            return sb.ToString();
        }

        public static string Encrypt(string secret)
        {
            var sb = new StringBuilder();
            secret = secret.ToLower();

            foreach (var c in secret)
            {
                
                var pos = _alphabet.IndexOf(c);
                sb.Append(_key[pos]);
            }

            return sb.ToString();
        }
    }
}
