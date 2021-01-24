using System;
using System.Collections.Generic;

namespace WPF_Schoolbib.Models
{
    class Fines
    {
        private Students student;
        private List<Library> loans;
        private DateTime loanDate;
        private DateTime returnDate;
        private double fine;
        public Fines()
        {

        }
        public void CalculateVoid()
        {
            foreach (Library item in loans)
            {
                if (returnDate > DateTime.Today)
                {
                    int timespan = (DateTime.Today - returnDate).Days;
                    fine = 0.50 * timespan;
                }
            }
        }

    }
}
