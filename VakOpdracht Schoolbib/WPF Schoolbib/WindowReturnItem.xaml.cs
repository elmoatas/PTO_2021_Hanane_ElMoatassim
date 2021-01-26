using System;
using System.Windows;
using System.Windows.Controls;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowLoanItem.xaml
    /// </summary>
    public partial class WindowReturnItem : Window
    {
        StudentRepository studentRepository = new StudentRepository();
        LibraryRepository libraryRepository = new LibraryRepository();
        LoansRepository loansRepository = new LoansRepository();
        public WindowReturnItem()
        {
            InitializeComponent();
            ShowStudentsInListbox();
        }
        private void ShowStudentsInListbox()
        {
            StudentListbox.ItemsSource = null;
            StudentListbox.ItemsSource = studentRepository.GetAllStudents();
        }

        private void ShowLoanedItems()
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            LoansListbox.ItemsSource = null;
            LoansListbox.ItemsSource = loansRepository.GetOnlyLentLoans(selected); 
        }
        private void FillInChoice()
        {
            Loans selectedLoan = (Loans)LoansListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            if (LoansListbox.SelectedItem != null) { ItemLabel.Content = selectedLoan.ItemTitle; }
            if (StudentListbox.SelectedItem != null) { StudentLabel.Content = $" {selectedStudent.LastName} {selectedStudent.FirstName}"; }
        }
        private void BringBackLoanedBook()
        {
            Loans selectedloan = (Loans)LoansListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            selectedloan.ReturnDate = DateTime.Now;
            loansRepository.UpdateLoan(selectedloan);
            Library libraryItem = libraryRepository.GetLibraryItemWithID(selectedloan.itemId);
            libraryItem.Availability = AvailabilityItem.Aanwezig;
            libraryRepository.UpdateLibraryItems(libraryItem);
        }

        private void StudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowLoanedItems();
            FillInChoice();
        }
        private void LoansListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillInChoice();
        }

        private void BringBackButton_Click(object sender, RoutedEventArgs e)
        {
            BringBackLoanedBook();
            ShowLoanedItems();
        }
    }
}
