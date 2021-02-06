using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class CardAnswerStatistics
    {
        //Got Answered
        public bool IsAnswered { get; set; }

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
