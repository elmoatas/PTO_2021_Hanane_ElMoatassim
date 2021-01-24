using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WPF_Schoolbib.Models
{
    class LibraryRepository
    {
        SchoolbibDBContext dbContext = new SchoolbibDBContext();
        public LibraryRepository()
        {
            dbContext.Database.CreateIfNotExists();
        }

        //CREATE == insert 
        public void CreateLibraryItem(Library library)
        {
            switch (library)
            {
                case Books book:
                    dbContext.Books.Add(book);
                    dbContext.SaveChanges();
                    break;
                case DVD dvd:
                    dbContext.DVDs.Add(dvd);
                    dbContext.SaveChanges();
                    break;
                case CD cd:
                    dbContext.CDs.Add(cd);
                    dbContext.SaveChanges();
                    break;
            }

        }
        //Read ==Select 
        public List<Library> GetAllLibraryItems()
        {

            List<Books> books = dbContext.Books.ToList();
            List<DVD> dvd = dbContext.DVDs.ToList();
            List<CD> cd = dbContext.CDs.ToList();

            List<Library> allLibraryItems = new List<Library>(); ;
            allLibraryItems.AddRange(books);
            allLibraryItems.AddRange(dvd);
            allLibraryItems.AddRange(cd);
            return allLibraryItems;
        }
        public List<Books> GetAllBooks()
        {

            List<Books> books = dbContext.Books.ToList();
            return books;
        }
        public List<DVD> GetAllDvds()
        {
            List<DVD> dvd = dbContext.DVDs.ToList();
            return dvd;
        }
        public List<CD> GetAllCds()
        {
            List<CD> cd = dbContext.CDs.ToList();
            return cd;
        }
        public List<Library> GetOnlyAvailableItems()
        {
            List<Books> books = dbContext.Books.Where((b)=> b.Availability == AvailabilityItem.Aanwezig).ToList();
            List<DVD> dvd = dbContext.DVDs.Where((d) => d.Availability == AvailabilityItem.Aanwezig).ToList();
            List<CD> cd = dbContext.CDs.Where((c) => c.Availability == AvailabilityItem.Aanwezig).ToList();
            List<Library> allAvailableItems = new List<Library>(); ;
            allAvailableItems.AddRange(books);
            allAvailableItems.AddRange(dvd);
            allAvailableItems.AddRange(cd);
            return allAvailableItems;
        }
        //Update
        public void UpdateLibraryItems(Library library)
        {
            switch (library)
            {
                case Books book:
                    dbContext.SaveChanges();
                    break;
                case DVD dvd:
                    dbContext.SaveChanges();
                    break;
                case CD cd:
                    dbContext.SaveChanges();
                    break;
            }

        }
        //Delete
        public void DeleteLibraryItems(Library library)
        {
            switch (library)
            {
                case Books book:
                    dbContext.Entry(book).State = EntityState.Deleted;
                    dbContext.Books.Remove(book);
                    break;
                case DVD dvd:
                    dbContext.Entry(dvd).State = EntityState.Deleted;
                    dbContext.DVDs.Remove(dvd);
                    break;
                case CD cd:
                    dbContext.Entry(cd).State = EntityState.Deleted;
                    dbContext.CDs.Remove(cd);
                    break;
            }
            dbContext.SaveChanges();
        }
    }
}
