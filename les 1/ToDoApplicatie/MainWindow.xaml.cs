using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (toDoListbox.SelectedItem != null)
            {
                toDoListbox.Items.Remove(toDoListbox.SelectedItem);
            }
        }

        private void InputToDoTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            //via stackoverflow:You can handle the keydown event of your TextBox control
            if (e.Key == Key.Enter)
            {
                AddButton_Click(sender, e);
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = toDoListbox.SelectedIndex - 1;
            if (newIndex < 0)
            {
                upButton.IsEnabled = false;
            }
            else
            {
                object selectedItem = toDoListbox.SelectedItem;
                toDoListbox.Items.Remove(selectedItem);
                toDoListbox.Items.Insert(newIndex, selectedItem);
                toDoListbox.SelectedIndex = newIndex;
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = toDoListbox.SelectedIndex + 1;
            if (newIndex >= toDoListbox.Items.Count)
            {
                downButton.IsEnabled = false;
            }
            else
            {
                object selectedItem = toDoListbox.SelectedItem;
                toDoListbox.Items.Remove(selectedItem);
                toDoListbox.Items.Insert(newIndex, selectedItem);
                toDoListbox.SelectedIndex = newIndex;
            }
        }

        private void InputToDoTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            AddButton.IsEnabled = true;
            ChangeVisibility(Visibility.Hidden);
        }

        private void ToDoListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeVisibility(Visibility.Visible);
            downButton.IsEnabled = true;
            upButton.IsEnabled = true;
        }
        private void ColorPicker(string buttonColor)
        {
            ListBoxItem selected = new ListBoxItem();

            if (buttonColor == "red")
            {
                selected.Foreground = Brushes.Red;
            }
            if (buttonColor == "yellow")
            {
                selected.Foreground = Brushes.Yellow;
            }
            if (buttonColor == "green")
            {
                selected.Foreground = Brushes.Green;
            }

        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selected = (ListBoxItem)toDoListbox.SelectedItem;
            selected.Foreground = Brushes.Red;
        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker("green");
        }

        private void YellowButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker("yellow");
        }
    }
}




