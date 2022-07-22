using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var creatures = new List<IBuyer>();
            IBuyer creature = null;

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    creature = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    string group = tokens[2];

                    creature = new Rebel(name, age, group);
                }

                creatures.Add(creature);
            }

            while (true)
            {
                string buyer = Console.ReadLine();

                if (buyer == "End")
                {
                    break;
                }

                IBuyer curBuyer = creatures.FirstOrDefault(x => x.Name == buyer);

                if (curBuyer != null)
                {
                    curBuyer.BuyFood();
                }
            }

            int boughtFood = creatures.Sum(x => x.Food);

            Console.WriteLine(boughtFood);
        }
    }
}
