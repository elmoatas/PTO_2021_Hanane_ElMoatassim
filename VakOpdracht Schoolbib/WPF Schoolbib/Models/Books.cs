using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF_Schoolbib.Models
{

    public class Books :Library
    {
        private int id;
        private int pages;
        private string publisher;
        private Language language;
        private BookGenre bookGenre;
        int languageIndex;
        int genreIndex;

        public Books()
        {

        }
        public Books(string title, string creator, long productnumber, AvailabilityItem availability, int genreIndex, int languageIndex, int pages, string publisher):base(title, creator, productnumber, availability)
        {
            this.languageIndex = languageIndex;
            this.genreIndex = genreIndex;
            GetBookGenre();
            GetLanguage();
            this.pages = pages;
            this.publisher = publisher;
        }


        [Key]
        public int Id { get => id; set => id = value; }
        public int Pages { get => pages; set => pages = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public Language Language { get => language; set => language = value; }
        public BookGenre BookGenre { get => bookGenre; set => bookGenre = value; }
        [NotMapped]
        public int LanguageIndex { get => languageIndex; set => languageIndex = value; }
        public int GenreIndex { get => genreIndex; set => genreIndex = value; }

        public void GetBookGenre()
        {
            switch (GenreIndex)
            {
                case 0: bookGenre = (BookGenre)0 ; break;
                case 1: bookGenre = (BookGenre)1; break;
                case 2: bookGenre = (BookGenre)2; break;
                case 3: bookGenre = (BookGenre)3; break;
                case 4: bookGenre = (BookGenre)4; break;
                case 5: bookGenre = (BookGenre)5; break;
            }
        }
        public void GetLanguage()
        {
            switch (LanguageIndex)
            {
                case 0: language = (Language)0; break;
                case 1: language = (Language)1; break;
                case 2: language = (Language)2; break;
                case 3: language = (Language)3; break;
                case 4: language = (Language)4; break;
            }
        }

       
    }
}
