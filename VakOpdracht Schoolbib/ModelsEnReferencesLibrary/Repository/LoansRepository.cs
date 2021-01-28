using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WPF_Schoolbib.Models
{

    public class LoansRepository
    {
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
        public LoansRepository()
        {
        }
        //CREATE == insert 
        public void CreateLoan(Loans loan)
        {

            //dbContext.LibraryItems.Attach(loan.LoanedItem);
            //dbContext.Students.Attach(loan.Student);
            dbContext.Loans.Add(loan);
            dbContext.SaveChanges();
        }
        //Read 
        public List<Loans> GetLoansOfStudent(int selectedStudentID)
        {
            List<Loans> allLoansOfSelectedStudent = dbContext.Loans.Where((l) => l.StudentId == selectedStudentID).ToList();
            return allLoansOfSelectedStudent;
        }
     
        public List<Loans> GetOnlyLentLoans(int selectedStudentID)
        {
            List<Loans> allLoansOfSelectedStudent = dbContext.Loans.Where((l) => l.StudentId == selectedStudentID).ToList();
            foreach (Loans loan in allLoansOfSelectedStudent)
            {
                if (loan.ReturnDateString != DateTime.MinValue.ToString()) 
                {
                    allLoansOfSelectedStudent.Remove(loan);
                }
            }
            return allLoansOfSelectedStudent;
        }
        public Loans GetLoanWith(int loanID, int itemID)
        {
            return(from Loans in dbContext.Loans
                  where Loans.ID == loanID &&
                  Loans.itemId == itemID 
                  select Loans).First();
        }
        public Loans GetLoanWithLoanID(int loanID)
        {
            return (from Loans in dbContext.Loans
                    where Loans.ID == loanID
                    select Loans).First();
        }

      
        //Update
        public void UpdateLoan(Loans loan)
        {
            dbContext.Entry<Loans>(loan).State = EntityState.Modified;
            dbContext.SaveChanges();
        }


    }
}
