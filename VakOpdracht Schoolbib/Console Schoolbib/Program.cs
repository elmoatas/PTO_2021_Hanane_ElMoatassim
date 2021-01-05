using System;

namespace Console_Schoolbib
{ /*Console Applicatie
De console applicatie is een self - service applicatie voor studenten.
Studenten kunnen inloggen door hun studentenkaart in een kaartlezer te plaatsen. Die mag je simuleren door
gewoon in te loggen aan de hand van een studentennummer.
Eenmaal ingelogd kunnen studenten volgencties de aondernemen:
            Boeken inleveren &uitlenen
Een boek wordt normaal gezien gescanned. Dit kan je simuleren aan de hand van het id van een
boek in te typen.
Overzicht van alle ontleningen bekijken
Een ontlening verlengen
Een ontlening kan slechts 1 maal verlengd worden.
Boetes betalen
Een student kan geen nieuwe ontleningen doen wanneer deze een boete heeft.
De student moet zijn boete kunnen betalen aan de terminal. De volledige betaling hoef je niet te
implementeren.Implementeer wel een manier om aan te geven dat de student betaald heeft.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("################");
            Console.WriteLine("# de schoolbib #");
            Console.WriteLine("################");
            Console.WriteLine("Log in aan de hand van je studentennummer.");
            Console.WriteLine("studentennummer: ");

            Console.WriteLine("Welkom Naam");
            Console.WriteLine("a. Boek Lenen");
            Console.WriteLine("b. Boek Inleveren ");
            Console.WriteLine("c. Overzicht van ontlening bekijken");
            Console.WriteLine("d. Ontlening verlengen");
            Console.WriteLine("e. Boetes betalen");

        }
    }
}
