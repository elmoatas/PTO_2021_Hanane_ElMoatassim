using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WPF_Schoolbib.Models
{
    //RESPONSIBILITY => Database Operaties
    class StudentRepository
    {
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
        public StudentRepository()
        {
            dbContext.Database.CreateIfNotExists();
        }

        //CREATE == insert 
        public void CreateStudent(Students students)
        {
            dbContext.Students.Add(students);
            dbContext.SaveChanges();
        }
        //Read ==Select 
        public List<Students> GetAllStudents()
        {
            List<Students> allStudents = dbContext.Students.ToList();
            return allStudents;
        }
        public List<Library> GetAllLoanedItems(Students student)
        {
            List<Library> allLoans = student.LibraryItem.ToList();
            //List<Books> books = dbContext.Books.Where((st) => st.Id == student.Id).ToList();
            //List<CD> cd = dbContext.CDs.Where((st) => st.Id == student.Id).ToList();
            //List<DVD> dvd = dbContext.DVDs.Where((st) => st.Id == student.Id).ToList();
            //List<Library> allLoans = new List<Library>();
            //allLoans.AddRange(books);
            //allLoans.AddRange(cd);
            //allLoans.AddRange(dvd);
            return allLoans;
        }
        //Update
        public void UpdateStudent(Students students)
        {
            dbContext.SaveChanges();
        }
        //Delete
        public void DeleteStudent(Students students)
        {
            dbContext.Entry(students).State = EntityState.Deleted;
            dbContext.Students.Remove(students);
            dbContext.SaveChanges();
        }
    }
}
