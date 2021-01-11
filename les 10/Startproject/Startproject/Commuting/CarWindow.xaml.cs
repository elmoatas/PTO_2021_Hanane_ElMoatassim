using Commuting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public CarWindow()
        {
            InitializeComponent();
        }
        public Commute Car { get; set; }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            double km = Convert.ToInt32(distanceTextBox.Text);
            Commute car = new Car(fromTextBox.Text, toTextBox.Text, datePicker.SelectedDate.ToString(), km);
        }
    }
}
