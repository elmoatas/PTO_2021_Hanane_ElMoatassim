using System;

namespace Case
{
    class Bericht
    {
        // Private members / class attributes / class variables
        private string sender;
        private string content;
        private DateTime date;
        private string receiver;
        // Constructor 
        public Bericht()
        {

        }
        // Properties / getters & setters
        public string Sender
        {
            get { return sender; }
        }
        public string Content
        {
            get { return content; }
        }
        public DateTime Date
        {
            get { return date; }
        }
        public string Receiver
        {
            get { return receiver; }
        }
        // Methodes (public & private)
        public string Display()
        {
            string display="";
            return display;
        }
        public void Send()
        {


        }
    }
}
