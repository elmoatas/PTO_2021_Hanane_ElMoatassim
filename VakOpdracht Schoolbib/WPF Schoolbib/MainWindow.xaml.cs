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

        private void TestStudents()
        {
            Students test1 = new Students("voornaam1", "achternaam1");
            Students test2 = new Students("hanane", "Elmoatassim");
            Students test = new Students("voornaam2", "achternaam2");
            Library newItem = new CD("Redbone", "childish Gambino", 5485);
            Library newItem2 = new Books("bookthief", "Mark suzak", 5485645);
            Library newItem3 = new DVD("criminal mind", "Spencer", 54849);
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
    }
}
