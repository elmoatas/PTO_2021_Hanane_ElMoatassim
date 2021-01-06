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
        //Students student = new Students();
        public WindowStudent()
        {
            InitializeComponent();
        }
       
        private void MakeTextBoxesEmpty()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
        }
        private void EditInfo()
        {
            Students selected = (Students)((ListBoxItem)AllStudentListbox.SelectedItem).Content;
            selected.FirstName = FirstNameTextBox.Text;
            selected.LastName = LastNameTextBox.Text;
        }

        private void ShowInfo()
        {
            Students selected = (Students)((ListBoxItem)AllStudentListbox.SelectedItem).Content;
            ShowIDLabel.Content = selected.ID;
            FirstNameTextBox.Text = selected.FirstName;
            LastNameTextBox.Text = selected.LastName;
        }
        private void AddStudentTolist()
        {
            Students newStudent = new Students(FirstNameTextBox.Text, LastNameTextBox.Text);
            ListBoxItem studentListboxItem = new ListBoxItem();
            studentListboxItem.Content = newStudent;
            AllStudentListbox.Items.Add(studentListboxItem);
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
