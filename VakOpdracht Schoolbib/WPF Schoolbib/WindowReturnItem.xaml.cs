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

        private void ShowItems()
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            LoansListbox.ItemsSource = null;
            LoansListbox.ItemsSource = studentRepository.GetAllLoanedItems(selected);
        }


        private void StudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowItems();
        }

        private void BringBackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
