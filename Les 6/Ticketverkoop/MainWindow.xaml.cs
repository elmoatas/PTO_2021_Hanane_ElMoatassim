using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ticketverkoop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double totalPrice = 0;
         int NumberOfAdultPassengers = 1;
        int NumberOfKidPassengers = 0;
        TicketInformation ticket = new TicketInformation();

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();

        }
        private void UpdateUI()
        {
            OneWayRadiobutton.IsChecked = true;
            AddDestinationToCombobox();
            HideRoundTripDatePicker();
        }

 
        private void AddDestinationToCombobox()
        {
            FromComboBox.ItemsSource = ticket.DestinationList;
            ToComboBox.ItemsSource = ticket.DestinationList;

            if (FromComboBox.SelectedItem != null)
            {
                ComboBoxItem selection = (ComboBoxItem)FromComboBox.SelectedItem;
                string selectedDestination = selection.Content.ToString();
                foreach (string destination in ticket.DestinationList)
                {
                    if (selectedDestination != destination)
                    {

                    }
                }
            }
        }


        private void CalculateTotalPrice()
        {
            totalPrice = ticket.TotalPrice;
            if (RoundWayRadioButton.IsChecked == true)
            {
                 totalPrice*= 2;
            }
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
        }

        private void RoundWayRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            HideRoundTripDatePicker();
        }

        private void AdultNumberUpButton_Click(object sender, RoutedEventArgs e)
        {
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

        private void FromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromComboBox.SelectedItem != null)
            {
                ticket.DestinationA= FromComboBox.SelectedItem.ToString();
            }
        }

        private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToComboBox.SelectedItem != null)
            {
                ticket.DestinationB = ToComboBox.SelectedItem.ToString();
            }
        }

        private void CalculatePriceButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateTotalPrice();
            MessageBox.Show($"Totaal prijs is {totalPrice} €.");
        }
    }
}
