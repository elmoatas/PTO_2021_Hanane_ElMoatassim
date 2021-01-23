using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                    break;
                case DVD dvd:
                    dbContext.DVDs.Add(dvd);
                    break;
                case CD cd:
                    dbContext.CDs.Add(cd);
                    break;
            }
            dbContext.SaveChanges();
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
        //Update
        public void UpdateLibraryItems(Library library)
        {
            switch (library)
            {
                case Books book:
                    dbContext.Books.AddOrUpdate(book);
                    break;
                case DVD dvd:
                    dbContext.DVDs.AddOrUpdate(dvd);
                    break;
                case CD cd:
                    dbContext.CDs.AddOrUpdate(cd);
                    break;
            }
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
