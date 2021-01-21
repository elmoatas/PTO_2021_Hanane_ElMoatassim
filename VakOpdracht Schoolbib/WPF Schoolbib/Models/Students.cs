using System.ComponentModel.DataAnnotations;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    enum Studychoices
    {
        Chemie,
        Othopedagogie,
        Ergotherapie,
        Logopedie,
        Electronica,
        Verpleegkunde,
    }
    class Students
    {
        //static List<Students> allStudentsList = new List<Students>();
        private int id;
        // private int itemID;
        private string firstName;
        private string lastName;
        private string study;
        private string sex;
        private Library libraryItem;

        //public static int globalID;
        public Students()
        {

        }
        public Students(string firstName, string lastName, int studyIndex,string sex )
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            GetTheStudyChoiceName(studyIndex);       
        }

        [Key]
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Study { get => study; set => study = value; }
        public string Sex { get => sex; set => sex = value; }

        public void GetTheStudyChoiceName(int ComboBoxIndex)
        {
            switch (ComboBoxIndex)
            {
                case 0:
                    study = Studychoices.Chemie.ToString();
                    break;
                case 1:
                    study = Studychoices.Othopedagogie.ToString();
                    break;
                case 2:
                    study = Studychoices.Ergotherapie.ToString();
                    break;
                case 3:
                    study = Studychoices.Logopedie.ToString();
                    break;
                case 4:
                    study = Studychoices.Electronica.ToString();
                    break;
                case 5:
                    study = Studychoices.Verpleegkunde.ToString();
                    break;
            }
        }
     
        public override string ToString()
        {
            return $"{lastName} {firstName} - {sex} - {study}";
        }

    }
}
