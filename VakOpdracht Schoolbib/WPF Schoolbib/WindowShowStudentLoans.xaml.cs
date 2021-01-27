using System.Windows;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowShowStudentLoans.xaml
    /// </summary>
    public partial class WindowShowStudentLoans : Window
    {
        WindowModifyStudent windowModifyStudent = new WindowModifyStudent();
        LoansRepository loansRepository = new LoansRepository();
        int studentId;
        public WindowShowStudentLoans(int studentID)
        {
            InitializeComponent();
                      this.studentId = studentID;
            ShowLoans();
        }
        private void ShowLoans()
        {
            LoansOfSelectedStudentListbox.ItemsSource = loansRepository.GetLoansOfStudent(studentId);
        }
    }
}
