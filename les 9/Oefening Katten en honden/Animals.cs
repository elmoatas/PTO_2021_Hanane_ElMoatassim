using System.Windows.Media;

namespace Oefening_Katten_en_honden
{
    class Animals

    {
        //PRIVATE MEMBERS
        private double height;
        private double weight;
        private double length;
        private Brush[] Color;

        //CONSTRUCTOR
        public Animals()
        {

        }
        public double Height { get => height; set => height = value; }
        public double Weight { get => weight; set => weight = value; }
        public double Length { get => length; set => length = value; }
        public Brush[] Color1 { get => Color; set => Color = value; }

        //METHODE
        internal void Eat()
        {

        }

        internal void Sleep()
        {

        }

    }
}
