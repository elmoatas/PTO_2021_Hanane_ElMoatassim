using Console_Schoolbib;
using System;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Studenten_selfserviceApp.Interface
{
    class AllLoans: SelfServiceInterface
    {
        LoansRepository loansRepository = new LoansRepository();

        public AllLoans(Students loggedStudent) : base(loggedStudent)
        {
        
            LoggedStudent = loggedStudent;
        }

       

        internal void GetLoans()
        {
            Console.WriteLine("Lijst van uitgeleende Boeken");
            Console.WriteLine("================" + Environment.NewLine);
            foreach (Loans item in loansRepository.GetLoansOfStudent(LoggedStudent.Id))
            {
               
                Console.WriteLine($"ID: {item.itemId} - Titel: {item.ItemTitle} - Auteur: {item.ItemCreator} - uitgeleend op: {item.LoanDate.ToShortDateString()}" +
                    $"- {item.GetReturnDate()}  ");
            }
            Console.Write("Enter om terug naar menu te gaan.");
            Console.ReadKey();
        }
    }
}
