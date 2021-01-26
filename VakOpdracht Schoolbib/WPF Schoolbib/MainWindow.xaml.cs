using System.Windows;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
       
        }

        private void NewStudentButton_Click(object sender, RoutedEventArgs e)
        {
            WindowAddStudent addStudent = new WindowAddStudent();
            addStudent.ShowDialog();
        }
        private void OpenWindow()
        {

        }

        private void ModifyEraseStudentButton_Click(object sender, RoutedEventArgs e)
        {
            WindowModifyStudent modifyStudent = new WindowModifyStudent();
            modifyStudent.ShowDialog();
        }

        private void NewLibraryItemButton_Click(object sender, RoutedEventArgs e)
        {
            WindowAddCatalog addItemWindow = new WindowAddCatalog();
            addItemWindow.ShowDialog();
        }

        private void ModifyEraseLibraryItemButton_Click(object sender, RoutedEventArgs e)
        {
           
            WindowModifyCatalog modifyCatalog = new WindowModifyCatalog();
            modifyCatalog.ShowDialog();
        }

        private void ReturnItemButton_Click(object sender, RoutedEventArgs e)
        {
            WindowReturnItem returnItem = new WindowReturnItem();
            returnItem.ShowDialog();
        }

        private void LoanItemButton_Click(object sender, RoutedEventArgs e)
        {
            WindowLoanItem loanItem = new WindowLoanItem();
            loanItem.ShowDialog();
        }

        private void ReserveItemButton_Click(object sender, RoutedEventArgs e)
        {
            WindowReserve reserveItem = new WindowReserve();
            reserveItem.ShowDialog();
        }
    }
}
