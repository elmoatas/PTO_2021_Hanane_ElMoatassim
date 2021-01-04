using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Poker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ShowHand()
        {
            DealCards dealcard = new DealCards();
            dealcard.Deal();
            ImageCard1.Source = new BitmapImage(new Uri(dealcard.ImageUrl1, UriKind.RelativeOrAbsolute));
            ImageCard2.Source = new BitmapImage(new Uri(dealcard.ImageUrl2, UriKind.RelativeOrAbsolute));
            ImageCard3.Source = new BitmapImage(new Uri(dealcard.ImageUrl3, UriKind.RelativeOrAbsolute));
            ImageCard4.Source = new BitmapImage(new Uri(dealcard.ImageUrl4, UriKind.RelativeOrAbsolute));
            ImageCard5.Source = new BitmapImage(new Uri(dealcard.ImageUrl5, UriKind.RelativeOrAbsolute));
        }
        public void showScore()
        {

        }

        private void PullCardsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowHand();
        }
    }
}
