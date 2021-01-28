using System;
using WPF_Schoolbib;
using WPF_Schoolbib.Models;

namespace Console_Schoolbib
{
    class LoginInterface
    {
        StudentRepository studentRepository = new StudentRepository();
  

        public LoginInterface() 
        {

        }

        public int InputStudentNumber { get; set; }
        public Students LoggedStudent { get; set; }

        public void ShowLoginInterface()
        {
            int InputStudentNumber;

            Console.Clear();

            do
            {
                Console.Clear();
                Console.WriteLine("################");
                Console.WriteLine("# De Schoolbib #");
                Console.WriteLine("################" + Environment.NewLine);

                Console.WriteLine("Log in aan de hand van je studentennummer.");
                Console.Write("geef hier je studentennummer in: ");
                
                InputStudentNumber = Convert.ToInt32(Console.ReadLine());

                if (SheckIfStudentNumberOK(InputStudentNumber) == false)
                {
                    Console.WriteLine("ERROR:Geef een geldige ID nummer in");
                    Console.ReadKey();
                }


            } while (SheckIfStudentNumberOK(InputStudentNumber) == false);

             LoggedStudent = studentRepository.GetUserWith(InputStudentNumber);
   

        }

        public bool SheckIfStudentNumberOK(int inputNumber)
        {
            bool ok = false;
            foreach (Students student in studentRepository.GetAllStudents())
            {
                if (inputNumber == student.Id) { ok = true; }
           
            }
            return ok;
        }
    }
}
