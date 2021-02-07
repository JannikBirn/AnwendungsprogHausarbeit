using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class CardAnswerStatistics
    {
        public CardAnswerStatistics(CardAnswer cardAnswer)
        {
            Count = 1;
            Wrong = cardAnswer.IsAnswerCorrect ? 0 : 1;
            Correct = cardAnswer.IsAnswerCorrect ? 1 : 0;
            TimeMin = cardAnswer.GetSpan();
            TimeMax = cardAnswer.GetSpan();
            TimeAvg = cardAnswer.GetSpan();
        }

        //How often (wrong, right)
        public int Count { get; set; }
        public int Wrong { get; set; }
        public int Correct { get; set; }

        //Time avg., min., max.
        public long TimeMin { get; set; }
        public long TimeMax { get; set; }
        public long TimeAvg { get; set; }

    }
}
