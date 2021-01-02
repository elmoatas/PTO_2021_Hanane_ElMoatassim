using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Ticketverkoop
{
    /// <summary>
    /// Interaction logic for PrintTicket.xaml
    /// </summary>
    public partial class PrintTicket : Window
    {
        string destinationA;
        string destinationB;
        string fromDatetime;
        string toDateTime;
        int numberOfAdultPassengers;
        int numberOfKidPassengers;
        double totalPrice;

        bool roundwayTrip;

        public PrintTicket(string destinationA, string destinationB, bool roundwayTrip, string fromDatetime, string toDateTime,
            int numberOfAdultPassengers, int numberOfKidPassengers, double totalPrice)
        {
            InitializeComponent();
            this.roundwayTrip = roundwayTrip;
            this.destinationA = destinationA;
            this.destinationB = destinationB;
            this.fromDatetime = fromDatetime;
            this.toDateTime = toDateTime;
            this.numberOfAdultPassengers = numberOfAdultPassengers;
            this.numberOfKidPassengers = numberOfKidPassengers;
            this.totalPrice = totalPrice;
            PrintAll();
        }
        private string KindOfTicket()
        {
            string RoundwaytripString = "";
            if (roundwayTrip)
            {
                RoundwaytripString = "Heen en Terug";
            }
            else
            {
                RoundwaytripString = "Enkel reis";
            }
            return RoundwaytripString;
        }
        private void PrintAll()
        {
            TypeOfTicketLabel.Content = KindOfTicket();
            TrajectLabel.Content = $"{destinationA} - {destinationB}";
            DateLabel.Content = $"{fromDatetime} - {toDateTime}";
            NumberOfAdultsLabel.Content = $"{numberOfAdultPassengers} Volwassenen. ";
            NumberOfKidssLabel.Content = $"{numberOfKidPassengers} Kinderen. ";
            PriceLabel.Content = $" TotaalPrijs: {totalPrice}€";
            CodeImage.Source = new BitmapImage(new Uri("barcode-1d.jpg", UriKind.RelativeOrAbsolute));
        }
    }
}
