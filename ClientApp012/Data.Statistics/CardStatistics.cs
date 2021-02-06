using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class CardStatistics
    {
        //Card Statistiks on a daily basis
        //long is day at 0:00:00, int is times answered that day
        //if there is no CardAnswerStatistics for a given day, the card wasn't answered that day
        public Dictionary<long, CardAnswerStatistics> AnswereStatisticsDaily { get; set; }

        public Card Card { get; set; }

        internal CardStatistics(Card card)
        {
            Card = card;
            AnswereStatisticsDaily = GetAnswersPerDay();
        }


        public Dictionary<long, CardAnswerStatistics> GetAnswersPerDay()
        {
            Dictionary<long, CardAnswerStatistics> answerePerDay = new Dictionary<long, CardAnswerStatistics>();

            foreach (CardAnswer cardAnswer in Card.cardAnswers)
            {
                long date = new System.DateTime(cardAnswer.End).Date.Ticks;
                bool isFirstCardAnswer = false;

                CardAnswerStatistics currentAnswerStatistics;
                if (answerePerDay.ContainsKey(date))
                {
                    //Get Card Answer from that date
                    currentAnswerStatistics = answerePerDay[date];
                }
                else
                {
                    currentAnswerStatistics = new CardAnswerStatistics();
                    isFirstCardAnswer = true;
                }

                currentAnswerStatistics.Count++;

                if (cardAnswer.IsAnswerCorrect)
                    currentAnswerStatistics.Correct++;
                else
                    currentAnswerStatistics.Wrong--;

                if (currentAnswerStatistics.TimeMin > cardAnswer.GetSpan())
                    currentAnswerStatistics.TimeMin = cardAnswer.GetSpan();

                if (currentAnswerStatistics.TimeMax < cardAnswer.GetSpan())
                    currentAnswerStatistics.TimeMax = cardAnswer.GetSpan();

                currentAnswerStatistics.TimeAvg = (currentAnswerStatistics.TimeAvg + cardAnswer.GetSpan()) / 2;

                if (isFirstCardAnswer)
                    answerePerDay.Add(date,currentAnswerStatistics);
            }


            return answerePerDay;
        }

    }
}
