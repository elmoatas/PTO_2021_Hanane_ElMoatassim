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
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for WindowLoanItem.xaml
    /// </summary>
    public partial class WindowReturnItem : Window
    {
        public WindowReturnItem()
        {
            InitializeComponent();
            //ShowInfo();
        }

        private void ShowInfo() 
        {
            //StudentListbox.ItemsSource = null;
            //StudentListbox.ItemsSource = Students.AllStudentsList;
        }
        private void ShowItems() 
        {
           /* Students selectedStudent = (Students)StudentListbox.SelectedItem;
            foreach (Library item in Library.LibraryList)
            {
                if (item.LoanerID== selectedStudent.ID)
                {
                    LoansListbox.Items.Add(item);
                }
            }*/
        }

        private void StudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // ShowItems();
        }

        private void BringBackButton_Click(object sender, RoutedEventArgs e)
        {/*
            Students selectedStudent = (Students)StudentListbox.SelectedItem;
            Library selectedItem = (Library)LoansListbox.SelectedItem;
            if (selectedItem.LoanerID==selectedStudent.ID)
            {
                selectedItem.LoanerID = 0;
                LoansListbox.Items.Remove(selectedItem);
            }*/
        }
    }
}
