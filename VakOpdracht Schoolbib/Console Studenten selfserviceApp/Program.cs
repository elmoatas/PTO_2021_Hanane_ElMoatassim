using Console_Schoolbib;
using Console_Studenten_selfserviceApp.Interface;
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
            //Open login interface
            login.ShowLoginInterface();
             
            //openselfservice
            LoanBookInterface loanBookInterface = new LoanBookInterface(login.LoggedStudent);
            ReturnInterface returnInterface = new ReturnInterface(login.LoggedStudent);
            AllLoans allLoans = new AllLoans(login.LoggedStudent);
            PayFines payFines = new PayFines(login.LoggedStudent);
            char choice;
           
            do
            {
            Console.Clear();
            Console.WriteLine("###############");
            Console.WriteLine("# Selfservice #");
            Console.WriteLine("###############" + Environment.NewLine);
            Console.WriteLine($"Welcome {login.LoggedStudent.FirstName} {login.LoggedStudent.LastName}!");
            Console.WriteLine("a. Boek Lenen");
            Console.WriteLine("b. Boek Inleveren ");
            Console.WriteLine("c. Overzicht van ontlening bekijken");
            Console.WriteLine("d. Ontlening verlengen");
            Console.WriteLine("e. Boetes betalen");
            Console.WriteLine("x. exit");
            Console.Write("Maak je keuze:");

            choice = Convert.ToChar(Console.ReadLine().ToLower());
           
                switch (choice)
                {
                    case 'a': loanBookInterface.ShowLoanBookInterface(); break;
                    case 'b': returnInterface.ReturnBook(); break;
                    case 'c': allLoans.GetLoans(); break;
                    //case 'd': .ExtendLoan(); break;
                    case 'e': payFines.ShowFines(); break;

                }
            } while (choice != 'x');






            Console.ReadKey();
        }
  
    }
}
