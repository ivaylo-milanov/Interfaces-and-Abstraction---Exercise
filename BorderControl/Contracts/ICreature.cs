using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface ICreature
    {
        string ID { get; set; }
        void isFake(string lastDigits);
    }
}
