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
            ChangeVisibility(Visibility.Hidden);
            AddButton.IsEnabled = false;
        }
        private void ChangeVisibility(Visibility a)
        {
            loadButton.Visibility = a;
            deleteButton.Visibility = a;
            saveButton.Visibility = a;
            upButton.Visibility = a;
            downButton.Visibility = a;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Toevoegen van todo in listbox
            ListBoxItem todo = new ListBoxItem();
            if (!toDoListbox.Items.Contains(inputToDoTextbox.Text) && inputToDoTextbox.Text != "")
            {

                toDoListbox.Items.Add(inputToDoTextbox.Text);
                inputToDoTextbox.Text = "";
                AddButton.IsEnabled = true;
            }
            else
            {

                inputToDoTextbox.Text = "";
                AddButton.IsEnabled = false;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (toDoListbox.SelectedItem != null)
            {
                toDoListbox.Items.Remove(toDoListbox.SelectedItem);

            }

        }

        private void inputToDoTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            //via stackoverflow:You can handle the keydown event of your TextBox control
            if (e.Key == Key.Enter)
            {
                AddButton_Click(sender, e);
            }
        }


        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            toDoListbox.SelectedIndex = toDoListbox.SelectedIndex - 1;
        }

        private void inputToDoTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            AddButton.IsEnabled = true;
            ChangeVisibility(Visibility.Hidden);
        }

        private void toDoListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeVisibility(Visibility.Visible);
        }

   
    }
}




