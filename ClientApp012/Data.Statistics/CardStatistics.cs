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
        public Dictionary<long, CardAnswerStatistics> AnswerePerDay { get; set; }

        private Card Card { get; set; }

        internal CardStatistics(Card card)
        {
            Card = card;
        }


        public Dictionary<long, int> GetTimesAnsweredPerDay()
        {
            Dictionary<long, int> answerePerDay = new Dictionary<long, int>();

            foreach (CardAnswer cardAnswer in Card.cardAnswers)
            {
                CardAnswerStatistics currentAnswerStatistiks = new CardAnswerStatistics();




                //long date = new System.DateTime(cardAnswer.End).Date.Ticks;
                //answerePerDay.Add(date, answerePerDay[date] + 1);
            }


            return answerePerDay;
        }

    }
}
