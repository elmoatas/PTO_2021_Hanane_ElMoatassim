using System;
using System.Collections.Generic;
using System.Linq;
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
        StudentRepository studentRepository = new StudentRepository();
        LibraryRepository libraryRepository = new LibraryRepository();
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
                
        public WindowModifyStudent()
        {
            InitializeComponent();
            ShowStudentsInListbox();
            PutStudyChoicesInComboBox();
            PutSexChoisesInComboBox();
            ShowLoansButton.IsEnabled = false;
        }
        private void ShowStudentsInListbox()
        {
            StudentListbox.ItemsSource = null;
            StudentListbox.ItemsSource = studentRepository.GetAllStudents();
        }
        private void PutStudyChoicesInComboBox()
        {
            string[] studychoises = Enum.GetNames(typeof(Studychoices));
            StudyCombobox.ItemsSource = studychoises;
        }
        private void PutSexChoisesInComboBox()
        {
            string[] sexChoices = Enum.GetNames(typeof(SexEnum));
            SexComboBox.ItemsSource = sexChoices;
        }

        private void MakeAllFieldsEmpty()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            SexComboBox.SelectedIndex = -1;
            StudyCombobox.SelectedIndex = -1;
            ShowIDLabel.Content = "";
        }
        private void EditInfo()
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            selected.FirstName = FirstNameTextBox.Text;
            selected.LastName = LastNameTextBox.Text;
            selected.Studyindex = StudyCombobox.SelectedIndex;
            selected.SexIndex = SexComboBox.SelectedIndex;
            studentRepository.UpdateStudent(selected);
        }

        private void ShowInfo()
        {
            if (StudentListbox.SelectedItem != null)
            {
                Students selected = (Students)StudentListbox.SelectedItem;
                ShowIDLabel.Content = selected.Id;
                FirstNameTextBox.Text = selected.FirstName;
                LastNameTextBox.Text = selected.LastName;
                StudyCombobox.SelectedIndex = selected.Studyindex;
                SexComboBox.SelectedIndex = selected.SexIndex;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditInfo();
            MakeAllFieldsEmpty();
            ShowStudentsInListbox();
        }

        private void AllStudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowInfo();
            if (StudentListbox.SelectedItem != null)
            {
                ShowLoansButton.IsEnabled = true;
            }
            else
            {
                ShowLoansButton.IsEnabled = false;
            }
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            Students selected = (Students)StudentListbox.SelectedItem;


            if (libraryRepository.GetLibraryItemReservedBy(selected) != null)
            {
                Library item = libraryRepository.GetLibraryItemReservedBy(selected);
                item.ReserveStudentID = -1;
                item.Availability = AvailabilityItem.Aanwezig;
                libraryRepository.UpdateLibraryItems(item);
            }
            studentRepository.DeleteStudent(selected);
            ShowStudentsInListbox();
            MakeAllFieldsEmpty();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            StudentListbox.ItemsSource = null;
            List<Students> FilteredStudentlist = new List<Students>();
            FilteredStudentlist.Clear();
            //List<Students> IDFilter = dbContext.Students.Where((st) => st.Id == Convert.ToInt32(FilterIDTextbox.Text)).ToList();
            List<Students> firstNameFilter = dbContext.Students.Where((st) => st.FirstName == FilterFirstNameTextbox.Text).ToList();
            List<Students> lastNameFilter = dbContext.Students.Where((st) => st.LastName == FilterLastNameTextbox.Text).ToList();
            List<Students> femaleFilter = dbContext.Students.Where((st) => st.SexIndex == 0).ToList();
            List<Students> maleFilter = dbContext.Students.Where((st) => st.SexIndex == 1).ToList();
            //if (FilterIDTextbox.Text != "")
            //{
            //    FilteredStudentlist.AddRange(IDFilter);

            //}
            //else
            //{
            //    foreach (Students item in IDFilter)
            //    {
            //        FilteredStudentlist.Remove(item);
            //    }
            //}

            if (FilterFirstNameTextbox.Text != "")
            {
                FilteredStudentlist.AddRange(firstNameFilter);
            }
            else
            {
                foreach (Students item in firstNameFilter)
                {
                    FilteredStudentlist.Remove(item);
                }
            }

            if (FilterLastNameTextbox.Text != "")
            {
                FilteredStudentlist.AddRange(lastNameFilter);
            }
            else
            {
                foreach (Students item in lastNameFilter)
                {
                    FilteredStudentlist.Remove(item);
                }
            }

            if (FilterFemaleCheckBox.IsChecked == true)
            {
                FilteredStudentlist.AddRange(femaleFilter);
            }
            else
            {
                foreach (Students item in femaleFilter)
                {
                    FilteredStudentlist.Remove(item);
                }
            }
            if (FilterMaleCheckBox.IsChecked == true)
            {
                FilteredStudentlist.AddRange(maleFilter);
            }
            else
            {
                foreach (Students item in maleFilter)
                {
                    FilteredStudentlist.Remove(item);
                }
            }
            if (FilterFemaleCheckBox.IsChecked == false && FilterMaleCheckBox.IsChecked == false)
            {
                FilteredStudentlist = studentRepository.GetAllStudents();
            }

            StudentListbox.ItemsSource = FilteredStudentlist;
        }

        private void ShowLoansButton_Click(object sender, RoutedEventArgs e)
        {
                       
            WindowShowStudentLoans showStudentLoans = new WindowShowStudentLoans(Convert.ToInt32(ShowIDLabel.Content));
            showStudentLoans.ShowDialog();
        }
    }
}
