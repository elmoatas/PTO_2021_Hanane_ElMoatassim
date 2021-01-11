using System;
using System.Collections.Generic;
using System.Text;

namespace Commuting
{
    class Train: Commute
    {
       
        double prijs;
        public Train(string from, string to, string date, double prijs) : base(from, to, date)
        {
            this.prijs = prijs;
        }

        public double Prijs { get => prijs; set => prijs = value; }
    }
}
