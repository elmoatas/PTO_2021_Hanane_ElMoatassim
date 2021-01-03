using System;

namespace Poker
{
    class PackOfCards : Cards
    {
        //PRIVATE MEMBERS
        const int totalNumberOfCards = 52; //constante int 
        private Cards[] packOfCardArray;

        //CONSTRUCTOR 
        public PackOfCards()
        {
            packOfCardArray = new Cards[totalNumberOfCards];
        }
        
        //PROPERTIES
        public Cards[] GetaPackOfCard { get { return packOfCardArray; } } //get current pack of card 

        //METHODES
        public void CreateAndShufflePackOfCards()  
        {
            //create deck of 52 cards : 13 values, with 4 suitS
            int i = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {

                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    packOfCardArray[i] = new Cards { MySuit = suit, MyValue = value }; //nieuw kaarten steken in de Packet: elke kaart krijgt een suit en een value  
                    i++;
                }
            }

            ShuffleCards(); //deze kaarten shufflen
        }
        private void ShuffleCards()
        {
            Random rnd = new Random();
            Cards card;

            //i = aantal keren dat je gaat chufflen
            for (int i = 0; i < 100; i++)
            {
                for (int f = 0; f < totalNumberOfCards; f++)
                {
                    // f= de plaats van de kaart ==> dan gaat de kaart gelijk zijn aan de kaart op plaats van f 
                    // deze  krijgt een random index en deze index wordt dan aan de kaart gegeven
                    // dit nu doen voor alle kaarten

                    int CardIndex = rnd.Next(13);
                    card = packOfCardArray[f];
                    packOfCardArray[f] = packOfCardArray[CardIndex];
                    packOfCardArray[CardIndex] = card;
                }
            }
        }
    }
}
