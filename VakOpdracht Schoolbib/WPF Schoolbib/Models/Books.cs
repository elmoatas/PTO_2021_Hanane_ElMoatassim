using System.ComponentModel.DataAnnotations;

namespace WPF_Schoolbib.Models
{

    class Books 
    {
        private int id;
        private string title;
        private string creator;
        private long productNumber;
        private int pages;
        private string publisher;
        private Language language;
        private BookGenre bookGenre;

        
        public Books(string title, string creator, long productnumber, int genreIndex, int languageIndex, int pages, string publisher) 
        {
            this.title = title;
            this.creator = creator;
            this.productNumber = productnumber;
            GetBookGenre(genreIndex);
            GetLanguage(languageIndex);
            this.pages = pages;
            this.publisher = publisher;
        }


        [Key]
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Creator { get => creator; set => creator = value; }
        public long ProductNumber { get => productNumber; set => productNumber = value; }
        public int Pages { get => pages; set => pages = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        internal Language Language { get => language; set => language = value; }
        public BookGenre BookGenre { get => bookGenre; set => bookGenre = value; }



        private void GetBookGenre(int genreIndex)
        {
            switch (genreIndex)
            {
                case 0: bookGenre = (BookGenre)0; break;
                case 1: bookGenre = (BookGenre)1; break;
                case 2: bookGenre = (BookGenre)2; break;
                case 3: bookGenre = (BookGenre)3; break;
                case 4: bookGenre = (BookGenre)4; break;
                case 5: bookGenre = (BookGenre)5; break;
            }
        }
        private void GetLanguage(int languageIndex)
        {
            switch (languageIndex)
            {
                case 0: language = (Language)0; break;
                case 1: language = (Language)1; break;
                case 2: language = (Language)2; break;
                case 3: language = (Language)3; break;
                case 4: language = (Language)4; break;
            }
        }

        public override string ToString()
        {
            return $" {productNumber} - {title} ";
        }

    }
}
