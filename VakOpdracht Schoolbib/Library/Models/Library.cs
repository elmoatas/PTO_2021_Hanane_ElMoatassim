using System.ComponentModel.DataAnnotations;

namespace LibraryModels.Models
{


    abstract public class Library
    {


        public Library()
        {

        }

        [Key]
        public int LibraryId { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public long ProductNumber { get; set; }
        public int ReserveStudentID { get; set; }
        public int LoanerID { get; set; }
        public AvailabilityItem Availability { get; set; }

        public override string ToString()
        {
            return $"{ProductNumber} - {Title} - {Creator}";
        }
    }
}
