using System;
using System.Linq;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Schoolbib
{
    class LoginInterface
    {
        StudentRepository studentRepository = new StudentRepository();
        SchoolbibDBContext schoolbibDBContext = new SchoolbibDBContext();
      
        public LoginInterface()
        {
          
        }

        public int InputStudentNumber { get; set; }
        public Students LoggedStudent { get; set; }
        public void ShowLoginInterface()
        {
            Console.Clear();
            Console.WriteLine("################");
            Console.WriteLine("# De Schoolbib #");
            Console.WriteLine("################" + Environment.NewLine);
           
            Console.WriteLine("Log in aan de hand van je studentennummer.");
            Console.Write("geef hier je studentennummer in: ");

            SheckIfStudentNumberOK(Convert.ToInt32(Console.ReadLine()));
          
        }
        public void SheckIfStudentNumberOK(int inputNumber)
        {
            foreach (Students student in studentRepository.GetAllStudents() )
            {        
                if (inputNumber == student.Id) 
                {
                    Console.WriteLine($"Welcome {student.FirstName} {student.LastName}");
                    LoggedStudent = studentRepository.GetUserWith(inputNumber);
                }
                else
                {
                    Console.WriteLine("ERROR:Geef een geldige ID nummer in");
                }
            }
        }
    }
}
