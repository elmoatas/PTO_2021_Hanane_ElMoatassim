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
        public string ReturnDateString { get => GetReturnDate(); }
        public double Fine { get; set; }

        //Info over student 
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        


        //Info over Item
        public int itemId { get; set; }
        public string ItemTitle { get; set; }
        public string ItemCreator { get; set; }
        public long ItemProductNumber { get; set; }

        [NotMapped]
        public DateTime ExpectedReturndate { get => LoanDate.AddDays(30); }

        [NotMapped]
        public AvailabilityItem ItemAvailibility { get => libraryRepository.GetLibraryItemWithID(itemId).Availability; }

        [NotMapped]
        public DateTime ReturnDate { get; set; }

        private string GetReturnDate()
        {
            if (ReturnDate == DateTime.MinValue)
            {
                return $"Verwachte inleverdatum: {ExpectedReturndate}";
            }
            else
            {
                return $"Inleverdatum: {ReturnDate.ToShortDateString()}";
            }
        }
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
            return $" Titel: {ItemTitle} ";
        }

    }
}
