using System;
using System.ComponentModel.DataAnnotations;

namespace WPF_Schoolbib.Models
{


    abstract class Library
    {
     
        private DateTime loanDate;
        private DateTime returnDate;
        private Students loaner;

        public Library(string title, string creator, long productnumber)
        {
          
        }
        

        public DateTime LoanDate { get => loanDate; set => loanDate = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        public Students Loaner { get => loaner; set => loaner = value; }

        public override string ToString()
        {
            return $" ";
        }
    }
}
