using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Schoolbib
{
    class Book
    {
        string title;
        string author;
        bool available;
        int ISBN;
        List<Book> books = new List<Book>();

        public Book(string title, string author,  int iSBN)
        {
            this.title = title;
            this.author = author;
            this.available = available;
            ISBN = iSBN;
        }

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public bool Available { get => available; set => available = value; }
           public void AddBookToList()
        {
           
        }
        public void RemoveBookFromList()
        {
           // books.Remove();
        }
    }
}
