using System;
using System.Windows.Media.Imaging;

namespace Dobbelsteen
{
    class Dice
    {
        //private members


        private int number_Dice;
        private System.Windows.Media.Imaging.BitmapImage image;
        private string dice_name;

        //Constructor
        public Dice(string name)
        {
            this.dice_name = name;
        }

        //Properties ( getters/setters)
        public int Dice_Number
        {
            get { return number_Dice; }
        }
        public BitmapImage Image
        {
            get { return image; }
        }

        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        //Methodes ( public & private)
        public void Roll()
        {
            Random random = new Random();
            number_Dice = random.Next(1, 7);
        }
        private void SetImage(int number)
        {
            string url = "";
            switch (number)
            {
                case 1: url = "1.png break"; break;
                case 2: url = "2.png break"; break;
                case 3: url = "3.png break"; break;
                case 4: url = "4.png break"; break;
                case 5: url = "5.png break"; break;
                case 6: url = "6.png break"; break;
            }
            if (url != "")
            {
                Uri resourceUri = new Uri(url, UriKind.Relative);
                image = new BitmapImage(resourceUri);
            }
        }

    }
}
