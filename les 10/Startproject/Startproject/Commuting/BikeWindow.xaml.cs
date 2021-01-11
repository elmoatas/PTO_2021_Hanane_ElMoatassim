using Commuting;
using System;
using System.Windows;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for BikeWindow.xaml
    /// </summary>
    public partial class BikeWindow : Window
    {
        public BikeWindow()
        {
            InitializeComponent();
        }

        public Commute Bike { get; set; }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            double km = Convert.ToInt32(distanceTextBox.Text);
            Commute bike = new Bike(fromTextBox.Text, toTextBox.Text, datePicker.SelectedDate.ToString());
        }

    }
}
