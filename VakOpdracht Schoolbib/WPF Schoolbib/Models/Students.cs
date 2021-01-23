using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    
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
        private int studyindex;
        private int sexIndex;
       
        public Students()
        {

        }
        public Students(string firstName, string lastName, int studyIndex,int sexIndex )
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sexIndex = sexIndex;
            this.studyindex = studyIndex;
            GetTheStudyChoiceName();
            GetSex();
        }

        [Key]
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Study { get => study; set => study = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Studyindex { get => studyindex; set => studyindex = value; }
        public int SexIndex { get => sexIndex; set => sexIndex = value; }

        public void GetSex()
        {
            switch (sexIndex)
            {
                case 0: sex = SexEnum.Vrouw.ToString(); break;
                case 1: sex = SexEnum.Man.ToString(); break;
                case 2: sex = SexEnum.None.ToString(); break;
            }
        }

        public void GetTheStudyChoiceName()
        {
            switch (studyindex)
            {
                case 0:
                    study = Studychoices.Informatica.ToString();
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
