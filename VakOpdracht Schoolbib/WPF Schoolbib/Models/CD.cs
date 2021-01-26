using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{

   public class CD : Library
    {
        private int id;
        private int duration;
        private string genre;
        private CDGenre cdGenre;
        int genreIndex;

        public CD()
        {

        }

        public CD(string title, string creator, long productnumber, AvailabilityItem availability, int genreIndex, int duration) : base(title, creator, productnumber, availability)
        {
            this.genreIndex = genreIndex;
            GetCdGenre();
            this.duration = duration;
        }


        [Key]
        public int Id { get => id; set => id = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Genre { get => genre; set => genre = value; }
        public CDGenre CdGenre { get => cdGenre; set => cdGenre = value; }
        [NotMapped]
             public int GenreIndex { get => genreIndex; set => genreIndex = value; }


        public void GetCdGenre()
        {
            switch (genreIndex)
            {
                case 0: cdGenre = (CDGenre)0; break;
                case 1: cdGenre = (CDGenre)1; break;
                case 2: cdGenre = (CDGenre)2; break;
                case 3: cdGenre = (CDGenre)3; break;
                case 4: cdGenre = (CDGenre)4; break;
            }
        }
     
    }
}
