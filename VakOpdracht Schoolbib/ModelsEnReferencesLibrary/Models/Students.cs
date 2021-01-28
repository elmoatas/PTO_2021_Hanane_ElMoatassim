using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{

    public class Students
    {

        public Students()
        {

        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Studyindex { get; set; }
        public int SexIndex { get; set; }
        [NotMapped]
        public string Study { get => GetTheStudyChoiceName(); }
       
        [NotMapped]
        public string Sex { get => GetSex(); }

        private string GetSex()
        {
            string sex = "";
            switch (SexIndex)
            {
                case 0: sex = SexEnum.Vrouw.ToString(); break;
                case 1: sex = SexEnum.Man.ToString(); break;
            }
            return sex;
        }

        private string GetTheStudyChoiceName()
        {
            switch (Studyindex)
            {
                case 0:
                    return Studychoices.Informatica.ToString();
                case 1:
                    return Studychoices.Othopedagogie.ToString();
                case 2:
                    return Studychoices.Ergotherapie.ToString();
                case 3:
                    return Studychoices.Logopedie.ToString();
                case 4:
                    return Studychoices.Electronica.ToString();
                case 5:
                    return Studychoices.Verpleegkunde.ToString();
                default: return "";
            }

        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }

    }
}
