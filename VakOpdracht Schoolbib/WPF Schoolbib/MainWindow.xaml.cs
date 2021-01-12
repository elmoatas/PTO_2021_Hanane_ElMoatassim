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
            TestStudents();
        }

        private void TestStudents()
        {
            Students test1 = new Students("voornaam1", "achternaam1");
            Students test2 = new Students("voornaam2", "achternaam2");
            Students test3 = new Students("voornaam3", "achternaam3");
            Students test4 = new Students("voornaam4", "achternaam4");

        }

        private void NewStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Students test1 = new Students("voornaam1", "achternaam1");
            //test1.AllStudentsList.Add((Students)test1);
          
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
    }
}
