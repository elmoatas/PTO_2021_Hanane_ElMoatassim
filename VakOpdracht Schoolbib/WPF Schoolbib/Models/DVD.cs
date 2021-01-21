using System.ComponentModel.DataAnnotations;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{

    class DVD 
    {
        private int id;
        private string title;
        private string creator;
        private long productNumber;
        private int duration;
        private DVDGenre dvdGenre;
        private Language language;

       

        public DVD(string title, string creator, long productnumber, int genreIndex, int languageIndex, int duration)
        {
            this.title = title;
            this.creator = creator;
            this.productNumber = productnumber;
            GetDvdGenre(genreIndex);
            GetLanguage(languageIndex);
            this.duration = duration;
        }


        [Key]
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Creator { get => creator; set => creator = value; }
        public long ProductNumber { get => productNumber; set => productNumber = value; }
        public int Duration { get => duration; set => duration = value; }
        private DVDGenre DvdGenre { get => dvdGenre; set => dvdGenre = value; }
        private Language Language { get => language; set => language = value; }

        private void GetDvdGenre(int genreIndex)
        {
            switch (genreIndex)
            {
                case 0: dvdGenre = (DVDGenre)0; break;
                case 1: dvdGenre = (DVDGenre)1; break;
                case 2: dvdGenre = (DVDGenre)2; break;
                case 3: dvdGenre = (DVDGenre)3; break;
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
