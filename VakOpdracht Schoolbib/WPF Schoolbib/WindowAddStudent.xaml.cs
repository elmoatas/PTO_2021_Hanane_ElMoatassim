using System;
using System.Linq;
using System.Windows;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowAddStudent.xaml
    /// </summary>
    public partial class WindowAddStudent : Window
    {
        SchoolbibDBContext schoolbibDBContext = new SchoolbibDBContext();
        StudentRepository studentRepository = new StudentRepository();
        public WindowAddStudent()
        {
            InitializeComponent();
            ShowStudentsInListbox();
            PutStudyChoicesInComboBox();
            PutSexChoisesInComboBox();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentToDB();
            SetToInitialState();
            ShowStudentsInListbox();
            Close();
        }
        private void PutStudyChoicesInComboBox()
        {
            string[] studychoises = Enum.GetNames(typeof(Studychoices));
            StudyComboBox.ItemsSource = studychoises;
        }
        private void PutSexChoisesInComboBox()
        {
            string[] sexChoices = Enum.GetNames(typeof(SexEnum));
            SexComboBox.ItemsSource = sexChoices;
        }
        private void SetToInitialState()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            StudyComboBox.SelectedIndex = -1;
            SexComboBox.SelectedIndex = -1;
        }

        private void AddStudentToDB()
        {
            if (AllFieldsAreFilled() == true)
            {
                Students newstudent = new Students(FirstNameTextBox.Text, LastNameTextBox.Text, StudyComboBox.SelectedIndex, SexComboBox.SelectedIndex);
                studentRepository.CreateStudent(newstudent);
            }
        }
        private void ShowStudentsInListbox()
        {
            StudentListbox.ItemsSource = null;
            StudentListbox.ItemsSource = schoolbibDBContext.Students.ToList();
        }
        private bool AllFieldsAreFilled()
        {
            bool everythingOK = true;
            if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "" || StudyComboBox.SelectedIndex == -1 ||
                SexComboBox.SelectedIndex == -1)
            {
                everythingOK = false;

            }
            else
            {
                everythingOK = true;
            }
            return everythingOK;
        }
    }
}
