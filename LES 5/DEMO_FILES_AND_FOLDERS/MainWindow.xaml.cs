using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEMO_FILES_AND_FOLDERS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Folderbrowserdialog { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            openFolderBrowserDialog();
        }
        private void openFolderBrowserDialog()
        {
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void filesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
