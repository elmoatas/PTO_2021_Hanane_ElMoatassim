using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Schoolbib.Models
{
    
    public class LoansRepository
    {
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
        public LoansRepository()
        {
            dbContext.Database.CreateIfNotExists();
        }
        //CREATE == insert 
        public void CreateLoan(Loans loan)
        {
            dbContext.Loans.Add(loan);
            dbContext.SaveChanges();
        }
        //Read ==Select 
        public List<Loans> GetLoansOfStudent(Students selectedStudent)
        {
            List<Loans> allLoansOfSelectedStudent = dbContext.Loans.Where((l) => l.Student == selectedStudent).ToList();
            //list van loans waarvij student id = aan selectedstudent id
            return allLoansOfSelectedStudent;
        }
        //Update
        public void UpdateLoan(Loans loan)
        {
            dbContext.SaveChanges();
        }
        //Delete

    }
}
