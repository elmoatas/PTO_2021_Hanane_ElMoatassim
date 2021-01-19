using System.Windows;
using System.Windows.Controls;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowModifyStudent.xaml
    /// </summary>
    public partial class WindowModifyStudent : Window
    {
        public WindowModifyStudent()
        {
            InitializeComponent();
            StudentListbox.ItemsSource = Students.AllStudentsList;
        }
        private void MakeTextBoxesEmpty()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
        }
        private void EditInfo()
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            selected.FirstName = FirstNameTextBox.Text;
            selected.LastName = LastNameTextBox.Text;


        }

        private void ShowInfo()
        {
            if (StudentListbox.SelectedItem != null)
            {
                Students selected = (Students)StudentListbox.SelectedItem;
                //ShowIDLabel.Content = selected.ID;
                FirstNameTextBox.Text = selected.FirstName;
                LastNameTextBox.Text = selected.LastName;
            }
        }
  
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {


            EditInfo();
            MakeTextBoxesEmpty();
            StudentListbox.ItemsSource = null;
            StudentListbox.ItemsSource = Students.AllStudentsList;
        }

        private void AllStudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowInfo();
          
            AddLoans();
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            Students.AllStudentsList.Remove(selected);
            StudentListbox.ItemsSource = null;
            StudentListbox.ItemsSource = Students.AllStudentsList;

        }

        private void AddLoans() 
        {
            if (StudentListbox.SelectedItem != null)
            {
                Students selected = (Students)StudentListbox.SelectedItem;
                foreach (Library item in Library.LibraryList)
                {
                    if (item.ID == selected.ItemID)
                    {
                        LoansOfSelectedStudentListbox.Items.Add(item);
                    }
                }
            }
        }

        private void LoansOfSelectedStudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }
    }
}
