using System;
using System.Collections.Generic;

namespace Spaarrekening
{
    class Program
    {



        private static List<Rekening> rekeningen = new List<Rekening>();
        private static List<Saving> spaarrekening = new List<Saving>();


        static void Main(string[] args)
        {
            Console.WriteLine("#######################");
            Console.WriteLine("# Welkom bij de bank! #");
            Console.WriteLine("#######################");

            char keuze;

            do
            {
                Console.WriteLine("a. Nieuwe rekening aanmaken.");
                Console.WriteLine("b. zichtrekening kiezen. ");
                Console.WriteLine("c. spaarrekening kiezen. ");
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
                Rekening rekening = kiezenRekening();
                rekening.ToonMenu();
            }
            else if (keuze == 'c')
            {
                Saving spaarrekening = kiezenSpaarrekening();
                spaarrekening.ToonMenu();
            }
        }
        private static Saving kiezenSpaarrekening()
        {
            //voor elke rekening een apparte variabele maken van saldo?
            Console.WriteLine("welke rekening wil je gebruiken? ");

            int rekeningCounter = 0;
            foreach (Saving rekening in spaarrekening)
            {
                rekeningCounter++;
                Console.WriteLine($"{rekeningCounter}) {rekening.Print()}");
            }
            int rekeningKeuze = Convert.ToInt32(Console.ReadLine());

            return spaarrekening[rekeningKeuze - 1];

        }
        private static Rekening kiezenRekening()
        {
            //voor elke rekening een apparte variabele maken van saldo?
            Console.WriteLine("welke rekening wil je gebruiken? ");

            int rekeningCounter = 0;
            foreach (Rekening rekening in rekeningen)
            {
                rekeningCounter++;
                Console.WriteLine($"{rekeningCounter}) {rekening.Print()}");
            }
            int rekeningKeuze = Convert.ToInt32(Console.ReadLine());

            return rekeningen[rekeningKeuze - 1];

        }

        private static void aanmakenRekening()
        {
            Console.WriteLine("Welke naam wil je de rekening geven?");
            string naam = Console.ReadLine();
            Console.WriteLine(" Is het een zichtrekening (z) of een spaarrekening(s)?");
            char soortrekening = Convert.ToChar(Console.ReadKey().KeyChar.ToString().ToLower());
            if (soortrekening == 'z')
            {
                Rekening nieweRekening = new Rekening(naam);
                rekeningen.Add(nieweRekening);
            }
            if (soortrekening == 's')
            {
                Saving nieuwespaarrekening = new Saving(naam);
                spaarrekening.Add(nieuwespaarrekening);
            }

        }
    }
}

