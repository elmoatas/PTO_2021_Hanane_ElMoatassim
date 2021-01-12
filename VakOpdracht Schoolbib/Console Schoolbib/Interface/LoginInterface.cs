using System;

namespace Console_Schoolbib
{
    class LoginInterface
    {
        int inputStudentNumber;
        bool numberIsOK;
        public LoginInterface()
        {

        }

        public int InputStudentNumber { get => inputStudentNumber; set => inputStudentNumber = value; }
        public bool NumberIsOK { get => numberIsOK; set => numberIsOK = value; }

        public void ShowLoginInterface()
        {
            Console.Clear();
            Console.WriteLine("Log in aan de hand van je studentennummer.");
            Console.WriteLine("studentennummer: ");
            inputStudentNumber = Convert.ToInt32(Console.ReadLine());
        }
        public void SheckIfStudentNumberOK()
        {
          //if student number is niet gelijk aan een van students.number 
          //dan console writeline nummer is foutief geef een geldige nummer in.
          //check if in list
        }
    }
}
