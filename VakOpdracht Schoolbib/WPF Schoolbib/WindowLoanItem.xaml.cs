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
    public partial class WindowLoanItem : Window
    {
        public WindowLoanItem()
        {
            InitializeComponent();
           // StudentListbox.ItemsSource = null;
            //StudentListbox.ItemsSource = Students.AllStudentsList;
        }
       
        private void CDRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
           // CatalogusListbox.Items.Clear();
            /*foreach (Library item in Library.LibraryList)
            {
                if ( item is CD)
                {
                    CatalogusListbox.Items.Add(item);
                }
                
            }*/
        }

        private void DvdRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            //CatalogusListbox.Items.Clear();
            /*foreach (Library item in Library.LibraryList)
            {
                if (item is DVD)
                {
                    CatalogusListbox.Items.Add(item);
                }

            }*/
        }

        private void BoekRadiobutton_Checked(object sender, RoutedEventArgs e)
        {
            /*CatalogusListbox.Items.Clear();
          foreach (Library item in Library.LibraryList)
           {
               if (item is Books)
               {
                   CatalogusListbox.Items.Add(item);
               }

           }*/
        }

        private void CatalogusListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void loanButton_Click(object sender, RoutedEventArgs e)
        {
            //Library selectedItemCatalogus = (Library)CatalogusListbox.SelectedItem;       //geselecteerde item
            //Students selectedStudent = (Students)StudentListbox.SelectedItem;
           // selectedStudent.ItemID = selectedItemCatalogus.ID;
            //selectedItemCatalogus.LoanerID = selectedStudent.ID;
        }
    }
}
