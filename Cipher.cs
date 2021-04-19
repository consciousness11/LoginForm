using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class Cipher
    {
        public static char cipers(char c, int k)
        {
            if (!char.IsLetter(c)) return c;

            char convCh = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + k) - convCh) % 26) + convCh);

        }

        public static string Encrypt(string input, int key)
        {
            string output = string.Empty;
            foreach (char c in input)
                output += cipers(c, key);
            return output;
        }

        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }
    }
}
