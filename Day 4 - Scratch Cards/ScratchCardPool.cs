using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class ScratchCardPool
    {
        IDictionary<int, ScratchCard> scratchCardDict;
        List<ScratchCard> scratchCardList;
        public ScratchCardPool(string[] cardStrings)
        {
            scratchCardDict = new Dictionary<int, ScratchCard>();
            scratchCardList = new List<ScratchCard>();
            foreach (string cardString in cardStrings)
            {
                ScratchCard newCard = new ScratchCard(cardString);
                scratchCardList.Add(newCard);
                scratchCardDict.Add(newCard.Number, newCard);
            }
        }

        public void ScoreAllCards()
        {
            for (int cardIndex = 0; cardIndex < scratchCardList.Count; cardIndex++)
            {
                // Get the points for the card
                ScratchCard card = scratchCardList[cardIndex];

                // Add that any cards to the pool
                int matches = card.GetNumMatches();

                for (int i = 1; i <= matches; i++)
                    scratchCardList.Add(scratchCardDict[card.Number + i]);
            }
        }

        public int CountNumCards()
        {
            return scratchCardList.Count;
        }
    }
}
