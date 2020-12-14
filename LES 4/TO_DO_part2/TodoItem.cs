using System;
using System.Windows.Media;

namespace TO_DO_part2
{
    class TodoItem
    {
        private string name;
        private Brush color;
        private DateTime duedate;
        private DateTime startDate;
        private DateTime finishDate;
        private string info;
        //constructor
        public TodoItem( string name, Brush color)
        {
            this.name = name;
            this.color = color;
        }

        public TodoItem()
        {

        }

        //properties
        //methodes
        public string GetName()
        {
            string name = "";
            return name;
        }
        public void SetName(string name)
        {

        }
        public Brush GetColor()
        {
            Brush color = Brushes.Transparent;
            return color ;
        }
        public void SetColor(Brush color)
        {

        }
        public DateTime GetStartDate() 
        {
            DateTime dueTime = DateTime.Now;
            return dueTime;
        }
        public DateTime GetFinishDate() 
        {
            DateTime finishTime = DateTime.Now;
            return finishTime;
        }
        public DateTime GetDueDate()
        {
            DateTime dueTime= DateTime.Now;
            return dueTime;
        }
        public void SetDueDate(DateTime dueDate)
        {

        }
        public void Start()
        {

        }
        public void Stop ()
        {
        
        }
        public string GetState()
        {
            string state="";
            return state;
        }
    
    }
}
