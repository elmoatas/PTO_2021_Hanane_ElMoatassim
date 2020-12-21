using System;
using System.Windows.Media;

namespace TO_DO_part2
{
    class TodoItem
    {
        private string name;
        private Brush color;
        private DateTime dueDate;
        private DateTime startDate;
        private DateTime finishDate;
        private string info;
        //constructor
        public TodoItem(string name)
        {
            this.name = name;

        }

        public TodoItem()
        {

        }

        //properties
        //methodes
        public string GetName
        {
            get { return name; }
            set { name = value; }
        }
        public override string ToString()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public Brush GetColor
        {

            get { return color; }
        }
        public void SetColor(Brush color)
        {

        }
        public DateTime GetStartDate
        {

            get { return dueDate; }
        }
        public DateTime GetFinishDate()
        {
            DateTime finishTime = DateTime.Now;
            return finishTime;
        }
        public DateTime GetDueDate()
        {
            DateTime dueTime = DateTime.Now;
            return dueTime;
        }
        public void SetDueDate(DateTime dueDate)
        {

        }
        public void Start()
        {

        }
        public void Stop()
        {

        }
        public string GetState()
        {
            string state = "";
            return state;
        }

    }
}
