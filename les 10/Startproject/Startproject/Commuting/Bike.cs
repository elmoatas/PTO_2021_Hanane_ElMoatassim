using System;
using System.Collections.Generic;
using System.Text;

namespace Commuting
{
    public class Bike: Commute 
    {
        const double tarief = 0.25;
        double km;
        double price;
        public Bike(string from, string to, string date) :base(from, to, date)
        {
            //this.km = km;
            CalculatePrice();
        }

        public double Price { get => price; set => price = value; }

        private void CalculatePrice()
        {
            price = km * tarief;
        }
     
    }

}

