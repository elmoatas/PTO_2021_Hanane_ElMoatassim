﻿using BMI.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            periodComboBox.ItemsSource = Enum.GetValues(typeof(TimePeriod));
            periodComboBox.SelectedItem = TimePeriod.All;
            BmiDBContex bmidb = new BmiDBContex();
        }


        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveBMIButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void periodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
