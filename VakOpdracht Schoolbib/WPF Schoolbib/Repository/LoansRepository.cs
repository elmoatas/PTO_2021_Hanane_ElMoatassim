using System.Collections.Generic;
using System.Linq;

namespace WPF_Schoolbib.Models
{

    public class LoansRepository
    {
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
        public LoansRepository()
        {
            // dbContext.Database.CreateIfNotExists();
        }
        //CREATE == insert 
        public void CreateLoan(Loans loan)
        {

            //dbContext.LibraryItems.Attach(loan.LoanedItem);
            //dbContext.Students.Attach(loan.Student);
            dbContext.Loans.Add(loan);
            dbContext.SaveChanges();
        }
        //Read ==Select 
        public List<Loans> GetLoansOfStudent(Students selectedStudent)
        {
            List<Loans> allLoansOfSelectedStudent = dbContext.Loans.Where((l) => l.StudentId == selectedStudent.Id).ToList();
            //list van loans waarvij student id = aan selectedstudent id
            return allLoansOfSelectedStudent;
        }
        public List<Loans> GetOnlyLentLoans(Students selectedStudent)
        {   
            List<Loans> onlyLentLoans = new List<Loans>();
            onlyLentLoans.Clear();
            foreach (Loans loan in GetLoansOfStudent(selectedStudent))
            {
                if(loan.ItemAvailibility== AvailabilityItem.Uitgeleend) 
                {
                    onlyLentLoans.Add(loan);
                }
            }
            return onlyLentLoans;
        }
        public Loans GetLoanWith(int loanID)
        {
            return (from Loans in dbContext.Loans
                    where Loans.ID == loanID
                    select Loans).First();
        }
        //Update
        public void UpdateLoan(Loans loan)
        {
            dbContext.Entry<Library>(library).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
      

    }
}
