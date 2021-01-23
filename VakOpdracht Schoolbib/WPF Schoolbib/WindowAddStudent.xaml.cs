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
            UpdateUI();
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
        private void UpdateUI()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            StudyComboBox.SelectedIndex = -1;
            SexComboBox.SelectedIndex = -1;
        }

        private void Validation()
        {
            // student mag niet in database bestaan al (zelfde voornaam en achternaam
            //als velden leeg zijn kan je niemand toevoegen alle velden moeten ingevuld zijn 
            /* List<Customer> customers = dbContext.Customers.ToList();
             foreach (Customer customer in customers)
             {
                 ListBoxItem item = new ListBoxItem();

                 item.Content = customer.CompanyName;

                 customerListBox.Items.Add(item);
             }*/

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
