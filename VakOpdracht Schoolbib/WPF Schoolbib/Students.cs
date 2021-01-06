using System.Collections.Generic;

namespace WPF_Schoolbib
{
    public class Students
    {

        string firstName;
        string lastName;
        int iD;
        List<int> allStudentNumbers = new List<int>();
        public Students()
        {

        }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int ID { get => iD; set => iD = value; }
        public List<int> AllStudentNumbers { get => allStudentNumbers; set => allStudentNumbers = value; }

    }
}
