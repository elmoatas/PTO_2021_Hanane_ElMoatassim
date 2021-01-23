﻿using System;
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
        public WindowModifyStudent()
        {
            InitializeComponent();
            ShowStudentsInListbox();
            PutStudyChoicesInComboBox();
            PutSexChoisesInComboBox();
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
            SexComboBox.SelectedItem = -1;
            StudyCombobox.SelectedIndex = -1;
            ShowIDLabel.Content = "";
        }
        private void EditInfo()
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            selected.FirstName = FirstNameTextBox.Text;
            selected.LastName = LastNameTextBox.Text;
            selected.Studyindex = StudyCombobox.SelectedIndex;
            selected.GetTheStudyChoiceName();
            selected.GetSex();
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
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            Students selected = (Students)StudentListbox.SelectedItem;
            studentRepository.DeleteStudent(selected);
            ShowStudentsInListbox();
            MakeAllFieldsEmpty();
        }

        private void AddLoans()
        {
            /* if (StudentListbox.SelectedItem != null)
             {
                 Students selected = (Students)StudentListbox.SelectedItem;
                 foreach (Library item in Library.LibraryList)
                 {
                     if (item.ID == selected.ItemID)
                     {
                         LoansOfSelectedStudentListbox.Items.Add(item);
                     }
                 }
             }*/
        }

        private void LoansOfSelectedStudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
