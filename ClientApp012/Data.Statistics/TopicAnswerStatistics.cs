using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class TopicAnswerStatistics
    {
        //How many individual cards were answered that day
        public int Answered { get; set; }
        //How often (wrong, right) all of the cards
        public int Count { get; set; }
        public int Wrong { get; set; }
        public int Correct { get; set; }

        //Time avg., min., max.
        public long TimeMin { get; set; }
        public long TimeMax { get; set; }
        public long TimeAvg { get; set; }
    }
}
