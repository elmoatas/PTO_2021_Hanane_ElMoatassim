using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {

        private static List<Rekening> zichtrekeningen = new List<Rekening>();
        private static List<SpaarRekening> spaarRekeningen = new List<SpaarRekening>();

        static void Main(string[] args)
        {
            char keuze;

            do
            {
                Console.Clear();
                Console.WriteLine("#######################");
                Console.WriteLine("# Welkom bij de bank! #");
                Console.WriteLine("#######################");

                Console.WriteLine("a. Nieuwe rekening aanmaken.");
                Console.WriteLine("b. Rekening kiezen. ");
                Console.WriteLine("c. Overschrijven.");
                Console.WriteLine("d. Afsluiten");
                keuze = Convert.ToChar(Console.ReadKey().KeyChar.ToString().ToLower());
                Console.WriteLine();
                VoerActieUit(keuze);
            } while (keuze != 'd');

            Console.WriteLine(" Bedankt en tot ziens!");
            Console.ReadKey();
        }

        private static void VoerActieUit(char keuze)
        {
            if (keuze == 'a')
            {
                aanmakenRekening();
            }
            else if (keuze == 'b')
            {
                kiezenRekening();
            }
            else if (keuze == 'c')
            {
                geldStorten();
            }

        }

        private static void geldStorten()
        {
            Console.WriteLine("Kies een zender?");
            PrintRekeningen();
            int rekeningKeuze = Convert.ToInt32(Console.ReadLine());
            Rekening zender;
            if (rekeningKeuze > zichtrekeningen.Count)
            {
                zender = spaarRekeningen[rekeningKeuze - zichtrekeningen.Count - 1];
            }
            else
            {
                zender = zichtrekeningen[rekeningKeuze - 1];
            }

            Console.WriteLine("Kies een ontvanger?");
            PrintRekeningen();
            rekeningKeuze = Convert.ToInt32(Console.ReadLine());
            Rekening ontvanger;
            if (rekeningKeuze > zichtrekeningen.Count)
            {
                ontvanger = spaarRekeningen[rekeningKeuze - zichtrekeningen.Count - 1];
            }
            else
            {
                ontvanger = zichtrekeningen[rekeningKeuze - 1];
            }

            Console.WriteLine("Welk bedrag wil je verzenden?");
            double bedrag = Convert.ToDouble(Console.ReadLine());

            zender.OverschrijvenNaar(ontvanger, bedrag);
        }

        private static void PrintRekeningen()
        {

            int rekeningCounter = 0;
            Console.WriteLine("Zichtrekeningen:");
            Console.WriteLine("----------------:");

            foreach (Rekening rekening in zichtrekeningen)
            {
                rekeningCounter++;
                Console.WriteLine($"   {rekeningCounter}) {rekening.Print()}");
            }

            Console.WriteLine("Spaarrekeningen:");
            Console.WriteLine("----------------:");

            foreach (Rekening rekening in spaarRekeningen)
            {
                rekeningCounter++;
                Console.WriteLine($"   {rekeningCounter}) {rekening.Print()}");
            }

        }

        private static void kiezenRekening()
        {
            Console.WriteLine("welke rekening wil je gebruiken? ");
            PrintRekeningen();
            //voor elke rekening een apparte variabele maken van saldo?

            int rekeningKeuze = Convert.ToInt32(Console.ReadLine());


            if (rekeningKeuze > zichtrekeningen.Count)
            {
                spaarRekeningen[rekeningKeuze - zichtrekeningen.Count - 1].ToonMenu();
            }
            else
            {
                zichtrekeningen[rekeningKeuze - 1].ToonMenu();
            }

        }

        private static void aanmakenRekening()
        {
            Console.WriteLine("Welk type rekening wil je maken?");
            Console.WriteLine("a) zichtrekening");
            Console.WriteLine("b) spaarrekening");

            string rekeningType = Console.ReadLine();

            Console.WriteLine("Welke naam wil je de rekening geven?");
            string naam = Console.ReadLine();

            if (rekeningType == "a")
            {
                Rekening nieuweRekening = new ZichtRekening(naam);
                zichtrekeningen.Add(nieuweRekening);
            }
            else
            {
                SpaarRekening nieuweRekening = new SpaarRekening(naam);
                spaarRekeningen.Add(nieuweRekening);
            }
        }
    }
}
