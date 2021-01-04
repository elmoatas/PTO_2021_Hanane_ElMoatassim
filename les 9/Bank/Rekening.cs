using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    //Gebruik een abstracte klasse voor rekening en maak hiervan 2 afgeleide klassen: Zichtrekening & Spaarrekening
    abstract class Rekening
    {
        // Private members
        List<double> verrichtingen = new List<double>();
        string naam;

        // Constructor 
        public Rekening(string naam)
        {
            this.naam = naam;
        }
        // menu tonen 
        // geven van totaalsaldo
        // actie uitvoeren 
        internal abstract void ToonMenu();
    

        internal string Print()
        {
            return $"rekening {naam}: {BerekenTotaalSaldo()}";
        }

        internal abstract void VoerActieUit(char keuze);
      

        protected void ToonVerrichting()
        {
            Console.WriteLine("Een lijst van verrichtingen");
        }

        protected void GeldAfhalen()
        {

            Console.WriteLine("Hoeveel wil je afhalen?");
            double bedrag = Convert.ToDouble(Console.ReadLine());
            bedrag = Math.Round(bedrag, 2);

            if (bedrag > BerekenTotaalSaldo())
            {
                Console.WriteLine("Saldo ontoereikend op rekening " + naam);
            }
            else
            {
                verrichtingen.Add(-bedrag);
                Console.WriteLine("afhaling OK: " + bedrag + " afgehaald van rekening " + naam);
                ToonSaldo();
            }
        }

        protected void GeldStorten()
        {
            Console.WriteLine("Hoeveel wil je storten?");

            double bedrag = Convert.ToDouble(Console.ReadLine());
            bedrag = Math.Round(bedrag, 2);
            verrichtingen.Add(bedrag);

            Console.WriteLine("Storting OK: " + bedrag + " gestort op rekening " + naam);
            ToonSaldo();
        }

        protected void ToonSaldo()
        {
            Console.WriteLine($"Uw saldo bedraagt: {BerekenTotaalSaldo()}");
        }

        private double BerekenTotaalSaldo()
        {
            double totaalSaldo = 0;

            foreach (double verrichting in verrichtingen)
            {
                totaalSaldo += verrichting;
            }

            return totaalSaldo;
        }

        public bool OverschrijvenNaar(Rekening rekening, double bedrag)
        {
            if (BerekenTotaalSaldo() < bedrag)
            {
                return false;
            }
            bedrag = Math.Round(bedrag, 2);
            verrichtingen.Add(-bedrag);

            rekening.GeldStorten(bedrag);
            return true;
        }

        public void GeldStorten(double bedrag)
        {
            verrichtingen.Add(bedrag);
        }
    }
}
