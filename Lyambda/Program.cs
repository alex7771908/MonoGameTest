using System;

namespace Example
{
    // Разработка типа делегата для лямбда-выражения
    public delegate void ActionMatch(string a, string b);
    public delegate bool FuncMatch(string a, string b);
    public delegate int Counting(string str);

    public class Program
    {
        // Разработка метода SetPassword()


        public static void Main(string[] args)
        {
            SetLogin();  // временно этот метод нам не нужен

            SetPassword();

            if (CheckCapture())
            {
                Console.WriteLine("Registration completed successfully");
            }
            else
            {
                Console.WriteLine("Failed to register");
            }
        }

        public static void SetLogin()
        {
            Console.WriteLine("Enter login:");

            Counting counting = (string a) =>
            {
                int i = 0;
                foreach (char s in a)
                {
                    i++;
                }
                return i;
            };
            if (counting(Console.ReadLine()) > 15)
            {
                Console.WriteLine("Name is too long");
                SetLogin();
            }
        }

        public static void SetPassword()
        {
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Repeat password:");
            string repeatedPassword = Console.ReadLine();
            ActionMatch funcMatch = (a, b) =>
            {
                if (a == b)
                {
                    Console.WriteLine("Passwords match");
                }
                else
                {
                    Console.WriteLine("Password mismatch. Please try again");
                    SetPassword();
                }

            };
            funcMatch(password, repeatedPassword);

        }

        public static bool CheckCapture()
        {
            int seed = int.Parse(Console.ReadLine());
            string captcha = "";
            Random random = new Random(seed);
            for (int i = 0; i < 10; i++)
            {
                int number = random.Next(48, 89);
                captcha += Convert.ToChar(number);
            }
            Console.WriteLine("Repeat code: " + captcha);
            FuncMatch funcMatch = (a, b) =>
            {
                if (a == b)
                {
                    Console.WriteLine("Success");
                    return true;
                }
                Console.WriteLine("Error");
                return false;

            };
            return(funcMatch(Console.ReadLine(), captcha));
        }

    }
}
