using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{

    class DVD : Library
    {
        private int id;
        private int duration;
        private DVDGenre dvdGenre;
        private Language language;
        int languageIndex;
        int genreIndex;

        public DVD()
        {

        }

        public DVD(string title, string creator, long productnumber, int genreIndex, int languageIndex, int duration) : base(title, creator, productnumber)
        {
            this.languageIndex = languageIndex;
            this.genreIndex = genreIndex;
            GetDvdGenre();
            GetLanguage();
            this.duration = duration;
        }


        [Key]
        public int Id { get => id; set => id = value; }
        public int Duration { get => duration; set => duration = value; }
        private DVDGenre DvdGenre { get => dvdGenre; set => dvdGenre = value; }
        private Language Language { get => language; set => language = value; }
        [NotMapped]
        public int LanguageIndex { get => languageIndex; set => languageIndex = value; }
        public int GenreIndex { get => genreIndex; set => genreIndex = value; }


        public void GetDvdGenre()
        {
            switch (genreIndex)
            {
                case 0: dvdGenre = (DVDGenre)0; break;
                case 1: dvdGenre = (DVDGenre)1; break;
                case 2: dvdGenre = (DVDGenre)2; break;
                case 3: dvdGenre = (DVDGenre)3; break;
            }
        }
        public void GetLanguage()
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

         }


}
