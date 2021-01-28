using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryModels.Models;

namespace LibraryModels
{

   public class CD : Library
    {
  
        public CD() 
        {

        }

        public CD(int duration, int genreIndex)
        {
            this.Duration = duration;
            this.GenreIndex = genreIndex;
        }

        [Key]
        public int Id { get; set; }
        public int Duration { get; set ; }
        public int GenreIndex { get; set; }

        [NotMapped]
        public string Genre { get => GetCdGenre();}
             

        private string GetCdGenre()
        {
            switch (GenreIndex)
            {
                case 0: return CDGenre.HipHop.ToString(); 
                case 1: return CDGenre.Rock.ToString(); 
                case 2: return CDGenre.Rap.ToString();
                case 3: return CDGenre.Klasiek.ToString();
                case 4: return CDGenre.Jazz.ToString(); 
                default: return ""; 
            }
           
        }

     
    }
}
