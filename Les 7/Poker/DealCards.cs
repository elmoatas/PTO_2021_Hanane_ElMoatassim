namespace Poker
{
    class DealCards : PackOfCards
    {
        //PRIVATE MEMBERS
        private Cards[] playerHand;
        string imageUrl1;
        string imageUrl2;
        string imageUrl3;
        string imageUrl4;
        string imageUrl5;
        
        //CONSTRUCTOR
        public DealCards()
        {
            playerHand = new Cards[5];
        }
        
        //PROPERTIES
        public string ImageUrl1 { get => imageUrl1; set => imageUrl1 = value; }
        public string ImageUrl2 { get => imageUrl2; set => imageUrl2 = value; }
        public string ImageUrl3 { get => imageUrl3; set => imageUrl3 = value; }
        public string ImageUrl4 { get => imageUrl4; set => imageUrl4 = value; }
        public string ImageUrl5 { get => imageUrl5; set => imageUrl5 = value; }
        
        //METHODES
        public void Deal()
        {
            //get actual cards
            CreateAndShufflePackOfCards(); // overgeerfd van pack of cards==> een pack van kaart maken  
            Get5Cards();
            GetUrlOfImage();
        }
        private void Get5Cards()
        {
            for (int i = 0; i < 5; i++)
            {
                playerHand[i] = GetaPackOfCard[i];
            }
        }
        private void GetUrlOfImage()
        {
            imageUrl1 = $@"ImageCards/{Cards.CardValue(playerHand[0])}{Cards.CardSuit(playerHand[0])}.jpg";
            imageUrl2 = $@"ImageCards/{Cards.CardValue(playerHand[1])}{Cards.CardSuit(playerHand[1])}.jpg";
            imageUrl3 = $@"ImageCards/{Cards.CardValue(playerHand[2])}{Cards.CardSuit(playerHand[2])}.jpg";
            imageUrl4 = $@"ImageCards/{Cards.CardValue(playerHand[3])}{Cards.CardSuit(playerHand[3])}.jpg";
            imageUrl5 = $@"ImageCards/{Cards.CardValue(playerHand[4])}{Cards.CardSuit(playerHand[4])}.jpg";
        }

    }
}
