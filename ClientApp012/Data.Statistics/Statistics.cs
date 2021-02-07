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

        public Dictionary<long, TopicAnswerStatistics> GetAllTopicAnswersDaily(long from, long to)
        {

            List<Dictionary<long, TopicAnswerStatistics>> dictionaries = new List<Dictionary<long, TopicAnswerStatistics>>();

            foreach (TopicStatistics item in topicStatistics)
            {
                dictionaries.Add(item.GetTopicAnswersDaily(from, to));
            }

            //Joing all Dicotnaries
            Dictionary<long, TopicAnswerStatistics> result = new Dictionary<long, TopicAnswerStatistics>();
            foreach (Dictionary<long, TopicAnswerStatistics> dictonary in dictionaries)
            {
                foreach (KeyValuePair<long, TopicAnswerStatistics> keyValuePair in dictonary)
                {
                    if (!result.ContainsKey(keyValuePair.Key))
                    {
                        //Create new key and value 
                        result.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                    else
                    {
                        //Add numbers to existing keyvalues
                        TopicAnswerStatistics currentStats = result[keyValuePair.Key];
                        currentStats.Answered += keyValuePair.Value.Answered;
                        currentStats.AnsweredTwice += keyValuePair.Value.AnsweredTwice;
                        currentStats.AnsweredMoreThenTwice += keyValuePair.Value.AnsweredMoreThenTwice;
                        currentStats.Count += keyValuePair.Value.Count;
                        currentStats.Wrong += keyValuePair.Value.Wrong;
                        currentStats.Correct += keyValuePair.Value.Correct;

                        if (currentStats.TimeMin > keyValuePair.Value.TimeMin)
                            currentStats.TimeMin = keyValuePair.Value.TimeMin;

                        if (currentStats.TimeMax > keyValuePair.Value.TimeMax)
                            currentStats.TimeMax = keyValuePair.Value.TimeMax;

                        currentStats.TimeAvg = (currentStats.TimeAvg + keyValuePair.Value.TimeAvg) / 2;

                        currentStats.TotalCardAmount += keyValuePair.Value.TotalCardAmount;

                    }
                }
            }

            return result;
        }

        private Topic AddTestData(Topic topic)
        {
            var rand = new Random();
            foreach (Card card in topic)
            {
                long lastEndTime = DateTime.Now.Ticks;
                lastEndTime += (long)rand.NextDouble() * (int)TimeSpan.FromHours(10).Ticks;
                if (rand.NextDouble() > 0.5)
                    for (int i = 0; i < 10; i++)
                    {
                        CardAnswer cardAnswer = new CardAnswer();
                        cardAnswer.IsAnswerCorrect = rand.NextDouble() > 0.5;
                        cardAnswer.Start = lastEndTime;
                        lastEndTime += (long)rand.NextDouble() * (int)TimeSpan.FromHours(1).Ticks;
                        if (rand.NextDouble() > 0.6)
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
