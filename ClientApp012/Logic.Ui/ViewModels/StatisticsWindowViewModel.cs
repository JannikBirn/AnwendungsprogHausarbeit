using De.HsFlensburg.ClientApp012.Data.Statistics;
using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels.LineGraph.Shapes;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class StatisticsWindowViewModel : INotifyPropertyChanged
    {

        public RootViewModel RootViewModel { get; set; }
        public LineGraphViewModel LineGraphVM { get; set; }
        private Statistics Statistics { get; set; }

        //Open Panel Commands
        public RelayCommand OpenStatisticsHistoryPanel { get; }
        //public RelayCommand HistoryPanelOpen { get; }
        public RelayCommand OpenStatisticsTimePanel { get; }
        public RelayCommand OpenStatisticsQualityPanel { get; }

        //Open Topic Selection
        public RelayCommand OpenTopicSelectionWindow { get; }

        //Relod Command
        public RelayCommand GenerateExampleData { get; }
        //Buttons
        public RelayCommand FirstButton { get; }
        public RelayCommand SecondButton { get; }
        public RelayCommand ThirdButton { get; }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        //Strings
        private string firstStatistic;
        public string FirstStatistic
        {
            get => firstStatistic;
            private set
            {
                firstStatistic = value;
                OnPropertyChanged("FirstStatistic");
            }
        }
        private string secondStatistic;
        public string SecondStatistic
        {
            get => secondStatistic;
            private set
            {
                secondStatistic = value;
                OnPropertyChanged("SecondStatistic");
            }
        }
        private string thirdStatistic;
        public string ThirdStatistic
        {
            get => thirdStatistic;
            private set
            {
                thirdStatistic = value;
                OnPropertyChanged("ThirdStatistic");
            }
        }

        //Selected Topic
        //If Property is null -> all topics are selected
        private TopicViewModel selectedTopic;


        public TopicViewModel SelectedTopic
        {
            get
            {
                return selectedTopic;
            }
            set
            {
                selectedTopic = value;
                OnPropertyChanged("SelectedTopic");
                OnPropertyChanged("SelectedTopicString");
            }
        }
        //Selected Topic as String for the Window
        public string SelectedTopicString
        {
            get
            {
                if (SelectedTopic != null)
                    return SelectedTopic.Name;
                return "All";
            }
        }

        public int CurrentPanelIndex { get; set; }


        public StatisticsWindowViewModel(RootViewModel model, LineGraphViewModel lineGraphVM)
        {
            //Refrenzing to the model
            RootViewModel = model;
            LineGraphVM = lineGraphVM;

            ErrorMessage = "";

            //Adding relay commands
            OpenStatisticsHistoryPanel = new RelayCommand(() => OpenStatisticsPanelMethod(OpenStatisticsPanelMessage.HISTORY_PANEL));
            OpenStatisticsTimePanel = new RelayCommand(() => OpenStatisticsPanelMethod(OpenStatisticsPanelMessage.TIME_PANEL));
            OpenStatisticsQualityPanel = new RelayCommand(() => OpenStatisticsPanelMethod(OpenStatisticsPanelMessage.QUALITY_PANEL));
            OpenTopicSelectionWindow = new RelayCommand(() => OpenTopicSelectionWindowMethod());
            GenerateExampleData = new RelayCommand(() => GenerateExampleDataMethod());

            FirstButton = new RelayCommand(() =>
            {
                LineGraphVM.ThirdLine.IsInvisible = !LineGraphVM.ThirdLine.IsInvisible;
            });
            SecondButton = new RelayCommand(() =>
            {
                LineGraphVM.SecondLine.IsInvisible = !LineGraphVM.SecondLine.IsInvisible;
            });
            ThirdButton = new RelayCommand(() =>
            {
                LineGraphVM.FirstLine.IsInvisible = !LineGraphVM.FirstLine.IsInvisible;
            });

        }

        private void GenerateExampleDataMethod()
        {
            InitStatistics();
            //Setup Statistics
            Statistics.GenerateExampleData();
            UpdateGraph();
        }

        private void InitStatistics()
        {
            //Setup Statistics
            if (Statistics == null)
            {
                Statistics = new Statistics(RootViewModel.Model);
            }
        }

        public bool UpdateGraph()
        {            
            return SetGraph(CurrentPanelIndex, DateTime.Now.Date.Ticks - TimeSpan.FromDays(10).Ticks, DateTime.Now.Date.Ticks);
        }

        //Setup Graph from and to date at 0:00:00
        //iteration -> default 24 hours
        //from included, to included
        private bool SetGraph(int graphType, long from, long to)
        {

            InitStatistics();

            //TopicStats for that period of time
            Dictionary<long, TopicAnswerStatistics> topicAnswersDaily = new Dictionary<long, TopicAnswerStatistics>();
            if (SelectedTopic != null)
            {
                Data.Statistics.TopicStatistics topicStats = Statistics.topicStatistics.Find(param => param.Topic == SelectedTopic.Model);
                if(topicStats != null)
                topicAnswersDaily = topicStats.GetTopicAnswersDaily(from, to);
            }
            else
            {
                topicAnswersDaily = Statistics.GetAllTopicAnswersDaily(from, to);
            }

            //For History Panel

            if (topicAnswersDaily.Count != 0)
            {
                //list of all Days as long
                List<long> dates = new List<long>();
                long currentdate = new DateTime(from).Date.Ticks; //Start Datum
                while (currentdate <= to)
                {
                    dates.Add(currentdate);
                    currentdate += TimeSpan.TicksPerDay;
                }
                //Points for the Paths
                List<Point> unscaledPointsPathOne = new List<Point>();
                List<Point> unscaledPointsPathTwo = new List<Point>();
                List<Point> unscaledPointsPathThree = new List<Point>();

                //Shapes for Path
                ShapePath firstPath;
                ShapePath secondPath;
                ShapePath thirdPath;

                //Max and Min Values for Skaling 
                long xMax = to;
                long xMin = from;
                long yMax = 0;//Will be replaced in switch
                long yMin = 0;//Will be replaced in switch

                string firstStatisticStat = "";
                string secondStatisticStat = "";
                string thirdStatisticStat = "";

                switch (graphType)
                {
                    case OpenStatisticsPanelMessage.HISTORY_PANEL:
                        //Points for Paths
                        foreach (long date in dates)
                        {
                            //Points for Path 1,2,3
                            if (topicAnswersDaily.ContainsKey(date))
                            {
                                unscaledPointsPathOne.Add(new Point(date, topicAnswersDaily[date].Answered));
                                unscaledPointsPathTwo.Add(new Point(date, topicAnswersDaily[date].AnsweredTwice));
                                unscaledPointsPathThree.Add(new Point(date, topicAnswersDaily[date].AnsweredMoreThenTwice));
                            }
                            else
                            {
                                unscaledPointsPathOne.Add(new Point(date, 0));
                                unscaledPointsPathTwo.Add(new Point(date, 0));
                                unscaledPointsPathThree.Add(new Point(date, 0));
                            }

                        }

                        //Declaring Min-Max
                        yMax = topicAnswersDaily.First().Value.TotalCardAmount;
                        yMin = 0;

                        //Generating Path
                        firstPath = LineGraphVM.GetPahtUnscaled(unscaledPointsPathThree, xMax, xMin, yMax, yMin, "#00FF00");
                        secondPath = LineGraphVM.GetPahtUnscaled(unscaledPointsPathTwo, xMax, xMin, yMax, yMin, "#0000FF");
                        thirdPath = LineGraphVM.GetPahtUnscaled(unscaledPointsPathOne, xMax, xMin, yMax, yMin, "#FF0000");


                        //Graph Axis Setup

                        LineGraphVM.VerticalUnit = "%";
                        LineGraphVM.VerticalNumbers = new ObservableCollection<string> { "  0", " 20", " 40", " 60", " 80", "100" };



                        //Adding Bottom String Statistics
                        firstStatisticStat = topicAnswersDaily.First().Value.TotalCardAmount.ToString();
                        int totalAnswers = 0;
                        int totalAnswersMoreThenThree = 0;
                        topicAnswersDaily.Select(pair => pair.Value).ToList().ForEach(v =>
                        {
                            totalAnswers += v.Answered;
                            totalAnswersMoreThenThree += v.AnsweredMoreThenTwice;
                        });

                        secondStatisticStat = totalAnswers.ToString();
                        thirdStatisticStat = totalAnswersMoreThenThree.ToString();

                        break;

                    case OpenStatisticsPanelMessage.TIME_PANEL:

                        //Graph Axis Setup
                        yMax = topicAnswersDaily.Max(param => param.Value.TimeMax);
                        yMin = topicAnswersDaily.Min(param => param.Value.TimeMin);

                        foreach (long date in dates)
                        {
                            //Points for Path 1,2,3
                            if (topicAnswersDaily.ContainsKey(date))
                            {
                                unscaledPointsPathTwo.Add(new Point(date, topicAnswersDaily[date].TimeAvg));
                                unscaledPointsPathOne.Add(new Point(date, topicAnswersDaily[date].TimeMax));
                                unscaledPointsPathThree.Add(new Point(date, topicAnswersDaily[date].TimeMin));
                            }
                            else
                            {
                                unscaledPointsPathOne.Add(new Point(date, yMin));
                                unscaledPointsPathTwo.Add(new Point(date, yMin));
                                unscaledPointsPathThree.Add(new Point(date, yMin));
                            }
                        }



                        LineGraphVM.VerticalUnit = "sec";
                        ObservableCollection<string> verticalAxisSeconds = new ObservableCollection<string>();

                        long timeSpan = yMax - yMin;
                        long timeSegment = timeSpan / 6;
                        for (int i = 0; i < 6; i++)
                        {
                            verticalAxisSeconds.Add(TimeSpan.FromTicks(yMin + (timeSegment * i)).ToString("ss"));
                        }

                        LineGraphVM.VerticalNumbers = verticalAxisSeconds;


                        //Adding Bottom String Statistics
                        long overallMinTime = topicAnswersDaily.Select(pair => pair.Value).ToList().Min(stat => stat.TimeMin);
                        long overallMaxTime = topicAnswersDaily.Select(pair => pair.Value).ToList().Max(stat => stat.TimeMax);

                        long overallAvgTime = topicAnswersDaily.First().Value.TimeAvg;
                        topicAnswersDaily.Select(pair => pair.Value).ToList().ForEach(v =>
                        {
                            overallAvgTime = (overallAvgTime + v.TimeAvg) / 2;
                        });

                        firstStatisticStat = TimeSpan.FromTicks(overallMaxTime).TotalSeconds.ToString("N0");
                        secondStatisticStat = TimeSpan.FromTicks(overallAvgTime).TotalSeconds.ToString("N0");
                        thirdStatisticStat = TimeSpan.FromTicks(overallMinTime).TotalSeconds.ToString("N0");

                        break;

                    case OpenStatisticsPanelMessage.QUALITY_PANEL:

                        foreach (long date in dates)
                        {
                            //Points for Path 1,2,3
                            if (topicAnswersDaily.ContainsKey(date))
                            {
                                double timesAnswered = topicAnswersDaily[date].Count;
                                unscaledPointsPathTwo.Add(new Point(date, topicAnswersDaily[date].Wrong / timesAnswered));
                                unscaledPointsPathOne.Add(new Point(date, topicAnswersDaily[date].Correct / timesAnswered));
                                unscaledPointsPathThree.Add(new Point(date, topicAnswersDaily[date].CorrectMoreThenThreeTimes / timesAnswered));
                            }
                            else
                            {
                                unscaledPointsPathOne.Add(new Point(date, 0));
                                unscaledPointsPathTwo.Add(new Point(date, 0));
                                unscaledPointsPathThree.Add(new Point(date, 0));
                            }
                        }


                        //Graph Axis Setup
                        yMax = 1;
                        yMin = 0;

                        LineGraphVM.VerticalUnit = "%";
                        LineGraphVM.VerticalNumbers = new ObservableCollection<string> { "  0", " 20", " 40", " 60", " 80", "100" };


                        //Adding Bottom String Statistics
                        int totalWrong = 0;
                        int totalCorrect = 0;
                        int totalCorrectMoreThenThree = 0;
                        int totalAnswered = 0;

                        topicAnswersDaily.Select(pair => pair.Value).ToList().ForEach(v =>
                        {
                            totalWrong += v.Wrong;
                            totalCorrect += v.Correct;
                            totalCorrectMoreThenThree += v.CorrectMoreThenThreeTimes;
                            totalAnswered += v.Count;
                        });

                        firstStatisticStat = (100 * totalWrong / (double)totalAnswered).ToString("N2");
                        secondStatisticStat = (100 * totalCorrect / (double)totalAnswered).ToString("N2");
                        thirdStatisticStat = (100 * totalCorrectMoreThenThree / (double)totalAnswered).ToString("N2");

                        break;
                }



                LineGraphVM.Shapes.Clear();
                firstPath = LineGraphVM.GetPahtUnscaled(unscaledPointsPathThree, xMax, xMin, yMax, yMin, "#00FF00");
                secondPath = LineGraphVM.GetPahtUnscaled(unscaledPointsPathTwo, xMax, xMin, yMax, yMin, "#0000FF");
                thirdPath = LineGraphVM.GetPahtUnscaled(unscaledPointsPathOne, xMax, xMin, yMax, yMin, "#FF0000");

                LineGraphVM.FirstLine = firstPath;
                LineGraphVM.SecondLine = secondPath;
                LineGraphVM.ThirdLine = thirdPath;
                LineGraphVM.Shapes.Add(firstPath);
                LineGraphVM.Shapes.Add(secondPath);
                LineGraphVM.Shapes.Add(thirdPath);

                //Adding Dates for Horizontal Axis
                LineGraphVM.HorizontalUnit = "date";
                List<string> datesFormatted = new List<string>();
                foreach (long date in dates)
                {
                    DateTime dateInTime = new DateTime(date);
                    datesFormatted.Add(dateInTime.ToString("dd-MM"));
                }
                LineGraphVM.HorizontalNumbers = new ObservableCollection<string>(datesFormatted);

                FirstStatistic = firstStatisticStat;
                SecondStatistic = secondStatisticStat;
                ThirdStatistic = thirdStatisticStat;
            }
            else
            {
                //Returns false if there is no statistics
                return false;
            }
            return true;
        }


        private void OpenTopicSelectionWindowMethod()
        {
            Messenger.Instance.Send<OpenTopicSelectionWindowMessage>(null);
        }

        public void OpenStatisticsPanelMethod(int panelIndex)
        {
            CurrentPanelIndex = panelIndex;
            if (UpdateGraph())
            {
                //Graph can be updated, open panel
                //Sending Message to MessageListener to change Panel
                ErrorMessage = "";
                OpenStatisticsPanelMessage messageObject = new OpenStatisticsPanelMessage();
                messageObject.PanelIndex = panelIndex;

                Messenger.Instance.Send<OpenStatisticsPanelMessage>(messageObject);
            }
            else
            {
                ErrorMessage = "No Statistiks for the current selection!";
                OpenStatisticsPanelMessage messageObject = new OpenStatisticsPanelMessage();
                messageObject.PanelIndex = OpenStatisticsPanelMessage.NO_PANEL;
                Messenger.Instance.Send<OpenStatisticsPanelMessage>(messageObject);
            }
        }


        //For the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
