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
            toDoListbox.ItemsSource = toDoList;
        }
        private void EnableButtons()
        {
            downButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            upButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            fulldownButton.IsEnabled = toDoListbox.SelectedIndex + 1 < toDoListbox.Items.Count;
            fullUpButton.IsEnabled = toDoListbox.SelectedIndex > 0;
            AddButton.IsEnabled = inputToDoTextbox.Text != "";
        }

        private void AddItemToList()
        {
            string inputToDo = inputToDoTextbox.Text;
            bool contains = toDoListbox.Items.Contains(inputToDo);
            // bool contains = toDoList.Contains();// check if the list already contains the todo
            if (inputToDoTextbox.Text != "") //contains && 
            {
                TodoItem newItem = new TodoItem();
                toDoList.Add(newItem);
                newItem.GetName = inputToDoTextbox.Text;
                inputToDoTextbox.Text = "";
            }
            else
            {
                inputToDoTextbox.Text = "nee";
            }

            /* if (!toDoListbox.Items.Contains(inputToDoTextbox.Text) && inputToDoTextbox.Text != "")
             {
                 newItem.GetName = inputToDoTextbox.Text;
                 toDoList.Add(newItem);
                 inputToDoTextbox.Text = "";
             }
             else
             {
                 inputToDoTextbox.Text = "";
             }*/
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //Toevoegen van todo in listbox
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
            ItemTextbox.Text = selectedToDo.GetName;

            toDoListbox.ItemsSource = toDoList;
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

        }
    }
}
