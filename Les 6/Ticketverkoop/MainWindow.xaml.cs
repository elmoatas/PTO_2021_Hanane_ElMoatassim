using System;
using System.Windows;
using System.Windows.Controls;

namespace Ticketverkoop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int NumberOfAdultPassengers = 1;
        int NumberOfKidPassengers = 0;
        string destinationA;
        string destinationB;
        bool roundwayTrip = false;
        string fromDatetime;
        string toDateTime;
        double totalPrice;
        CalculatePriceAndDestinations ticket = new CalculatePriceAndDestinations();

        public MainWindow()
        {
            InitializeComponent();
            AddDestinationToCombobox();
            HideRoundTripDatePicker();
            OneWayRadiobutton.IsChecked = true;
            KidNumberdownButton.IsEnabled = false;
            AdultNumberdownButton.IsEnabled = false;
            FromDatepicker.DisplayDateStart = DateTime.Now;
        }



        private void AddDestinationToCombobox()
        {
            ticket.AddDestinationsToList();
            FromComboBox.ItemsSource = ticket.DestinationList;
            ToComboBox.ItemsSource = ticket.DestinationList;
        }
        private bool Check()
        {
            bool check = true;
            if (FromComboBox.SelectedIndex == -1 || ToComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer een Station");
                check = false;
            }
            if (roundwayTrip == true && (ToDatepicker.SelectedDate == null || FromDatepicker.SelectedDate == null))
            {
                MessageBox.Show("selecteer een datum");
                check = false;
            }
            if (roundwayTrip = false && FromDatepicker.SelectedDate == null)
            {
                MessageBox.Show("selecteer een datum");
                check = false;
            }
            return check;

        }

        private void HideRoundTripDatePicker()
        {
            if (RoundWayRadioButton.IsChecked == true)
            {
                ToDatepicker.Visibility = Visibility.Visible;
            }
            else
            {
                ToDatepicker.Visibility = Visibility.Hidden;
            }
        }

        private void OneWayRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            HideRoundTripDatePicker();
            roundwayTrip = false;
        }

        private void RoundWayRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            HideRoundTripDatePicker();
            roundwayTrip = true;
        }

        private void AdultNumberUpButton_Click(object sender, RoutedEventArgs e)
        {
            AdultNumberdownButton.IsEnabled = true;
            NumberOfAdultPassengers += 1;
            AdultNumberLabel.Content = NumberOfAdultPassengers;

        }

        private void AdultNumberdownButton_Click(object sender, RoutedEventArgs e)
        {

            NumberOfAdultPassengers -= 1;
            AdultNumberLabel.Content = NumberOfAdultPassengers;
            if (NumberOfAdultPassengers <= 1)
            {
                AdultNumberdownButton.IsEnabled = false;
            }
        }

        private void KidNumberUpButton_Click(object sender, RoutedEventArgs e)
        {
            KidNumberdownButton.IsEnabled = true;
            NumberOfKidPassengers += 1;
            KidNumberLabel.Content = NumberOfKidPassengers;
        }

        private void KidNumberdownButton_Click(object sender, RoutedEventArgs e)
        {

            NumberOfKidPassengers -= 1;
            KidNumberLabel.Content = NumberOfKidPassengers;
            if (NumberOfKidPassengers <= 0)
            {
                KidNumberdownButton.IsEnabled = false;
            }
        }

        private void SaveAllInformation()
        {
            //opslaan van traject
            if (FromComboBox.SelectedItem != null)
            {
                ticket.DestinationA = FromComboBox.SelectedItem.ToString();
                destinationA = FromComboBox.SelectedItem.ToString();
            }
            if (ToComboBox.SelectedItem != null)
            {
                ticket.DestinationB = ToComboBox.SelectedItem.ToString();
                destinationB = ToComboBox.SelectedItem.ToString();
            }
            //Opslaan van Heendatum en terugdatum
            fromDatetime = FromDatepicker.SelectedDate.Value.ToShortDateString();
            if (roundwayTrip == true)
            {
                toDateTime = ToDatepicker.SelectedDate.Value.ToShortDateString();
            }
            else
            {
                toDateTime = "";
            }
            //Opslaan van aantal volwassenen en kinderen 
            ticket.NumberOfAdults = NumberOfAdultPassengers;
            ticket.NumberOfKids = NumberOfKidPassengers;
            //Opslaan van totaalprijs 
            totalPrice = ticket.CalculateTotalPrice();
        }
        private void CalculatePriceButton_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                SaveAllInformation();
                MessageBox.Show($"Totaal prijs is {totalPrice} €.");
            }
        }

        private void PrintTicket_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                SaveAllInformation();
                PrintTicket printticket = new PrintTicket(ticket.DestinationA, ticket.DestinationB, roundwayTrip, fromDatetime, toDateTime, NumberOfAdultPassengers, NumberOfKidPassengers, totalPrice);
                printticket.ShowDialog();
            }

        }

        private void FromComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            /*if (FromComboBox.SelectedItem != null)
            {
                foreach (string destination in ToComboBox.Items.ToString())
                {
                    if (FromComboBox.SelectedItem == destination)
                    {
                        ToComboBox.Items.Remove(destination);
                    }
                }
            }*/
        }

        private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*if (ToComboBox.SelectedItem != null)
            {
                foreach (ComboBoxItem destination in FromComboBox.Items)
                {
                    if (ToComboBox.SelectedItem == destination)
                    {
                        FromComboBox.Items.Remove(destination);
                    }
                }
            }*/
        }

        private void FromDatepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDatepicker.DisplayDateStart = FromDatepicker.SelectedDate;
        }
    }
}
