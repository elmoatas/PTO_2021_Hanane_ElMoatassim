using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowStudent.xaml
    /// </summary>
    public partial class WindowStudent : Window
    {
        Students student = new Students();
        public WindowStudent()
        {
            InitializeComponent();
        }
        private void OnlyNumbersInID()
        {

        }
        private void MakeTextBoxesEmpty()
        {
            FirstNameTextBox.Text = "";
            IDTextBox.Text = "";
            LastNameTextBox.Text = "";
        }
        private void EditInfo()
        {
            student.ID = Convert.ToInt32(IDTextBox.Text);
            student.FirstName = FirstNameTextBox.Text;
            student.LastName = LastNameTextBox.Text;
        }
        private void ShowInfo()
        {
            IDTextBox.Text = student.ID.ToString();
            FirstNameTextBox.Text = student.FirstName;
            LastNameTextBox.Text = student.LastName;
        }
        private void AddStudentTolist()
        {
            Students newStudent = new Students();
            ListBoxItem allStudents = new ListBoxItem();
            allStudents.Content = newStudent;
            AllStudentListbox.Items.Add(allStudents);
        }

        private void AllStudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowInfo();
        }

        private void EditStudentButton_Click(object sender, RoutedEventArgs e)
        {
            EditInfo();
                    }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentTolist();
            MakeTextBoxesEmpty();

        }
    }
}
