using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Schoolbib.Models
{
    abstract class Library
    {
       // static List<Library> libraryList = new List<Library>();
        private string title;
        private string author;
        private int id;
        //private int loanerID;
        private Students student;

        public Library(string title, string author, int ID)
        {
            this.title = title;
            this.author = author;
            this.id = ID;
           // libraryList.Add(this);
        }

        [Key]
        public int ID { get => id; set => id = value; }
        //public static List<Library> LibraryList { get => libraryList; set => libraryList = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        
        //public int LoanerID { get => loanerID; set => loanerID = value; }

        public override string ToString() 
        {
            return title + " - " + author;
        }
    }
}
