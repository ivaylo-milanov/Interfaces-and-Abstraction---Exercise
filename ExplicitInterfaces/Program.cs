using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        private static IResident resident;
        private static IPerson person;
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);
                resident = citizen;
                person = citizen;

                person.GetName();
                resident.GetName();
            }
        }
    }
}
