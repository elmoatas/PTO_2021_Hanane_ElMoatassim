using System;

namespace oefening_pyramide
{
    class Program
    {
        static void Main(string[] args)
        {
            int Aantal_lagen = 0;
            int aantal_blokken_perlaag;
            int totaal_aantal_blokken = 0;
            string keuze;
            Console.WriteLine(@"Welke waarde wil je ingeven? 
a) hoogte van de piramide
b) aantal blokken
geef je keuze: ");
            keuze = Console.ReadLine();
            if (keuze == "a")
            {
                Console.WriteLine("hoeveel lagen wil je?");
                Aantal_lagen = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= Aantal_lagen; i++)
                {
                    aantal_blokken_perlaag = i * i;
                    totaal_aantal_blokken += aantal_blokken_perlaag;
                    Console.WriteLine($"laag {i} heeft {aantal_blokken_perlaag} blokken nodig.");
                }
                Console.WriteLine($"in totaal zijn er {totaal_aantal_blokken} blokken nodig voor een piramide met {Aantal_lagen} lagen.");
            }
            else if (keuze == "b")
            {
                Console.WriteLine("hoeveel blokken zijn er?");
                totaal_aantal_blokken = Convert.ToInt32(Console.ReadLine());
                int blokken_over = totaal_aantal_blokken;
                int aantal_blokken_rest = 0;
                while (totaal_aantal_blokken > 0)
                {
                    Aantal_lagen++;
                    aantal_blokken_perlaag = Aantal_lagen * Aantal_lagen;
                    totaal_aantal_blokken -= aantal_blokken_perlaag;
                    if (blokken_over > aantal_blokken_perlaag)
                    {
                        Aantal_lagen--;
                        blokken_over = aantal_blokken_rest;
                    }
                }
                Console.WriteLine($"je kan {Aantal_lagen} lagen maken. met {aantal_blokken_rest}");
            }
            else
            {
                Console.WriteLine("geen geldige keuze");
            }
            Console.ReadKey();
        }
    }
}
