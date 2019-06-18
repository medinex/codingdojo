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
        private static string _key = "!)\"(£*%&><@abcdefghijklmno ";

        public static string Decrypt(string message)
        {
            var sb = new StringBuilder();

            foreach (var c in message)
            {
                var pos = _alphabet.First(x => x == c);
                sb.Append(_key[pos]);
            }

            return sb.ToString();
        }
    }
}
