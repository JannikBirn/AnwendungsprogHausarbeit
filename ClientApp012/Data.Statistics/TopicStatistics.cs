using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class TopicStatistics
    {
        public Topic Topic { get; set; }

        public CardStatistics CardStatistics { get; set; }
        internal TopicStatistics(Topic topic)
        {
            this.Topic = topic;
            CardStatistics = new CardStatistics(Topic.ToList<Card>());
        }
    }
}
