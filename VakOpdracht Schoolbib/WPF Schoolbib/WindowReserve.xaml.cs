using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowReserve.xaml
    /// </summary>
    public partial class WindowReserve : Window
    {
        StudentRepository studentRepository = new StudentRepository();
        LibraryRepository libraryRepository = new LibraryRepository();
        public WindowReserve()
        {
            InitializeComponent();
            ShowLoanedItems();
            ShowStudentsInListbox();
        }

        private void ShowLoanedItems()
        {
            Students selected = (Students)LoansListbox.SelectedItem;
            LoansListbox.ItemsSource = null;
            LoansListbox.ItemsSource = libraryRepository.GetItemsBasedOnAvailability( AvailabilityItem.Uitgeleend);
        }
        private void ShowStudentsInListbox()
        {
            StudentsListbox.ItemsSource = null;
            StudentsListbox.ItemsSource = studentRepository.GetAllStudents();
        }
        private void FillInChoice()
        {
            Library selectedItemCatalogus = (Library)LoansListbox.SelectedItem;
            Students selectedStudent = (Students)StudentsListbox.SelectedItem;
            if (LoansListbox.SelectedItem != null) { ItemLabel.Content = selectedItemCatalogus.Title; }
            if (StudentsListbox.SelectedItem != null) { StudentLabel.Content = $" {selectedStudent.LastName} {selectedStudent.FirstName}"; }
        }

        private void CDRadiobutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DvdRadiobutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BoekRadiobutton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LoansListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillInChoice();
        }

        private void StudentsListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillInChoice();
        }
    }
}
