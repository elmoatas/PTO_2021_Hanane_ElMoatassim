using Console_Schoolbib;
using System;
using System.Collections.Generic;
using System.Linq;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Studenten_selfserviceApp.Interface
{
    class LoanBookInterface : SelfServiceInterface
    {
        LibraryRepository libraryRepository = new LibraryRepository();
        LoansRepository loansRepository = new LoansRepository();


        public LoanBookInterface(Students loggedStudent):base(loggedStudent)
        {
            LoggedStudent = loggedStudent;
        }
        internal void ShowLoanBookInterface()
        {
            char choice;
            do
            {
                Console.Clear();
                Console.WriteLine("#################");
                Console.WriteLine("# BOEK UITLENEN #");
                Console.WriteLine("#################" + Environment.NewLine);

                Console.WriteLine($" a. Gereserveerd boek uitlenen.");
                Console.WriteLine($" b. Een overzicht van de boeken die aanwezig zijn.");
                Console.WriteLine($" c. Meteen het ID nummer van boek ingeven.");
                Console.WriteLine($" d. Terug naar selfservice" + Environment.NewLine);

                Console.Write("Maak je keuze:");
                choice = Convert.ToChar(Console.ReadLine().ToLower());
                switch (choice)
                {
                    case 'a': ShowReservedBooksBy(); break;
                    case 'b': ShowAllAvailableBooks(); break;
                    case 'c': LoanwithID(); break;
                    default: Console.WriteLine("Ongeldige invoer!"); break;
                }

            } while (choice != 'd');

        }

        private void ShowAllAvailableBooks()
        {
            Console.Clear();
            List<Library> listOfBooks = libraryRepository.GetBooksBasedOnAvailability(AvailabilityItem.Aanwezig);
            if (!listOfBooks.Any())
            {
                Console.WriteLine("Er zijn geen boeken!");
                Console.Write("Enter om terug naar menu te gaan.");
                Console.ReadKey();
                ShowLoanBookInterface();
            }
            else
            {
                Console.WriteLine("Lijst Van Boeken");
                Console.WriteLine("================" + Environment.NewLine);
                foreach (Library item in listOfBooks)
                {
                    Console.WriteLine($"ID: {item.LibraryId} - Titel: {item.Title} - Auteur: {item.Creator} ");
                }
                LoanwithID();
            }
        }

        private void ShowReservedBooksBy()
        {
            Console.Clear();
            List<Library> reservedBooks = new List<Library>();
            foreach (Books book in libraryRepository.GetListItemReservedBy(LoggedStudent))
            {
                if (book.Availability == AvailabilityItem.GereserveerdAanwezig)
                {
                    reservedBooks.Add(book);
                }
            }

            if (!reservedBooks.Any())
            {
                Console.WriteLine($"Er zijn geen gereserveerde Items");
                Console.Write("Enter om terug naar menu te gaan.");
                Console.ReadKey();
                ShowLoanBookInterface();
            }
            else
            {
                Console.WriteLine("Lijst Van gereserveerde boeken");
                Console.WriteLine("================" + Environment.NewLine);
                foreach (Library item in reservedBooks)
                {
                    Console.WriteLine($"{item.LibraryId} - Titel: {item.Title} - Auteur: {item.Creator} ");
                }
            }
        }


        private void LoanwithID()
        {
            Console.WriteLine($"Geef het ID nummer van het boek dat je wilt uitlenen.");
            Console.Write($"ID:");

            int ID = Convert.ToInt32(Console.ReadLine());
            Library bookChoice = libraryRepository.GetItemWith(ID);

            Console.WriteLine($"wil je {bookChoice.Title} - {bookChoice.Creator} uitlenen (J/N): ");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "J")
            {
                Loans newLoan = new Loans();
                newLoan.StudentId = LoggedStudent.Id;
                newLoan.LoanDate = DateTime.UtcNow;
                newLoan.itemId = bookChoice.LibraryId;
                newLoan.ItemTitle = bookChoice.Title;
                newLoan.ItemCreator = bookChoice.Creator;
                newLoan.ItemProductNumber = bookChoice.ProductNumber;
                newLoan.StudentFirstName = LoggedStudent.FirstName;
                newLoan.StudentLastName = LoggedStudent.LastName;
                newLoan.ReturnDateString = "";
                newLoan.FinePayed = true;
                loansRepository.CreateLoan(newLoan);
                bookChoice.Availability = AvailabilityItem.Uitgeleend;
                libraryRepository.UpdateLibraryItems(bookChoice);
                Console.WriteLine($"Je hebt volgende item uitgeleend: {bookChoice.Title} ");
            }
            else if (choice == "N") // nieuwe keuze maken
            {
                ShowLoanBookInterface();
            }
            else
            {
                Console.WriteLine(" Invoer verkeerd: probeer opnieuw");
            }

            Console.Write("Enter om terug naar menu te gaan.");
            Console.ReadKey();
            ShowLoanBookInterface();
        }
    }
}
