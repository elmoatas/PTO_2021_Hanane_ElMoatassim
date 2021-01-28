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
        }

        //CREATE == insert 
        public void CreateLibraryItem(Library library)
        {
            //dbContext.Students.Attach((from Students in dbContext.Students
            //                              where Students.Id == library.ReserveStudentID
            //                              select Students).First());

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
            return dbContext.LibraryItems.ToList();
        }
        public List<Books> GetAllBooks()
        {
            return dbContext.Books.ToList();
        }
        public List<DVD> GetAllDvds()
        {

            return dbContext.DVDs.ToList();
        }
        public List<CD> GetAllCds()
        {
            return dbContext.CDs.ToList();
        }
        public Library GetItemWith(int id)
        {
            return (from Library in dbContext.LibraryItems
                    where Library.LibraryId == id
                    select Library).First();
        }
        public Library GetLibraryItemWithID(long id)
        {
            return (from Library in dbContext.LibraryItems
                    where Library.LibraryId == id
                    select Library).First();
        }
        public List<Library> GetItemsBasedOnAvailability(AvailabilityItem availability)
        {

            return dbContext.LibraryItems.Where((L) => L.Availability == availability).ToList();
        }

        public List<Library> GetBooksBasedOnAvailability(AvailabilityItem availability)
        {
            return dbContext.LibraryItems.Where((L) => L.Availability == availability && L is Books).ToList();
        }

        public List<Library> GetListItemReservedBy(Students student)
        {
            List<Library> reserved = dbContext.LibraryItems.Where((st) => st.ReserveStudentID == student.Id).ToList();
            return reserved;
        }
        public List<Library> GetbookItemsLoanedBy(Students student)
        {
            return dbContext.LibraryItems.Where(
                (L) => L.LoanerID == student.Id &&
                (L.Availability == AvailabilityItem.Gereserveerduitgeleend || L.Availability == AvailabilityItem.Uitgeleend)).ToList();
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
