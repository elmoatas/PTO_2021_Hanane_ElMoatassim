﻿using System;
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
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowAddStudent.xaml
    /// </summary>
    public partial class WindowAddStudent : Window
    {
        public WindowAddStudent()
        {
            InitializeComponent();
            StudentListbox.ItemsSource = Students.AllStudentsList;
        }
        private void UpdateUI()
        {
     
            FirstNameTextBox.Text = "";
           LastNameTextBox.Text = "";

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //StudentListbox.ItemsSource = null;
            // StudentListbox.ItemsSource = Students.AllStudentsList;
            SchoolbibDBContext schoolbibDBContext = new SchoolbibDBContext();
            Students newstudent = new Students(FirstNameTextBox.Text, LastNameTextBox.Text);
            schoolbibDBContext.Students.Add(newstudent);
            schoolbibDBContext.SaveChanges();
            UpdateUI();
        }
    }
}
