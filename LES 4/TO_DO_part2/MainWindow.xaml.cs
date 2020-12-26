using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TO_DO_part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TodoItem> toDoList = new List<TodoItem>();
        bool startButtonPressed = false;
        bool finishedButtonPressed = false;
        public MainWindow()
        {
            InitializeComponent();
            UpdatUI();
            PrintFinishedLabel.Content = "-";
            PrintStartedLabel.Content = "-";
        }
        private void UpdatUI()
        {
            downButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            upButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            fulldownButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            fullUpButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            AddButton.IsEnabled = inputToDoTextbox.Text != "";
            if (toDoListbox.SelectedIndex != -1)
            {
                speciallabelStack1.Visibility = Visibility.Visible;
                speciallabelStack2.Visibility = Visibility.Visible;
            }
            else
            {
                speciallabelStack1.Visibility = Visibility.Hidden;
                speciallabelStack2.Visibility = Visibility.Hidden;
            }
        }
        private bool CheckTheInputTextbox()
        {
            bool check = true;
            if (inputToDoTextbox.Text == "" || toDoListbox.Items.Contains(inputToDoTextbox.Text))
            {
                check = false; // pasop als je spatie invult voegt hijdeze wel nog toE !
            }
            return check;
        }
        private void AddItemToList()
        {
            if (CheckTheInputTextbox())
            {
                TodoItem newItem = new TodoItem(inputToDoTextbox.Text);
                toDoListbox.Items.Add(newItem);
                inputToDoTextbox.Text = "";
            }
            else
            {
                inputToDoTextbox.Text = "";
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemToList();
            UpdatUI();
        }
        private void InputToDoTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddItemToList();
            }
            UpdatUI();
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
            UpdatUI();
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (toDoListbox.SelectedIndex + 1 <= toDoListbox.Items.Count)
            {
                GoUpOrGoDown(1);
            }
            UpdatUI();
        }
        private void FullUpDown(int placementOfItem)
        {
            object selectedItem = toDoListbox.SelectedItem;
            toDoListbox.Items.Remove(selectedItem);
            toDoListbox.Items.Insert(placementOfItem, selectedItem);
            toDoListbox.SelectedIndex = placementOfItem;
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
            if (toDoListbox.SelectedItem != null)
            {
                UpdatUI();
                TodoItem selected = (TodoItem)toDoListbox.SelectedItem;
                FillInInfo(selected);
            }
        }
        private void FillInInfo(TodoItem selected)
        {
            //TodoItem selected = (TodoItem)toDoListbox.SelectedItem;
            ItemNameTextbox.Text = selected.Name;
            DuedateDatePicker.SelectedDate = selected.DueDate;
            //"ColorCombobox"
            PrintStatusLabel.Content = selected.GetState();
            PrintStartedLabel.Content = selected.StartDate;
            PrintFinishedLabel.Content = selected.FinishDate;
            ExtraInfoTextbox.Text = selected.Information;
        }
        private void SaveInformation(TodoItem selected)
        {
            //TodoItem selected = (TodoItem)toDoListbox.SelectedItem;
            selected.Name = ItemNameTextbox.Text;
            selected.DueDate = DuedateDatePicker.SelectedDate.Value;
            //selected.Color
            selected.Information = ExtraInfoTextbox.Text;
        }

        private void StartTaskButton_Click(object sender, RoutedEventArgs e)
        {
            startButtonPressed = true;
            TodoItem selected = (TodoItem)toDoListbox.SelectedItem;
            selected.Start(startButtonPressed);
            //PrintStartedLabel.Content = selected.StartDate.ToString();
            FillInInfo(selected);
        }

        private void FinishTaskButton_Click(object sender, RoutedEventArgs e)
        {
            finishedButtonPressed = true;
            TodoItem selected = (TodoItem)toDoListbox.SelectedItem;
            selected.Stop(finishedButtonPressed);
            //PrintFinishedLabel.Content = selected.FinishDate;
            FillInInfo(selected);
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem selected = (TodoItem)toDoListbox.SelectedItem;
            SaveInformation(selected);
        }
    }
}
