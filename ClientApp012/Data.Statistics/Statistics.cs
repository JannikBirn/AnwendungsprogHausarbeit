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
            Init();
        }

        public void UpdateStatistics()
        {
            Init();
        }

        private void Init()
        {
            topicStatistics = new List<TopicStatistics>();
            foreach (Topic topic in RootModel.TopicCollection)
            {
                AddTestData(topic); //For Testing purpose
                topicStatistics.Add(new TopicStatistics(topic));

            }
        }

        private Topic AddTestData(Topic topic)
        {
            var rand = new Random();
            long lastEndTime = DateTime.Now.Ticks;
            foreach (Card card in topic)
            {
                if (rand.NextDouble() > 0.2)
                    for (int i = 0; i < 10; i++)
                    {
                        CardAnswer cardAnswer = new CardAnswer();
                        cardAnswer.IsAnswerCorrect = rand.NextDouble() > 0.5;
                        cardAnswer.Start = lastEndTime;
                        lastEndTime += rand.Next((int)TimeSpan.FromSeconds(1).Ticks, (int)TimeSpan.FromSeconds(20).Ticks);
                        if (rand.NextDouble() > 0.9)
                        {
                            lastEndTime += TimeSpan.FromDays(1).Ticks;
                        }
                        cardAnswer.End = lastEndTime;
                        card.cardAnswers.Add(cardAnswer);
                    }
            }

            return topic;
        }


    }
}
