using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : ICreature
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }

        public string Model { get; set; }
        public string ID { get; set; }

        public void isFake(string lastDigits)
        {
            int startIndex = ID.Length - lastDigits.Length;
            string substring = ID.Substring(startIndex, lastDigits.Length);

            if (substring == lastDigits)
            {
                Console.WriteLine(ID);
            }
        }
    }
}
