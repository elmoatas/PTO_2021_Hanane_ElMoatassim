using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Text_editor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string inputText;
        public string InputText { get => inputText; set => inputText = value; }
       
        public Window1(string inputText)
        {
            InitializeComponent();
            this.inputText = inputText;
            ShowText();
        }
        private void ShowText()
        {
            inputTextBox.Text = inputText;
        }

        private void NoteTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                inputTextBox.Text += Environment.NewLine; 
            }
        }
    }
}
