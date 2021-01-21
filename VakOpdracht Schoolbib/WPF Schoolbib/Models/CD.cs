using System.ComponentModel.DataAnnotations;
using WPF_Schoolbib.Models;

namespace WPF_Schoolbib
{

    class CD
    {
        private int id;
        private string title;
        private string creator;
        private long productNumber;
        private int duration;
        private string genre;
        private CDGenre cdGenre;

      

        public CD(string title, string creator, long productnumber, int genreIndex, int duration)
        {
            this.title = title;
            this.creator = creator;
            this.productNumber = productnumber;
            GetCdGenre(genreIndex);
            this.duration = duration;
        }


        [Key]
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Creator { get => creator; set => creator = value; }
        public long ProductNumber { get => productNumber; set => productNumber = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Genre { get => genre; set => genre = value; }
        public CDGenre CdGenre { get => cdGenre; set => cdGenre = value; }

        private void GetCdGenre(int genreIndex)
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
        public override string ToString()
        {
            return $" {productNumber} - {title} ";
        }
    }
}
