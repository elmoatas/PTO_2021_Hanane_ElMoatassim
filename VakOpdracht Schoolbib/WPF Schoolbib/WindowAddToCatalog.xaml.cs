using System;
using System.Windows;
using System.Windows.Controls;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowCatalog.xaml
    /// </summary>
    public partial class WindowAddCatalog : Window
    {
        public WindowAddCatalog()
        {
            InitializeComponent();
        }

        private void Idtextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void UpdateUI()
        {
            if (BoekRadiobutton.IsChecked == true)
            {
                Author.Content = "Autheur";
                ID.Content = "ISBN";
            }
            if (CDRadiobutton.IsChecked == true)
            {
                Author.Content = "Artiest";
                ID.Content = "ID";
            }
            if (DvdRadiobutton.IsChecked == true)
            {
                Author.Content = "Regisseur";
                ID.Content = "ID";
            }
            Idtextbox.Text = "";
            Titletextbox.Text = "" ;
            Authortextbox.Text = "";
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (BoekRadiobutton.IsChecked == true)
            {
                Library newBook = new Books(Titletextbox.Text, Authortextbox.Text, Convert.ToInt32(Idtextbox.Text));
               
            }
            if (CDRadiobutton.IsChecked == true)
            {
                Library newCD = new CD(Titletextbox.Text, Authortextbox.Text, Convert.ToInt32(Idtextbox.Text));
            }
            if (DvdRadiobutton.IsChecked == true)
            {
                Library newDVD = new DVD(Titletextbox.Text, Authortextbox.Text, Convert.ToInt32(Idtextbox.Text));
            }
            UpdateUI();
        }

        private void DvdRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void CDRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void BoekRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }
    }
}
