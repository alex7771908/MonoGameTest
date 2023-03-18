using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Category[] categories = new Category[3];
            for(int i = 0; i < 3; i++)
            {
                Category category = new Category();
                categories[i] = category;
            }    
            User user = new User();
        }
    }

    public class Item
    {
        int price;
        string name;
        float rating;

        public string Name { get { return name; } }
    }
    public class Category
    {
        string name;
        Item[] items;

        public Item[] Items { get { return items; } }
    }

    public class Basket
    {
        List<Item> boughtItems;

        public List<Item> BoughtItems { get { return boughtItems; } set { this.boughtItems = value} }
    }

    public class User
    {
        string login;
        string password;
        Basket basket = new Basket();
        public void Authentification()
        {
            login = Console.ReadLine();
            password = Console.ReadLine();
        }
        public void Catalogue(Category[] categories)
        {
            foreach(Category category in categories)
            {
                foreach (Item item in category.Items)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
        public void CategoryItems(Category category)
        {
            foreach(Item item in category.Items)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void ChooseItem(Item item)
        {
            basket.BoughtItems.Add(item);
        }


    }
}
