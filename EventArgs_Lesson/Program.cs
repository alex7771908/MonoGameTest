using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventArgs_Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Player player = new Player();

            player.PlayerSaid += OnPlayerSaid;

            player.Say();

            Action action = delegate ()
            {
                Console.WriteLine("Hello");
            };
            action();

            Action<int, int> math = delegate (int a, int b)
            {
                Console.WriteLine(a + b);
            };
            math(1, 2);

            player.Math(delegate (int a, int b)
            {
                return a + b;
            }, 12, 45);

            player.Math(delegate (int a, int b)
            {
                return a - b;
            }, 12, 45);

            Console.ReadKey();

        }

        static void OnPlayerSaid(object sender, EventArgs e)
        {
        PlayerEventArgs args = (PlayerEventArgs)e;
            Console.WriteLine($"{args.Name}({args.Level}) said: {args.Speech}");
        }
    }

    class Player
    {
        public event EventHandler PlayerSaid;

        public void Math(Func<int, int, int> algorithm, int a, int b)
        {
            int res = algorithm(a, b);

            Console.WriteLine("Result: " + res);
        }

        public void Say()
        {
            if(PlayerSaid != null)
            {

                PlayerSaid(this, new PlayerEventArgs() { Name="Dany", Level = 12, Speech = "HI"});
            }
        }
    }

    public class PlayerEventArgs: EventArgs
    {
        public string Name { get; set; }
        public string Speech { get; set; }
        public int Level { get; set; }
    }
}
