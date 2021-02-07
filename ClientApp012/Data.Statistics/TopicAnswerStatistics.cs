using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class TopicAnswerStatistics
    {
        public TopicAnswerStatistics() { }
        public TopicAnswerStatistics(TopicAnswerStatistics value)
        {
            this.TotalCardAmount = value.TotalCardAmount;
            this.Answered = value.Answered;
            this.AnsweredTwice = value.AnsweredTwice;
            this.AnsweredMoreThenTwice = value.AnsweredMoreThenTwice;
            this.Count = value.Count;
            this.Wrong = value.Wrong;
            this.Correct = value.Correct;
            this.TimeMin = value.TimeMin;
            this.TimeMax = value.TimeMax;
            this.TimeAvg = value.TimeAvg;
        }

        public int TotalCardAmount { get; set; }
        //How many individual cards were answered that day
        public int Answered { get; set; }
        public int AnsweredTwice { get; set; }
        public int AnsweredMoreThenTwice { get; set; }
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
