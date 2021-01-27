using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_Schoolbib.Models
{
    public class Loans
    {
        LibraryRepository libraryRepository = new LibraryRepository();
        private double fine = 0;
        
        public Loans()
        {


        }

        [Key]
        public int ID { get; set; }
        public DateTime LoanDate { get; set; }
        public double Fine { get; set; }
        public int StudentId { get; set; }
        public int itemId { get; set; }
     

        [NotMapped]
        public DateTime ExpectedReturndate { get => LoanDate.AddDays(30); }

        [NotMapped]
        public string ItemTitle { get => libraryRepository.GetLibraryItemWithID(itemId).Title; }

        [NotMapped]
        public AvailabilityItem ItemAvailibility { get => libraryRepository.GetLibraryItemWithID(itemId).Availability; }

        [NotMapped]
        public DateTime ReturnDate { get; set; }


        public void CalculateFine()
        {
            if (ExpectedReturndate < ReturnDate)
            {
                int timespan = (ExpectedReturndate - ReturnDate).Days;
                fine = 0.50 * timespan;
            }
        }
        // - Uitleendatum: {LoanDate.ToShortDateString()

        public override string ToString()
        {
             return $" Titel: {ItemTitle}";
        }

    }
}
