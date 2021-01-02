using System.Collections.Generic;

namespace Ticketverkoop
{
    class CalculatePriceAndDestinations
            {
        // Private members
        private int numberOfAdults;
        private int numberOfKids;
        private double priceKid;
        private double priceAdult;
        private double totalPrice;
        private string destinationA;
        private string destinationB;
        private bool roundWayTrip;

        private List<string> destinationsList = new List<string>();
        // Constructor 
        public CalculatePriceAndDestinations()
        {

        }
        public int NumberOfAdults
        {
            get { return numberOfAdults; }
            set { numberOfAdults = value; }
        }
        public int NumberOfKids
        {
            get { return numberOfKids; }
            set { numberOfKids = value; }
        }
        public string DestinationA { get { return destinationA; } set { destinationA = value; } }
        public string DestinationB { get { return destinationB; } set { destinationB = value; } }
        public double TotalPrice { get { return totalPrice; } }
        public List<string> DestinationList { get { return destinationsList; } }
        public bool RoundWayTrip { set { roundWayTrip = value; } }

        //METHODES
        public void AddDestinationsToList()                //DESTINATIONS IN LIJST TOEVOEGEN
        {
            destinationsList.Add("AALST");
            destinationsList.Add("BRUSSEL");
            destinationsList.Add("LEUVEN");
            destinationsList.Add("GENT");
        }
        private double CalculateTrajectPrice()               //PRIJS VAN TRAJECTEN BEREKENEN 
        {
            double priceTraject = 0;
            // AAL-BRU = 5 euro
            if (destinationA == "AALST" && destinationB == "BRUSSEL" || destinationA == "BRUSSEL" && destinationB == "AALST")
            {
                priceTraject = 5.00;
            }
            // AAL-LEUV = 10 euro
            else if (destinationA == "AALST" && destinationB == "LEUVEN" || destinationA == "LEUVEN" && destinationB == "AALST")
            {
                priceTraject = 10;
            }
            // AAL-Gent = 5 euro
            else if (destinationA == "AALST" && destinationB == "GENT" || destinationA == "GENT" && destinationB == "AALST")
            {
                priceTraject = 5;
            }
            // BRU -LEUV = 8 euro
            else if (destinationA == "LEUVEN" && destinationB == "BRUSSEL" || destinationA == "BRUSSEL" && destinationB == "LEUVEN")
            {
                priceTraject = 8;
            }
            // BRU - GENT = 10 euro
            else if (destinationA == "GENT" && destinationB == "BRUSSEL" || destinationA == "BRUSSEL" && destinationB == "GENT")
            {
                priceTraject = 10;
            }
            // GENT - LEUV = 12 euro
            else if (destinationA == "GENT" && destinationB == "LEUVEN" || destinationA == "LEUVEN" && destinationB == "GENT")
            {
                priceTraject = 12;
            }
            return priceTraject;
        }
        public double CalculateTotalPrice()          //TOTALE PRIJS BEREKENEN
        {
            priceAdult = CalculateTrajectPrice() * NumberOfAdults;
            priceKid = CalculateTrajectPrice() * NumberOfKids * 0.7;
            totalPrice = priceAdult + priceKid;
            if (roundWayTrip == true)
            {
                totalPrice *= 2;
            }
            return totalPrice;
        }
    }
}
