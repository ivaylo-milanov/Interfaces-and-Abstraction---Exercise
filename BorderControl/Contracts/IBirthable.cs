using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IBirthable
    {
        string Birthdate { get; set; }
        void GetBirthdate(string year);
    }
}
