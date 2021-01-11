using System;
using System.Collections.Generic;
using System.Text;

namespace Commuting
{
    class Car:Commute
    {
        const double tarief = 0.25;
        double km;
        double price;
        public Car(string from, string to, string date, double km) : base(from, to, date)
        {
            this.km = km;
            CalculatePrice();
        }

        public double Price { get => price; set => price = value; }

        private void CalculatePrice()
        {
            price = km * tarief;
        }
    }
}
