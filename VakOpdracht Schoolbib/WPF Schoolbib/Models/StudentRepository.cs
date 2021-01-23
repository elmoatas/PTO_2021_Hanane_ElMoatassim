using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;

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
        //Update
        public void UpdateStudent(Students students) 
        {
            dbContext.Students.AddOrUpdate(students);
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
