namespace Poker
{


    class PokerHands : DealCards
    {
        //ENUM
        internal enum Pokerhand
        {
            RoyalFlush,
            StraightFlush,
            FourOfaKind,
            FullHouse,
            Flush,
            Straight,
            ThreeOfaKind,
            TwoPair,
            OnePair,
            HighCard,
            None
        }

        //PRIVATE MEMBERS
        int countHearts = 0;
        int countClubs = 0;
        int countSpades = 0;
        int countDiamonds = 0;
        string showPokerHand;

        public string ShowPokerHand { get => showPokerHand; set => showPokerHand = value; }

        //CONSTRUCTOR
        public PokerHands()
        {

        }

        //PROPERTIES

        //METHODE 
        internal void ThreeOfAKind()
        {

            foreach (Cards Card in PlayerHand)
            {
                if (Cards.CardSuit(Card) == "H")
                {
                    countHearts++;
                }
                if (Cards.CardSuit(Card) == "C")
                {

                    countClubs++;
                }
                if (Cards.CardSuit(Card) == "S")
                {

                    countSpades++;
                }
                if (Cards.CardSuit(Card) == "D")
                {

                    countDiamonds++;
                }
            }
            if (countHearts == 3 || countClubs == 3 || countSpades == 3 || countDiamonds == 3)
            {
                showPokerHand = "Three Of A Kind";
            }

            //return Pokerhand.ThreeOfaKind;
        }

    }
}
