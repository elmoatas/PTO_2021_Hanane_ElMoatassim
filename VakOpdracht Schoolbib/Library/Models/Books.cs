using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryModels.Models
{

    public class Books : Library
    {

        public Books()
        {

        }
        public Books(int languageIndex, int pages, int genreIndex, string publisher)
        {
            this.LanguageIndex = languageIndex;
            this.Pages = pages;
            this.GenreIndex = genreIndex;
            this.Publisher = publisher;
        }

        [Key]
        public int Id { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public int LanguageIndex { get; set; }
        public int GenreIndex { get; set; }

        [NotMapped]
        public string Language { get => GetLanguage(); }
        [NotMapped]
        public string Bookgenre { get => GetBookGenre(); }


        private string GetBookGenre()
        {
            switch (GenreIndex)
            {
                case 0: return BookGenre.Thriller.ToString();
                case 1: return BookGenre.Fantasy.ToString();
                case 2: return BookGenre.ScienceFictie.ToString();
                case 3: return BookGenre.Romance.ToString();
                case 4: return BookGenre.nonFictie.ToString();
                case 5: return BookGenre.Avontuur.ToString();
                default: return "";
            }
        }

        private string GetLanguage()
        {
            switch (LanguageIndex)
            {
                case 0: return LanguageEnum.FR.ToString();
                case 1: return LanguageEnum.NL.ToString();
                case 2: return LanguageEnum.ENG.ToString();
                case 3: return LanguageEnum.DUI.ToString();
                case 4: return LanguageEnum.SPA.ToString();
                default: return "";
            }
        }


    }
}
