using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Data.Statistics
{
    public class Statistics
    {

        private Root RootModel { get; set; }
        public List<TopicStatistics> topicStatistics;

        public Statistics(Root rootModel)
        {
            this.RootModel = rootModel;
            
            topicStatistics = new List<TopicStatistics>();
            foreach (Topic topic in RootModel.TopicCollection)
            {
                topicStatistics.Add(new TopicStatistics(topic));

            }
        }

        public static Topic AddTestData(Topic topic)
        {
            var rand = new Random();
            long lastEndTime = DateTime.Now.Ticks;
            foreach (Card card in topic)
            {
                for (int i = 0; i < 10; i++)
                {
                    CardAnswer cardAnswer = new CardAnswer();
                    cardAnswer.IsAnswerCorrect = rand.NextDouble() > 0.5;
                    cardAnswer.Start = lastEndTime;
                    lastEndTime += rand.Next(10000000 * 10, 10000000 * 60);
                    cardAnswer.End = lastEndTime;
                    card.cardAnswers.Add(cardAnswer);
                }
            }

            return topic;
        }


    }
}
