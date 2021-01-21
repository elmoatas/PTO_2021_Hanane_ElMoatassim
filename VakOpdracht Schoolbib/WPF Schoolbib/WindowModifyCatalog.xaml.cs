using System;
using System.Windows;
using System.Windows.Controls;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowModifyCatalog.xaml
    /// </summary>
    public partial class WindowModifyCatalog : Window
    {
        public WindowModifyCatalog()
        {
            InitializeComponent();
            //UpdateUIT();
        }
        private void UpdateUIT()
        {
            if (Listbox.SelectedItem != null)
            {
                ModifyButton.IsEnabled = false;
                EraseButton.IsEnabled = false;
            }
            //Listbox.ItemsSource = null;
           // Listbox.ItemsSource = Library.LibraryList;
        }

        private void ShowInfo()
        {
          /*  if (Listbox.SelectedItem != null)
            {
                Library selected = (Library)Listbox.SelectedItem;
                Titletextbox.Text = selected.Title;
                Authortextbox.Text = selected.Author;
                Idtextbox.Text = Convert.ToString(selected.ID);
            }*/
        }
        private void EditInfo()
        {
          /*  Library selected = (Library)Listbox.SelectedItem;
            selected.Title = Titletextbox.Text;
            selected.Author = Authortextbox.Text;
            selected.ID = Convert.ToInt32(Idtextbox.Text);
          */
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
           // Library selected = (Library)Listbox.SelectedItem; ;
           // Library.LibraryList.Remove(selected);
            //Listbox.ItemsSource = null;
            //Listbox.ItemsSource = Students.AllStudentsList;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            //EditInfo();
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ShowInfo();
        }
    }
}
