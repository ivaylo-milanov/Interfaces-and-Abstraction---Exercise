using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            Birthdate = birthDate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }

        public void GetBirthdate(string year)
        {
            string curYear = Birthdate.Split('/')[2];

            if (year == curYear)
            {
                Console.WriteLine(Birthdate);
            }
        }
    }
}
