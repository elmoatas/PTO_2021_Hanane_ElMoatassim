﻿using System.Data.Entity;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{
    class SchoolbibDBContext : DbContext
    {
        // Databank Bibliotheek
        public SchoolbibDBContext():base ("data source = (localdb)\\MSSQLLocalDB; initial catalog = SchoolBib ")
        {

        }

        //Tabellen 
        public DbSet<Students> Students { get; set; }
        //public DbSet<Library> LibraryItems { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<DVD> DVDs { get; set; }
       
    }
}