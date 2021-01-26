using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WPF_Schoolbib.Models
{
    //RESPONSIBILITY => Database Operaties
    public class StudentRepository
    {
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
        public StudentRepository()
        {
           // dbContext.Database.CreateIfNotExists();
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
        public Students GetUserWith(int IDnumber)
        {
        
            return (from Students in dbContext.Students
                    where Students.Id == IDnumber
                    select Students).First();
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
