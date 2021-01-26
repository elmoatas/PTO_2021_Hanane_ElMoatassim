using System;
using System.Windows;
using System.Windows.Controls;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowLoanItem.xaml
    /// </summary>
    public partial class WindowLoanItem : Window
    {
        StudentRepository studentRepository = new StudentRepository();
        LibraryRepository libraryRepository = new LibraryRepository();
        LoansRepository loansRepository = new LoansRepository();
        public WindowLoanItem()
        {
            InitializeComponent();
            ShowLibraryInListbox();
            ShowStudentsInListbox();
        }
        private void ShowStudentsInListbox()
        {
            StudentListbox.ItemsSource = null;
            StudentListbox.ItemsSource = studentRepository.GetAllStudents();
        }
        private void ShowLibraryInListbox()
        {
            CatalogusListbox.ItemsSource = null;
            CatalogusListbox.ItemsSource = libraryRepository.GetItemsBasedOnAvailability(AvailabilityItem.Aanwezig);
        }
        private void ShowBooksInListbox()
        {
            CatalogusListbox.ItemsSource = null;
            CatalogusListbox.ItemsSource = libraryRepository.GetAllBooks();
        }
        private void ShowDVDsInListbox()
        {
            CatalogusListbox.ItemsSource = null;
            CatalogusListbox.ItemsSource = libraryRepository.GetAllDvds();
        }
        private void ShowCDsInListbox()
        {
            CatalogusListbox.ItemsSource = null;
            CatalogusListbox.ItemsSource = libraryRepository.GetAllCds();
        }

        private void FillInChoice() 
        {
            Library selectedItemCatalogus = (Library)CatalogusListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            if (CatalogusListbox.SelectedItem !=null) { ItemLabel.Content = selectedItemCatalogus.Title; }
            if (StudentListbox.SelectedItem!=null) { StudentLabel.Content = $" {selectedStudent.LastName} {selectedStudent.FirstName}"; }
        }

        private void CDRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            ShowCDsInListbox();
        }

        private void DvdRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            ShowDVDsInListbox();
        }

        private void BoekRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            ShowBooksInListbox();
        }

        private void CatalogusListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillInChoice();
        }

        private void StudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillInChoice();
        }

        private void loanButton_Click(object sender, RoutedEventArgs e)
        {
            Library selectedItemCatalogus = (Library)CatalogusListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            
            Loans newLoan = new Loans();
            newLoan.StudentId = selectedStudent.Id;        
            newLoan.LoanDate = DateTime.UtcNow;
            newLoan.itemId = selectedItemCatalogus.LibraryId;
          
            loansRepository.CreateLoan(newLoan);

            selectedItemCatalogus.Availability = AvailabilityItem.Uitgeleend;
            libraryRepository.UpdateLibraryItems(selectedItemCatalogus);
                    
            ShowLibraryInListbox();

        }

     
    }
}
