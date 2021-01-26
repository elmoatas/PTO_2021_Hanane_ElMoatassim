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
            LoansListbox.ItemsSource = loansRepository.GetLoansOfStudent(selected); ;
        }
        private void FillInChoice()
        {
            Library selectedItemCatalogus = (Library)LoansListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            if (LoansListbox.SelectedItem != null) { ItemLabel.Content = selectedItemCatalogus.Title; }
            if (StudentListbox.SelectedItem != null) { StudentLabel.Content = $" {selectedStudent.LastName} {selectedStudent.FirstName}"; }
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
            SchoolbibDBContext dbContext = new SchoolbibDBContext();
            Library selectedItemCatalogus = (Library)LoansListbox.SelectedItem;
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
                
            

            selectedItemCatalogus.Availability = AvailabilityItem.Aanwezig;

            studentRepository.UpdateStudent(selectedStudent);

            dbContext.SaveChanges();
            ShowLoanedItems();

        }


    }
}
