using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{

    public class DVD : Library
    {
   

        public DVD()
        {

        }

        public DVD(int languagIndex,int duration, int genreIndex)
        {
            this.LanguageIndex = languagIndex;
            this.Duration = duration;
            this.GenreIndex = genreIndex;
        }
       

        [Key]
        public int Id { get ; set; }
        public int Duration { get; set ; }
        public int LanguageIndex { get; set; }
        public int GenreIndex { get; set; }

        [NotMapped]
        public string DvdGenre { get => GetDvdGenre();}
        [NotMapped]
        public string Language { get => GetLanguage();}
      

        private string GetDvdGenre()
        {
            switch (GenreIndex)
            {
                case 0: return DVDGenre.Actie.ToString(); 
                case 1: return DVDGenre.Fantasy.ToString(); 
                case 2: return DVDGenre.Komedie.ToString(); 
                case 3: return DVDGenre.Drama.ToString();
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
