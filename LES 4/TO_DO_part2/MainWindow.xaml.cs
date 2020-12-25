using System.ComponentModel;
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
        BindingList<TodoItem> toDoList = new BindingList<TodoItem>();

        public MainWindow()
        {
            InitializeComponent();
            EnableButtons();

            // toDoListbox.ItemsSource = toDoList;
        }
        private void EnableButtons()
        {
            downButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            upButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            fulldownButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            fullUpButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            AddButton.IsEnabled = inputToDoTextbox.Text != "";
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
                TodoItem newItem = new TodoItem();
                toDoList.Add(newItem);
                newItem.Name = inputToDoTextbox.Text;
                toDoListbox.Items.Add(newItem.Name);
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
            EnableButtons();
        }
        private void InputToDoTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddItemToList();
            }
            EnableButtons();
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
            EnableButtons();
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (toDoListbox.SelectedIndex + 1 <= toDoListbox.Items.Count)
            {
                GoUpOrGoDown(1);
            }
            EnableButtons();
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
            if (toDoListbox.SelectedItem != null)
            {
                EnableButtons();
                TodoItem selectedToDo = (TodoItem)toDoListbox.SelectedItem;
                FillInfo(selectedToDo);
            }
        }
        private void FillInfo(TodoItem selectedToDo)
        {
            ItemTextbox.Text = selectedToDo.Name;
            //selectedToDo.DueDate = DuedateDatePicker.SelectedDate;
            //ExtraInfoTextbox.Text = selectedToDo.GetSetInformation;
            //toDoListbox.ItemsSource = toDoList;

        }

        private void StartTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FinishTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem selectedToDo = (TodoItem)toDoListbox.SelectedItem;

        }
    }
}
