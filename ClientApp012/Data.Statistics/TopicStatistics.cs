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

        public List<CardStatistics> CardStatistics { get; set; }

        //Topic Statistiks on a daily basis
        //long is day at 0:00:00, int is times answered that day
        //if there is no TopicAnswerStatistics for a given day, no cards in this topic were answered that day
        public Dictionary<long, TopicAnswerStatistics> TopicStatisticsDaily { get; set; }
        internal TopicStatistics(Topic topic)
        {
            this.Topic = topic;
            CardStatistics = new List<CardStatistics>();
            foreach (Card card in topic)
            {
                CardStatistics.Add(new CardStatistics(card));
            }

            TopicStatisticsDaily = GetAnswersPerDay();
        }

        private Dictionary<long, TopicAnswerStatistics> GetAnswersPerDay()
        {
            Dictionary<long, TopicAnswerStatistics> answerePerDay = new Dictionary<long, TopicAnswerStatistics>();

            foreach (CardStatistics cardStatistics in CardStatistics)
            {

                foreach (KeyValuePair<long, CardAnswerStatistics> cardAnswerDaily in cardStatistics.AnswereStatisticsDaily)
                {

                    TopicAnswerStatistics currentTopicAnswerStatistic;
                    if (answerePerDay.ContainsKey(cardAnswerDaily.Key))
                    {
                        //Get Card Answer from that date
                        currentTopicAnswerStatistic = answerePerDay[cardAnswerDaily.Key];
                        //Adding one to Answered
                        currentTopicAnswerStatistic.Answered++;
                        if (cardAnswerDaily.Value.Count > 1)
                            currentTopicAnswerStatistic.AnsweredTwice++;
                        if (cardAnswerDaily.Value.Count > 2)
                            currentTopicAnswerStatistic.AnsweredMoreThenTwice++;
                        //Adding Count, Wrong, Correct
                        currentTopicAnswerStatistic.Count += cardAnswerDaily.Value.Count;
                        currentTopicAnswerStatistic.Wrong += cardAnswerDaily.Value.Wrong;
                        currentTopicAnswerStatistic.Correct += cardAnswerDaily.Value.Correct;



                        if (currentTopicAnswerStatistic.TimeMin > cardAnswerDaily.Value.TimeMin)
                            currentTopicAnswerStatistic.TimeMin = cardAnswerDaily.Value.TimeMin;

                        if (currentTopicAnswerStatistic.TimeMax < cardAnswerDaily.Value.TimeMax)
                            currentTopicAnswerStatistic.TimeMax = cardAnswerDaily.Value.TimeMax;

                        currentTopicAnswerStatistic.TimeAvg = (currentTopicAnswerStatistic.TimeAvg + cardAnswerDaily.Value.TimeAvg) / 2;

                        currentTopicAnswerStatistic.TotalCardAmount = Topic.Count;
                    }
                    else
                    {
                        currentTopicAnswerStatistic = new TopicAnswerStatistics(cardAnswerDaily.Value);
                        answerePerDay.Add(cardAnswerDaily.Key, currentTopicAnswerStatistic);
                    }


                }
            }
            return answerePerDay;
        }

        public Dictionary<long, TopicAnswerStatistics> GetTopicAnswersDaily(long from, long to)
        {
            Dictionary<long, TopicAnswerStatistics> statsPerDay = new Dictionary<long, TopicAnswerStatistics>();

            foreach (KeyValuePair<long, TopicAnswerStatistics> topicStatsDaily in TopicStatisticsDaily)
            {
                if (topicStatsDaily.Key >= from && topicStatsDaily.Key <= to)
                    statsPerDay.Add(topicStatsDaily.Key, topicStatsDaily.Value);
            }
            return statsPerDay;
        }
    }
}
