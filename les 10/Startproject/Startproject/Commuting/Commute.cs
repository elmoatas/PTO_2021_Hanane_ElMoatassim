using System;
using System.Collections.Generic;
using System.Text;

namespace Commuting
{
    public class Commute
    {
        string from;
        string to;
        string date;
        double prijs;

        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Date { get => date; set => date = value; }

        public Commute(string from, string to, string date)
        {
            this.from = from;
            this.to = to;
            this.date = date;
        }

     
        private void CalculateTotalPrice()
        {
            
        }

        public override string ToString()
        {
            return from + to + date;
        }
    }
  
}
