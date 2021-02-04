using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class CardStatistics
    {
        List<Card> cards;

        internal CardStatistics(List<Card> cards)
        {
            this.cards = cards;
        }

        //Returning all Cards that have been answered between from-to
        public List<Card> GetCardsBetween(long from, long to)
        {
            List<Card> cards = new List<Card>();

            foreach (Card card in cards)
            {
                foreach (CardAnswer cardAnswer in card.cardAnswers)
                {
                    if (from < cardAnswer.End && to > cardAnswer.End)
                    {
                        cards.Add(card);
                        break;
                    }
                }
            }
            return cards;
        }

        //Returning all CardAnswers from a Card that were answered from-to
        public List<CardAnswer> GetCardAnswersBetween(Card card, long from, long to)
        {
            List<CardAnswer> cardAnswers = new List<CardAnswer>();

            foreach (CardAnswer cardAnswer in card.cardAnswers)
            {
                if (from < cardAnswer.End && to > cardAnswer.End)
                {
                    cardAnswers.Add(cardAnswer);
                }
            }

            return cardAnswers;
        }
    }
}
