using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_Schoolbib.Models
{
    public class Loans
    {

        private double fine = 0;


        public Loans()
        {


        }

        [Key]
        public int ID { get; set; }
        public DateTime LoanDate { get; set; }


        public double Fine { get; set; }
        public Students Student { get; set; }
        public Library LoanedItem { get; set; }
        [NotMapped]
        public DateTime ExpectedReturndate { get => LoanDate.AddDays(30); }
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

    }
}
