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
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            LoansListbox.ItemsSource = null;
            LoansListbox.ItemsSource = loansRepository.GetLoansOfStudent(selectedStudent.Id); 
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
            if(libraryItem.ReserveStudentID != -1)
            {
                libraryItem.Availability = AvailabilityItem.GereserveerdAanwezig;
            }
            else
            {
                libraryItem.Availability = AvailabilityItem.Aanwezig;
            }
          
            libraryRepository.UpdateLibraryItems(libraryItem);
            MessageBox.Show($"{selectedStudent.FirstName} {selectedStudent.LastName} heeft volgend item teruggebracht: {libraryItem.Title}.");
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
