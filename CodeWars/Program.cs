using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class Kata
    {
        public static void Main()
        {
            Decode("   .... . -.--   .--- ..- -.. .     ");
            Console.ReadLine();
        }

        public static string Decode(string morseCode)
        {
            string symbol = "";
            string code = "";
            for (int i = morseCode.Length - 1; i > 0; i--)
            {
                if (morseCode[i] == ' ')
                {
                    morseCode.Remove(i, 1);
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < morseCode.Length; i++)
            {
                if (morseCode[i] == ' ' && code != "")
                {
                    symbol += MorseCode.Get(code);
                    code = "";
                    if (morseCode[i + 1] == ' ' && morseCode[i + 2] == ' ')
                    {
                        symbol += ' ';
                        code = "";
                    }
                }
                else
                {
                    code += morseCode[i];
                }
            }
            symbol += MorseCode.Get(code);
            return symbol;
        }
    }
}
