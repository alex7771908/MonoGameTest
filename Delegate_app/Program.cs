using System;

namespace Example
{
    // 1. Тут нужно объявить тип делегата

    public delegate void MyAction();


    public class Program
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero();

            hero.action = Hello;

            hero.Start();

            Console.ReadLine();
        }

        public static void Hello()
        {
            Console.WriteLine("Hero, hello!");
        }
    }

    public class Hero
    {
        public MyAction action;
        public Hero()
        {

        }

        public void Start()
        {
            action();    
        }
    }
}
