using System.Data.Entity;
using WPF_Schoolbib.Models;


namespace WPF_Schoolbib
{
    public class SchoolbibDBContext : DbContext
    {
        // Databank Bibliotheek
        public SchoolbibDBContext() : base("data source = (localdb)\\MSSQLLocalDB; initial catalog = SchoolBib ")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //Tabellen 
        public DbSet<Students> Students { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Library> LibraryItems { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<DVD> DVDs { get; set; }

    }
}
