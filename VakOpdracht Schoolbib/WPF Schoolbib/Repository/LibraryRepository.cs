using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WPF_Schoolbib.Models
{
    public class LibraryRepository
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
        public Books GetBookWith(long ISBN)
        {

            return (from Books in dbContext.Books
                    where Books.ProductNumber == ISBN
                    select Books).First();
        }

        public List<Library> GetItemsBasedOnAvailability(AvailabilityItem availability)
        {
            List<Books> books = dbContext.Books.Where((b) => b.Availability == AvailabilityItem.Uitgeleend).ToList();
            List<DVD> dvd = dbContext.DVDs.Where((d) => d.Availability == AvailabilityItem.Uitgeleend).ToList();
            List<CD> cd = dbContext.CDs.Where((c) => c.Availability == AvailabilityItem.Uitgeleend).ToList();
            List<Library> Items = new List<Library>(); ;
            Items.AddRange(books);
            Items.AddRange(dvd);
            Items.AddRange(cd);
            return Items;
        }
        //Update
        public void UpdateLibraryItems(Library library)
        {
            dbContext.Entry<Library>(library).State = EntityState.Modified;
            dbContext.SaveChanges();
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
