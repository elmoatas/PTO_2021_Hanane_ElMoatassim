using System;
using System.Windows.Media;

namespace TO_DO_part2
{
    class TodoItem
    {
        //private members
        private string name;
        private Brush color;
        private int SelectedComboBoxItemColor;
        private DateTime dueDate;
        private string startDate;
        private string finishDate;
        private string info;

        //constructor
        public TodoItem()
        {

        }
        public TodoItem(string name)
        {
            this.name = name;
        }

        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Brush Color
        {
            get { return color; }
            set { color = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public string Information
        {
            get { return info; }
            set { info = value; }
        }
        public int IndexComboBoxItem
        {
            get { return SelectedComboBoxItemColor; }
            set { SelectedComboBoxItemColor = value; }
        }
        public string StartDate
        {
            get { return startDate; }
        }
        public string FinishDate
        {
            get { return finishDate; }
        }

        //methodes
        public void Start(bool buttonPressed)
        {
            if (buttonPressed)
            {
                startDate = DateTime.UtcNow.ToString();
            }
            else
            {
                startDate = "---";
            }

        }
        public void Stop(bool buttonPressed)
        {
            if (buttonPressed)
            {
                finishDate = DateTime.UtcNow.ToString();
            }
            else
            {
                startDate = "---";
            }
        }
        public string GetState()
        {
            string state = "";
            if (startDate == null)
            {
                state = "new - to do";

            }
            else if (finishDate != null)
            {
                state = "done";
            }
            else if (finishDate == null && StartDate != null)
            {
                state = " in progress";
            }
            return state;
        }
        public Brush GetColor(int index)
        {
            switch (index)
            {
                case 0: color = Brushes.Red; break;
                case 1: color = Brushes.Yellow; ; break;
                case 2: color = Brushes.Green; break;
            }
            return color;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
