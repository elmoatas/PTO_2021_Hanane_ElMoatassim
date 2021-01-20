using System;
using System.Linq;
using System.Windows;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowAddStudent.xaml
    /// </summary>
    public partial class WindowAddStudent : Window
    {
        SchoolbibDBContext schoolbibDBContext = new SchoolbibDBContext();
        public WindowAddStudent()
        {
            InitializeComponent();
            ShowStudentsInListbox();
            PutStudyChoicesInComboBox();
            Validation();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentToDB();
            UpdateUI();
            ShowStudentsInListbox();
        }
        private void PutStudyChoicesInComboBox()
        {
            string[] studychoises = Enum.GetNames(typeof(Studychoises));
            StudyCombobox.ItemsSource = studychoises;
        }
        private void UpdateUI()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            StudyCombobox.SelectedIndex = -1;
            FemaleRadioButton.IsChecked = false;
            MaleRadioButton.IsChecked = false;
        }
        private string GetSex()
        {
            string sex = "";
            if (FemaleRadioButton.IsChecked == true)
            {
                sex = "V";
            }
            else
            {
                sex = "M";
            }
            return sex;
        }
        private void Validation()
        {
            // student mag niet in database bestaan al (zelfde voornaam en achternaam
            //als velden leeg zijn kan je niemand toevoegen alle velden moeten ingevuld zijn 

        }

        private void AddStudentToDB()
        {
            if (AllFieldsAreFilled() == true)
            {
                Students newstudent = new Students(FirstNameTextBox.Text, LastNameTextBox.Text, StudyCombobox.SelectedIndex, GetSex());
                schoolbibDBContext.Students.Add(newstudent);
                schoolbibDBContext.SaveChanges();
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
            if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "" || StudyCombobox.SelectedIndex == -1 ||
                (FemaleRadioButton.IsChecked == false && MaleRadioButton.IsChecked == false))
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
