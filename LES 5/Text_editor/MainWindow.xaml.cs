using System;
using System.Windows;
using System.Windows.Forms;
using Forms = System.Windows.Forms;
namespace Text_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedPath;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenTheFile()
        {
            FolderBrowserDialog folderBrowseDialog = new FolderBrowserDialog();

            folderBrowseDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult dialogResult = folderBrowseDialog.ShowDialog();

            if (dialogResult == Forms.DialogResult.OK)
            {
                selectedPath = folderBrowseDialog.SelectedPath;
                pathLabel.Content = selectedPath;
            }
        }

        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            OpenTheFile();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
