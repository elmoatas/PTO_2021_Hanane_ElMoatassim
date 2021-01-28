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
        public string ReturnDateString { get; set; }
        public double Fine { get => 0.50 * Timespan; }
        public bool FinePayed { get; set; }
        public string availabiltyItemString { get => libraryRepository.GetLibraryItemWithID(itemId).Availability.ToString(); }

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
        public DateTime ReturnDate { get => DateTime.Parse(ReturnDateString); }
        [NotMapped]
        public bool ReturnedOnTime { get => IsItReturnedOnTime(); }
        [NotMapped]
        public int Timespan { get => GetTimeSpan(); }

        public string GetReturnDate()
        {
            if (ReturnDateString == "")
            {
                return $"Verwachte inleverdatum: {ExpectedReturndate}";
            }
            else
            {
                return $"Inleverdatum: {ReturnDateString}";
            }
        }
        private bool IsItReturnedOnTime()
        {
            bool onTime = false;
            if (ExpectedReturndate < ReturnDate)
            {
                onTime = false;
            }
            else
            {
                onTime = true;
            }
            return onTime;
        }
        private int GetTimeSpan()
        {
            int timespan = (ReturnDate- ExpectedReturndate ).Days;
            if (timespan > 0)
            {
                timespan = (ReturnDate - ExpectedReturndate).Days;
            }
            else
            {
                timespan = 0;
            }
            return timespan;
        }


        public override string ToString()
        {
            return $" Titel: {ItemTitle} ";
        }

    }
}
