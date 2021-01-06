using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Forms = System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Text_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedPath;
        string path;
        string fileName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StreamWriter()
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine();
            streamWriter.Close();
        }

        private void pathButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderBrowserDialog();
        }

        private void OpenFolderBrowserDialog()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == Forms.DialogResult.OK)
            {
                selectedPath = folderBrowserDialog.SelectedPath;
                pathLabel.Content = selectedPath;
                LoadDataFromFolder();
            }
            else if (dialogResult == Forms.DialogResult.Cancel)
            {
                MessageBox.Show("Geen selectie");
            }
        }

        private void LoadDataFromFolder()
        {
            filesListBox.Items.Clear();
            // load data
            string[] files = Directory.GetFiles(selectedPath);

            foreach (string file in files)
            {
                if (file.EndsWith(".txt"))
                {
                    filesListBox.Items.Add(file);
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            fileName = fileNameTextBox.Text;
            path = Path.Combine(selectedPath, fileName + ".txt");
            filesListBox.Items.Add(path);
            fileNameTextBox.Text = "";
            StreamWriter();
        }

        private void filesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            path = filesListBox.SelectedItem.ToString();
           OpenNewWindow();

        }

        //new window
        private void OpenNewWindow()
        {
            Window1.path = path;
            Window1.filename = fileName;
            Window1 window1 = new Window1();
            window1.Show();      
        }
    
      
    }
}
