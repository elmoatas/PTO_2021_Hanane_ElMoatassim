using System;
using System.IO;
using System.Windows;

namespace Text_editor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //private string path;
        public static string path { get; set; }
       public Window1()
        {
            InitializeComponent();
            StreamReader();
            Title = path;
        }

        private void StreamReader()
        {
            if (path != null)
            {
                StreamReader inputStream = File.OpenText(path);
                string line = inputStream.ReadLine();
                while (line != null)
                {
                    inputTextBox.AppendText(line);
                    inputTextBox.AppendText(Environment.NewLine);
                    line = inputStream.ReadLine();
                }
                inputStream.Close();
            }
        }

        private void Write()
        {
            StreamWriter outputStream = File.CreateText(path);
            outputStream.WriteLine(inputTextBox.Text);
            outputStream.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Write();
        }
    }
}
