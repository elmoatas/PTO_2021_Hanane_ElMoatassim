using System.Windows;
using System.Windows.Controls;
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
        LoansRepository loansRepository = new LoansRepository();
        public WindowReserve()
        {
            InitializeComponent();
            ShowLoanedItems();
            ShowStudentsInListbox();
            StudentsListbox.ItemsSource = studentRepository.GetAllStudents();
        }

        private void ShowLoanedItems()
        {
            LoansListbox.ItemsSource = null;
            LoansListbox.ItemsSource = libraryRepository.GetItemsBasedOnAvailability(AvailabilityItem.Uitgeleend);
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
       
            if (LoansListbox.SelectedItem != null) 
            {
                ItemLabel.Content = selectedItemCatalogus.Title;
            }
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
            ShowStudentsInListbox();
        }

        private void StudentsListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FillInChoice();
        }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            Library selectedItemCatalogus = (Library)LoansListbox.SelectedItem;
            Students selectedStudent = (Students)StudentsListbox.SelectedItem;
            selectedItemCatalogus.ReserveStudentID = selectedStudent.Id;
            selectedItemCatalogus.Availability = AvailabilityItem.Gereserveerduitgeleend;
            libraryRepository.UpdateLibraryItems(selectedItemCatalogus);
            MessageBox.Show($" {selectedStudent.FirstName} {selectedStudent.LastName} heeft volgende item gereserveerd: {selectedItemCatalogus.Title}");
            ShowLoanedItems();
        }
    }
}
