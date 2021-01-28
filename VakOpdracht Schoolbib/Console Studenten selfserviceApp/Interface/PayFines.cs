using System;
using System.Collections.Generic;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Studenten_selfserviceApp.Interface
{
    class PayFines
    {
        LoansRepository loansRepository = new LoansRepository();

        public PayFines(Students loggedStudent)
        {
            LoggedStudent = loggedStudent;
        }
        static public Students LoggedStudent { get; set; }
        public void ShowFines()
        {
            Console.WriteLine("####################");
            Console.WriteLine("# OVERZICHT BOETES #");
            Console.WriteLine("####################" + Environment.NewLine);

            List <Loans> allloans= loansRepository.GetLoansOfStudent(LoggedStudent.Id);
            foreach(Loans loan in allloans)
            {
                if (loan.ReturnedOnTime == false && loan.FinePayed == false)
                {
                    Console.WriteLine($"ID: {loan.ID} - Titel: {loan.ItemTitle} - Auteur: {loan.ItemCreator} - Dagen te laat: {loan.Timespan}- Boete: {loan.Fine} € ");
                }
            }
            Console.Write($"Geef de ID van de Boete dat je zou willen betalen:");
            int id = Convert.ToInt32(Console.ReadLine());
            Loans Selectedloan = loansRepository.GetLoanWithLoanID(id);
            Console.WriteLine($" {Selectedloan.Fine} € BETAALD.");
            Selectedloan.FinePayed =true;
            loansRepository.UpdateLoan(Selectedloan);
        }
    }
}
