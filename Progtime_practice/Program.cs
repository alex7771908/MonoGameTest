using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtime_practice
{

    internal class Program
    {
        public static void Main()
        {
            Action[] MyActions = { delegate ()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=^_^=");
            } , delegate ()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("KEK");
            }, delegate ()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("HI");
            }
            };

            MyActions[int.Parse(Console.ReadLine())]();

            Console.ReadLine();
        }
       
        
    }
}
