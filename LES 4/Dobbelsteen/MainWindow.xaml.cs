using System;
using System.Windows;

namespace Dobbelsteen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dice Dice1 = new Dice("dobbelsteen 1");
        public MainWindow()

        {
            InitializeComponent();
            Random rnd = new Random();
            rnd.Next(0, 6);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Dice1.Roll();
            imagedice.Source = Dice1.Image;
        }
    }
}
