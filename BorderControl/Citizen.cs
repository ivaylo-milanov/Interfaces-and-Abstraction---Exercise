using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICreature, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
            Food = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }

        public void GetBirthdate(string year)
        {
            string curYear = Birthdate.Split('/')[2];

            if (year == curYear)
            {
                Console.WriteLine(Birthdate);
            }
        }

        public void isFake(string lastDigits)
        {
            string substring = ID.Substring(ID.Length - lastDigits.Length
                , lastDigits.Length);

            if (substring == lastDigits)
            {
                Console.WriteLine(ID);
            }
        }
    }
}
