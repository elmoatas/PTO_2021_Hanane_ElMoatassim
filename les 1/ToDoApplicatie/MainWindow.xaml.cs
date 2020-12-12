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
            ChangeVisibilityAndEnableButtons();
        }
        private void ChangeVisibilityAndEnableButtons()
        {
            if (toDoListbox.SelectedIndex != -1)
            {
                specialButtonsStack.Visibility = Visibility.Visible;
            }
            else
            {
                specialButtonsStack.Visibility = Visibility.Hidden;
            }
            downButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            upButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            fulldownButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            fullUpButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            AddButton.IsEnabled = inputToDoTextbox.Text != "";
        }

        private void AddItemToList()
        {
            if (!toDoListbox.Items.Contains(inputToDoTextbox.Text) && inputToDoTextbox.Text != "")
            {
                toDoListbox.Items.Add(inputToDoTextbox.Text);
                inputToDoTextbox.Text = "";
            }
            else
            {
                inputToDoTextbox.Text = "";
            }

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Toevoegen van todo in listbox
            AddItemToList();
            ChangeVisibilityAndEnableButtons();
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
            if (e.Key == Key.Enter)
            {
                AddItemToList();
            }
            ChangeVisibilityAndEnableButtons();
        }
        private void GoUpOrGoDown(int upOrDown)
        {
            int newIndex = toDoListbox.SelectedIndex + upOrDown;
            object selectedItem = toDoListbox.SelectedItem;
            toDoListbox.Items.Remove(selectedItem);
            toDoListbox.Items.Insert(newIndex, selectedItem);
            toDoListbox.SelectedIndex = newIndex;
        }
        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (toDoListbox.SelectedIndex >= 0)
            {
                GoUpOrGoDown(-1);
            }
            ChangeVisibilityAndEnableButtons();
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (toDoListbox.SelectedIndex + 1 <= toDoListbox.Items.Count)
            {
                GoUpOrGoDown(1);
            }
            ChangeVisibilityAndEnableButtons();
        }
        private void FullUpDown(int placementOfItem)
        {
            object selectedItem = toDoListbox.SelectedItem;
            toDoListbox.Items.Remove(selectedItem);
            toDoListbox.Items.Insert(placementOfItem, selectedItem);
            toDoListbox.SelectedIndex = placementOfItem;
            upButton.IsEnabled = false;
            fullUpButton.IsEnabled = false;
        }
        private void fullUpButton_Click(object sender, RoutedEventArgs e)
        {
            FullUpDown(0);
        }
        private void fulldownButton_Click(object sender, RoutedEventArgs e)
        {
            FullUpDown(toDoListbox.Items.Count - 1);
        }
        private void ToDoListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeVisibilityAndEnableButtons();
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
            // ListBoxItem selected = (ListBoxItem)toDoListbox.SelectedItem;
            //selected.Background = Brushes.Red;
        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorPicker("green");
        }

        private void YellowButton_Click(object sender, RoutedEventArgs e)
        {
            //ColorPicker("yellow");
        }


    }
}




