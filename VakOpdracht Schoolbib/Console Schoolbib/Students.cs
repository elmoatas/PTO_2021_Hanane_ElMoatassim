using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Schoolbib
{
    class Students
    {
        string firstName;
        string familyName;
        int studentnumber;
        List<int> AllStudentNumbers = new List<int>();
        public Students()
        {

        }
        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public int Studentnumber { get => studentnumber; set => studentnumber = value; }
        public List<int> AllStudentNumbers1 { get => AllStudentNumbers; set => AllStudentNumbers = value; }
    }
}
