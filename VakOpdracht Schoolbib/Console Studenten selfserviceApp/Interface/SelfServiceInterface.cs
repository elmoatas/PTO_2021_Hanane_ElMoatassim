using System;
using System.Collections.Generic;
using System.Text;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Schoolbib
{
//    Boeken inleveren &uitlenen
//Een boek wordt normaal gezien gescanned.Dit kan je simuleren aan de hand van het id van een
//boek in te typen.
//Overzicht van alle ontleningen bekijken
//Een ontlening verlengen
//Een ontlening kan slechts 1 maal verlengd worden.
//Boetes betalen
//Een student kan geen nieuwe ontleningen doen wanneer deze een boete heeft.
//De student moet zijn boete kunnen betalen aan de terminal. De volledige betaling hoef je niet te
//implementeren.Implementeer wel een manier om aan te geven dat de student betaald heeft.*/
    class SelfServiceInterface
    {//inloggen aan de hand van selfservice 
     //
        LibraryRepository libraryRepository = new LibraryRepository();
        LoansRepository loansRepository = new LoansRepository();
        internal SelfServiceInterface()
        {

        }
        internal void ShowSelfService()
        {
            Console.WriteLine("Welkom");
            Console.WriteLine("a. Boek Lenen");
            Console.WriteLine("b. Boek Inleveren ");
            Console.WriteLine("c. Overzicht van ontlening bekijken");
            Console.WriteLine("d. Ontlening verlengen");
            Console.WriteLine("e. Boetes betalen");
            Console.WriteLine("x. exit");



        }
        internal void LoanBook(Students student)
        {
            Console.WriteLine("#################");
            Console.WriteLine("# BOEK UITLENEN #");
            Console.WriteLine("#################" + Environment.NewLine);

            Console.WriteLine($"geef het ISBN nummer vanm het boek dat je wilt uitlenen.");
            Console.WriteLine($"ISBN:");
            long ISBN = Convert.ToInt64( Console.ReadLine());
            Books bookChoice = libraryRepository.GetBookWithISBN(ISBN);
            Console.WriteLine($"wil je {bookChoice.Title} - {bookChoice.Creator} uitlenen (J/N): ");
            string choice = Console.ReadLine().ToUpper();
            if ( choice == "J")
            {
                Loans newLoan = new Loans();
                newLoan.StudentId = student.Id;
                newLoan.LoanDate = DateTime.UtcNow;
                newLoan.itemId = bookChoice.LibraryId;
                loansRepository.CreateLoan(newLoan);
                bookChoice.Availability = AvailabilityItem.Uitgeleend;
                //UpdateLoans
            }
            else if (choice == "N") // nieuwe keuze maken
            {

            }
            else
            {
                Console.WriteLine(" Invroer verkeerd: probeer opnieuw");
            }

            Console.Write("Enter om terug naar menu te gaan.");
            Console.ReadLine();
        }
        internal void ReturnBook()
        {
            Console.WriteLine("#################");
            Console.WriteLine("# BOEK inleveren #");
            Console.WriteLine("#################" + Environment.NewLine);

            Console.WriteLine($"Lijst van huidige boeken");
            //FOREACH ITEM IN LIJST = TONEN ( in loans where availability = uitgeleend en where studentid. die van huidige student)

            Console.WriteLine($"Geef het ISBN nummer van het boek dat je wilt terugbrengen.");
            long ISBN = Convert.ToInt64(Console.ReadLine());
            Books bookChoice = libraryRepository.GetBookWithISBN(ISBN);
            Console.WriteLine($"wil je {bookChoice.Title} - {bookChoice.Creator} terugbrengen (J/N): ");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "J")
            {
                bookChoice.Availability = AvailabilityItem.Aanwezig;
                //UpdateLoans
            }
            else if (choice == "N") // nieuwe keuze maken
            {
              
            }
            else
            {
                Console.WriteLine(" Invroer verkeerd: probeer opnieuw");
            }
         
        }
        internal void getLoans()
        {

        }
        internal void ExtendLoan()
        {

        }
        internal void PayFine()
        {

        }

    }
}
