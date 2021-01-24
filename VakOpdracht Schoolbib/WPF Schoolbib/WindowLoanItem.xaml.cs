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
            CatalogusListbox.ItemsSource = libraryRepository.GetOnlyAvailableItems();
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

        }

        private void loanButton_Click(object sender, RoutedEventArgs e)
        {
            SchoolbibDBContext dbContext = new SchoolbibDBContext();
            Library selectedItemCatalogus = (Library)CatalogusListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            selectedItemCatalogus.LoanDate = DateTime.Now;
            selectedItemCatalogus.Availability = AvailabilityItem.Uitgeleend;
            selectedStudent.LibraryItem.Add(selectedItemCatalogus);
            studentRepository.UpdateStudent(selectedStudent);
            dbContext.SaveChanges();

            ShowLibraryInListbox();

        }
    }
}
