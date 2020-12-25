using System;
using System.Windows.Media;

namespace TO_DO_part2
{
    class TodoItem
    {
        //private members
        private string name;
        private Brush color;
        private DateTime dueDate;
        private DateTime startDate;
        private DateTime finishDate;
        private string info;

        //constructor
    
        public TodoItem()
        {
        }

        //properties
        public string Name { get; set; }

        public Brush Color { get; set; }

        public DateTime DueDate { get; set; }
        public string Information { get; set; }

        public DateTime StartDate
        {
            get { return startDate; }
        }
        public DateTime FinishDate
        {
            get { return finishDate; }
        }

        //methodes

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
