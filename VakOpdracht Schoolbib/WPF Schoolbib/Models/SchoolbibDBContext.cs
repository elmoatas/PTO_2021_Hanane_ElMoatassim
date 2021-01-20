using System.Data.Entity;
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
        public DbSet<Library> LibraryItems { get; set; }
    }
}
