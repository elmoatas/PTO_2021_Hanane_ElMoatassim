﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Schoolbib
{
    class Book
    {
        string title;
        string author;
        bool available;
        int releaseDate;
        List<Book> books = new List<Book>();
        
        public Book()
        {

        }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public bool Available { get => available; set => available = value; }
        public int ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public void AddBookToList()
        {
            books.Add(new Book());
        }
        public void RemoveBookFromList()
        {
           // books.Remove();
        }
    }
}
