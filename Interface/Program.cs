using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Александр", "Андрей", "Анастасия",
                "Ирина", "Наталья", "Павел", "Роман",
                "Светлана", "Сергей", "Татьяна" };
            Random rand = new Random();
            Random rand2 = new Random();
            Human[] people = {new Noob(names, rand, rand2), new Advanced(names, rand, rand2),
                              new Veteran(names, rand, rand2), new Advanced(names, rand, rand2),
                              new Noob(names, rand, rand2), new Advanced(names, rand, rand2),
                              new Veteran(names, rand, rand2)};
            for (int i = 1; i < people.Length; i++)
            {
                bool Chance = people[i].Shoot();
                Console.WriteLine(people[i].Name + ": " + Chance);
                if (Chance)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }

    
    public abstract class Human
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        protected int age;
        public int Age { get { return age; } set { age = value; } }
        protected int experience;
        protected Random random = new Random();

        public abstract bool Shoot();
    }
    
    public class Noob: Human
    {
        public Noob(string[] names, Random rand, Random rand2)
        {
            this.name = names[rand2.Next(names.Length)];
            this.age = rand.Next(20, 41);
            this.experience = rand.Next(1, 10);
        }
        public override bool Shoot()
        {
            if (random.NextDouble() <= 0.01 * this.experience){
                return true;
            }
            return false;
        }
    }

    public class Advanced: Human
    {
        public Advanced(string[] names, Random rand, Random rand2)
        {
            this.name = names[rand2.Next(names.Length)];
            this.age = rand.Next(20, 41);
            this.experience = rand.Next(10, 20);
        }
        public override bool Shoot()
        {
            if (random.NextDouble() <= 0.05 * this.experience)
            {
                return true;
            }
            return false;
        }
    }
    public class Veteran: Human
    {
        public Veteran(string[] names, Random rand, Random rand2)
        {
            this.name = names[rand2.Next(names.Length)];
            this.age = rand.Next(30, 51);
        }
        public override bool Shoot()
        {
            if (random.NextDouble() <= 0.9 - 0.01 * this.age)
            {
                return true;
            }
            return false;
        }
    }

    
}
