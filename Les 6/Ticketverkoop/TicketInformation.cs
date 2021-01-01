using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Ticketverkoop
{
    class TicketInformation
    {
        // Private members
        private double priceKid;
        private double priceAdult;
        private double priceTraject;
        private double totalPrice = 0;
        private string destinationA;
        private string destinationB;
        private int NumberOfAdultPassengers = 1;
        private int NumberOfKidPassengers = 0;
        private List<string> destinationsList = new List<string>();
        // Constructor 
        public TicketInformation()
        {
            
        }
        public string DestinationA
        {
            get { return destinationA; }
            set { destinationA = value; }
        }
        public string DestinationB
        {
            get { return destinationB; }
            set { destinationB = value; }
        }
        public double TotalPrice
        {
            get { return totalPrice; }
        }
        public List<string> DestinationList
        {
            get { return destinationsList; }
        }
      
        private void AddDestinationsToList()
        {
            destinationsList.Add("AALST");
            destinationsList.Add("BRUSSEL");
            destinationsList.Add("LEUVEN");
            destinationsList.Add("GENT");
        }
        private void CalculateTrajectPrice()
        {
            // AAL-BRU = 5 euro
            if (destinationA == "AALST" && destinationB == "BRUSSEL" || destinationA == "BRUSSEL" && destinationB == "AALST")
            {
                priceTraject += 5.00;
            }
            // AAL-LEUV = 10 euro
            else if (destinationA == "AALST" && destinationB == "LEUVEN" || destinationA == "LEUVEN" && destinationB == "AALST")
            {
                priceTraject += 10;
            }
            // AAL-Gent = 5 euro
            else if (destinationA == "AALST" && destinationB == "GENT" || destinationA == "GENT" && destinationB == "AALST")
            {
                priceTraject += 5;
            }
            // BRU -LEUV = 8 euro
            else if (destinationA == "LEUVEN" && destinationB == "BRUSSEL" || destinationA == "BRUSSEL" && destinationB == "LEUVEN")
            {
                priceTraject += 8;
            }
            // BRU - GENT = 10 euro
            else if (destinationA == "GENT" && destinationB == "BRUSSEL" || destinationA == "BRUSSEL" && destinationB == "GENT")
            {
                priceTraject += 10;
            }
            // GENT - LEUV = 12 euro
            else if (destinationA == "GENT" && destinationB == "LEUVEN" || destinationA == "LEUVEN" && destinationB == "GENT")
            {
                priceTraject += 12;
            }
        }
        private void CalculateTotalPrice()
        {
            CalculateTrajectPrice();
            priceAdult = priceTraject * NumberOfAdultPassengers;
            priceKid = priceTraject * NumberOfKidPassengers * 0.7;
            totalPrice = priceAdult + priceKid;
            /*if ( )//RoundWayRadioButton.IsChecked == true)
            {
                totalPrice *= 2;
            }*/
        }
    }
}
