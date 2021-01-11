using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{

    enum CommutingOption
    {
        Bike,
        Car,
        Train
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {
            CarWindow carWindow = new CarWindow();
            carWindow.ShowDialog();
            commutingListBox.Items.Add(carWindow.Car);
        }

        private void addBikeButton_Click(object sender, RoutedEventArgs e)
        {
            BikeWindow bikeWindow = new BikeWindow();
            bikeWindow.ShowDialog();
            ListBoxItem commuteItem = new ListBoxItem();
            commuteItem.Content = bikeWindow.Bike;
            commutingListBox.Items.Add(commuteItem);
            
        }

        private void addTrainButton_Click(object sender, RoutedEventArgs e)
        {
            TrainWindow trainWindow = new TrainWindow();
            trainWindow.ShowDialog();
            //commutingListBox.Items.Add(trainWindow.Train);
        }
    }
}
