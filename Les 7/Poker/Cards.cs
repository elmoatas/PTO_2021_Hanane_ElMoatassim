namespace Poker
{

    class Cards
    {
        //ENUM
        public enum Suit
        {
            Hearts,
            Clubs,
            Spades,
            Diamonds
        }
        public enum Value
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace

        }
        
        //PRIVATE MEMBERS
        
        //CONSTRUCTOR
        
        //PROPERTIES
        public Suit MySuit { get; set; }
        public Value MyValue { get; set; }
        
        //METHODES
        public static string CardSuit(Cards card)
        {
            string cardSuit = "";


            switch (card.MySuit)
            {
                case Cards.Suit.Hearts:
                    cardSuit = "H";
                    break;
                case Cards.Suit.Clubs:
                    cardSuit = "C";
                    break;
                case Cards.Suit.Spades:
                    cardSuit = "S";
                    break;
                case Cards.Suit.Diamonds:
                    cardSuit = "D";
                    break;

            }
            return cardSuit;
        }
        public static string CardValue(Cards card)
        {
            string cardValue = "";
            switch (card.MyValue)
            {

                case Cards.Value.Two:
                    cardValue = "2";
                    break;
                case Cards.Value.Three:
                    cardValue = "3";
                    break;
                case Cards.Value.Four:
                    cardValue = "4";
                    break;
                case Cards.Value.Five:
                    cardValue = "5";
                    break;
                case Cards.Value.Six:
                    cardValue = "6";
                    break;
                case Cards.Value.Seven:
                    cardValue = "7";
                    break;
                case Cards.Value.Eight:
                    cardValue = "8";
                    break;
                case Cards.Value.Nine:
                    cardValue = "9";
                    break;
                case Cards.Value.Ten:
                    cardValue = "10";
                    break;
                case Cards.Value.Jack:
                    cardValue = "J";
                    break;
                case Cards.Value.Queen:
                    cardValue = "Q";
                    break;
                case Cards.Value.King:
                    cardValue = "K";
                    break;
                case Cards.Value.Ace:
                    cardValue = "A";
                    break;
            }
            return cardValue;
        }
    }
}
