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

namespace WPF_Schoolbib
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoanButton_Click(object sender, RoutedEventArgs e)
        {
            WindowLoanItem windowLoan = new WindowLoanItem();
            windowLoan.ShowDialog();
        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            WindowStudent windowStudent = new WindowStudent();
            windowStudent.ShowDialog();
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            WindowCatalog windowCatalog = new WindowCatalog();
            windowCatalog.ShowDialog();
        }
    }
}
