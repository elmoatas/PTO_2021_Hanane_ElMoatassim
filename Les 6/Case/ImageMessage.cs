using System;
using System.Windows.Controls;

namespace Case
{
    class ImageMessage
    {
        // Private members / class attributes / class variables
        string sender;
        private string content;
        private DateTime date;
        private string receiver;
        private Image image;

        // Constructor 
        public ImageMessage()//string sender, string content, DateTime date, string receiver, Image image)
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
        public Image Im
        {
            get { return image; }
        }
        // Methodes (public & private)
        public string Display()
        {
            string display = "";
            return display;
        }
        public void Send()
        {

        }
        public Image LoadImage()
        {
            return image;
        }
    }
}
