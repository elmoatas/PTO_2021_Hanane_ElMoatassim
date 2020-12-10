using System;
using System.Collections.Generic;

namespace Demo_boekenapplicatie
{
    class Program
    {
        static void Main(string[] args)
        {
            Books myFirstBook = new Books("De Kleine Prins", "Blabla", 10); //classe books: public Books(string title, string author, int totalNumberOfPages)
            Books mySecondBook = new Books("Harry Potter", "Blabla", 10);

            List<Books> books = new List<Books>();
            books.Add(myFirstBook);
            books.Add(mySecondBook);
            myFirstBook.Reader = "Matthias";

            char action;

            do
            {
                Console.WriteLine("Welk boek wil je lezen?");
                action = Console.ReadKey().KeyChar;
                switch (action)
                {
                    case '1':
                        books[0].StartReading();
                        break;
                    case '2':
                        books[1].StartReading();
                        break;
                }

            } while (action != 'x');
        }
    }
}
