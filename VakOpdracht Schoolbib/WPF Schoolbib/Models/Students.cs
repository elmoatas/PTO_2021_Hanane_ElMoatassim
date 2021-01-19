using System.Collections.Generic;
using System.Threading;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
     class Students
    {
        static List<Students> allStudentsList = new List<Students>();
        string firstName;
        string lastName;
        string fullname;
        int itemID;

        public static int globalID;

        public Students(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullname = firstName + " " + lastName;
            this.ID = Interlocked.Increment(ref globalID);
            AllStudentsList.Add(this);
            if(firstName==null && lastName == null)
            {

            }
        }

        public int ID { get; private set; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public static List<Students> AllStudentsList { get => allStudentsList; set => allStudentsList = value; }
        public int ItemID { get => itemID; set => itemID = value; }

        public override string ToString()
        {
            return fullname;
        }

    }
}
