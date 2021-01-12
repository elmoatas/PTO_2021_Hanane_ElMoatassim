using System.Collections.Generic;
using System.Threading;

namespace WPF_Schoolbib
{
    public class Students
    {

        string firstName;
        string lastName;
        string fullname;
        List<int> allStudentNumbers = new List<int>();
        public static int globalID;

        public Students(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullname = FirstName + " " + lastName;
            this.ID = Interlocked.Increment(ref globalID);
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int ID { get; private set; }
        public List<int> AllStudentNumbers { get => allStudentNumbers; set => allStudentNumbers = value; }

        public override string ToString()
        {
            return fullname;
        }

    }
}
