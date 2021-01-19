using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Schoolbib.Models
{
    abstract class Library
    {
        static List<Library> libraryList = new List<Library>();
        string title;
        string author;
        int Id;
       int loanerID;

        public Library(string title, string author, int ID)
        {
            this.title = title;
            this.author = author;
            this.Id = ID;
            libraryList.Add(this);
        }

        public static List<Library> LibraryList { get => libraryList; set => libraryList = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int ID { get => Id; set => Id = value; }
        public int LoanerID { get => loanerID; set => loanerID = value; }

        public override string ToString() 
        {
            return title + " - " + author;
        }
    }
}
