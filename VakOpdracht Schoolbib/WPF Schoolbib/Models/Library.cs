using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_Schoolbib.Models
{


    abstract public class Library
    {
        private int libraryId;
        private string title;
        private string creator;
        private long productNumber;
        private Students loaner;
        private AvailabilityItem availability;

        public Library()
        {

        }
        public Library(string title, string creator, long productnumber, AvailabilityItem availability)
        {
            this.title = title;
            this.creator = creator;
            this.productNumber = productnumber;
            this.availability = availability;

        }
        [Key]
        public int LibraryId { get => libraryId; set => libraryId = value; }
        public string Title { get => title; set => title = value; }
        public string Creator { get => creator; set => creator = value; }
        public long ProductNumber { get => productNumber; set => productNumber = value; }
        public int ReserveStudentID { get; set; }
        public Students Loaner { get => loaner; set => loaner = value; }
        public AvailabilityItem Availability { get => availability; set => availability = value; }
    



        public override string ToString()
        {
            return $" {productNumber} - {title} - {availability} ";
        }
    }
}
