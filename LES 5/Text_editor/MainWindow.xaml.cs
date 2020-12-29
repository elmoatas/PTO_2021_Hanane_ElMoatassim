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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StreamWriter(string path)
        {


            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("Hello World2!");
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
            string fileName = fileNameTextBox.Text;
            path = Path.Combine(selectedPath, fileName + ".txt");
            filesListBox.Items.Add(path);
            fileNameTextBox.Text = "";
            StreamWriter(path);
        }

        private void filesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            path = filesListBox.SelectedItem.ToString();
            OpenNewWindow(StreamReader(path));
        }

        //new window
        private void OpenNewWindow(string inputText)
        {
            Window1 windowTwo = new Window1(inputText);
            windowTwo.Show();
        }

        private string StreamReader(string path)
        {
            // open streamreader
            StreamReader streamReader = new StreamReader(path);

            // bestand lijn per lijn inlezen
            string line = streamReader.ReadLine();
            while (line != null)
            {
                line = streamReader.ReadLine();
            }
            return line;

            // sluit streamreader
            //streamReader.Close();

        }
    }
}
