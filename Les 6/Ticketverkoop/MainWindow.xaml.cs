using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Ticketverkoop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double totalPrice;
        double priceTicket;
        string destinationA;
        string destinationB;
        private List<string> DestinationsList = new List<string>();




        public MainWindow()
        {
            InitializeComponent();
            AddDestinationsToList();
        }
        private void AddDestinationsToList()
        {
            DestinationsList.Add("AALST");
            DestinationsList.Add("BRUSSEL");
            DestinationsList.Add("LEUVEN");
            DestinationsList.Add("GENT");
        }
        private void CalculatePriceOfTraject()
        {
            // AAL-BRU = 5 euro
            // AAL-LEUV = 8 euro
            // AAL-Gent = 5 euro
            // BRU -LEUV = 4 euro
            // BRU - GENT = 10 euro
            // GENT - LEUV = 12 euro
            //heen en terug = *2
        }
        private void CheckIfPosible()
        {
            if (FromTextBox.Text == ToTextBox.Text)
            {
                ToTextBox.Background = Brushes.Red;
                FromTextBox.Background = Brushes.Red;
            }
        }
        private void hideListbox()
        {
            DestinationListBox.Visibility = Visibility.Hidden;
        }

        private void DestinationListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //FromTextBox.Text = DestinationListBox.SelectedItem.ToString();
            hideListbox();
        }

        private void FromTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            AutoCompleteDestination(FromTextBox.Text);

            CheckIfPosible();
        }

        private void ToTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            AutoCompleteDestination(ToTextBox.Text);
            CheckIfPosible();
        }
        private void AutoCompleteDestination(string textboxUsed)
        {
            DestinationListBox.Items.Clear();
            if (textboxUsed.Length == 0)
            {
                hideListbox();
                return;
            }
            foreach (string destination in DestinationsList)
            {
                if (destination.StartsWith(textboxUsed.ToUpper()))
                {
                    DestinationListBox.Items.Add(destination);
                    DestinationListBox.Visibility = Visibility.Visible;
                }

            }
        }
    }
}
