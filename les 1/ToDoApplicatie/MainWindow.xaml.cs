using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoApplicatie
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

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            //Toevoegen van todo in listbox
            ListBoxItem todo = new ListBoxItem();
            todo.Content = inputToDoTextbox.Text;
            if (!toDoListbox.Items.Contains(inputToDoTextbox.Text) && inputToDoTextbox.Text != "")
            {
                toDoListbox.Items.Add(inputToDoTextbox.Text);
                inputToDoTextbox.Text = "";
            }
            else
            {
                AddButton.IsEnabled = false;
                inputToDoTextbox.Text = "";
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            toDoListbox.Items.Remove(toDoListbox.SelectedItem);

        }
        private void verify()
        {


        }
        private void inputToDoTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            //via stackoverflow:You can handle the keydown event of your TextBox control
            if (e.Key == Key.Enter)
            {
                addButton_Click(sender, e);
            }
        }
    }
}




