using Console_Schoolbib;
using System;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Studenten_selfserviceApp

{
    /*Console Applicatie
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
        StudentRepository studentRepository = new StudentRepository();
        SchoolbibDBContext schoolbibDBContext = new SchoolbibDBContext();
        static void Main(string[] args)
        {
            StudentRepository studentRepository = new StudentRepository();
            LibraryRepository libraryRepository = new LibraryRepository();
            LoansRepository loansRepository = new LoansRepository();

            Console.WriteLine("################");
            Console.WriteLine("# de schoolbib #");
            Console.WriteLine("################");

            Console.WriteLine("Druk op toets om door te gaan.");
            Console.ReadKey();

            LoginInterface login = new LoginInterface();
            login.ShowLoginInterface();

            SelfServiceInterface selfService = new SelfServiceInterface();
            selfService.ShowSelfService();
            
           //"a. Boek Lenen"
           //"b. Boek Inleveren "
           //"c. Overzicht van ontlening bekijken"
           //"d. Ontlening verlengen"
           //"e. Boetes betalen"
            char choice = Convert.ToChar(Console.ReadLine().ToLower());
            do
            {
            switch (choice)
            {
                case 'a': selfService.LoanBook(login.LoggedStudent);break;
                case 'b': selfService.ReturnBook(); break;
                case 'c': selfService.getLoans(); break;
                case 'd': selfService.ExtendLoan(); break;
                case 'e': selfService.PayFine(); break;
                
            }
            } while (choice != 'x');






            Console.ReadKey();
        }
    }
}
