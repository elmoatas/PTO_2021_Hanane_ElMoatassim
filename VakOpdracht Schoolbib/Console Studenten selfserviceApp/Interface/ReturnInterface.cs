using Console_Schoolbib;
using System;
using System.Collections.Generic;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Studenten_selfserviceApp.Interface
{
    class ReturnInterface : SelfServiceInterface
    {
        LibraryRepository libraryRepository = new LibraryRepository();
        LoansRepository loansRepository = new LoansRepository();
        public ReturnInterface(Students loggedStudent) : base(loggedStudent)
        {
            LoggedStudent = loggedStudent;
        }

        internal void ReturnBook()
        {
            Console.WriteLine("#################");
            Console.WriteLine("# BOEK inleveren #");
            Console.WriteLine("#################" + Environment.NewLine);


            List<Library> listOfLoans = libraryRepository.GetbookItemsLoanedBy(LoggedStudent);

            if (listOfLoans.Count == 0)
            {
                Console.WriteLine("Er zijn geen boeken uitgeleend!");
                Console.Write("Enter om terug naar menu te gaan.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Lijst van uitgeleende Boeken");
                Console.WriteLine("================" + Environment.NewLine);
                foreach (Library item in listOfLoans)
                {
                    Console.WriteLine($"LeningID {item.LibraryId} - Titel: {item.Title} - Auteur: {item.Creator}");

                }
                Console.WriteLine($"Geef het ID van het boek dat je wilt terugbrengen.");
                int ID = Convert.ToInt32(Console.ReadLine());
                Library bookChoice = libraryRepository.GetItemWith(ID);
                Loans loan = loansRepository.GetLoanWith(ID, LoggedStudent.Id);
                loan.ReturnDateString = DateTime.UtcNow.ToShortDateString();
                loansRepository.UpdateLoan(loan);

                bookChoice.LoanerID = 0;
                if (bookChoice.ReserveStudentID != -1)
                {
                    bookChoice.Availability = AvailabilityItem.GereserveerdAanwezig;
                }
                else
                {
                    bookChoice.Availability = AvailabilityItem.Aanwezig;
                }
                libraryRepository.UpdateLibraryItems(bookChoice);


                Console.WriteLine($"Je hebt volgend item teruggebracht: {bookChoice.Title}.");
                Console.Write("Enter om terug naar menu te gaan.");
                Console.ReadKey();

            }



        }
        private void ShowLoans()
        {

        }
    }
}
