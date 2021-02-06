using De.HsFlensburg.ClientApp012.Data.Statistics;
using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
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
        public RelayCommand ReloadStatistics { get; }

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


        public StatisticsWindowViewModel(RootViewModel model, LineGraphViewModel lineGraphVM)
        {
            //Refrenzing to the model
            RootViewModel = model;
            LineGraphVM = lineGraphVM;

            //Adding relay commands
            OpenStatisticsHistoryPanel = new RelayCommand(() => OpenStatisticsPanelMethod(OpenStatisticsPanelMessage.HISTORY_PANEL));
            OpenStatisticsTimePanel = new RelayCommand(() => OpenStatisticsPanelMethod(OpenStatisticsPanelMessage.TIME_PANEL));
            OpenStatisticsQualityPanel = new RelayCommand(() => OpenStatisticsPanelMethod(OpenStatisticsPanelMessage.QUALITY_PANEL));
            OpenTopicSelectionWindow = new RelayCommand(() => OpenTopicSelectionWindowMethod());
            ReloadStatistics = new RelayCommand(() => InitStatistics());

        }

        private void InitStatistics()
        {
            //Setup Statistics
            Statistics = new Statistics(RootViewModel.Model);
        }

        //Setup Graph from and to date at 0:00:00
        //iteration -> default 24 hours
        //from included, to excluded
        private void SetGraph(int graphType, long from, long to)
        {
            if (Statistics == null)
            {
                InitStatistics();
            }

            //TopicStats for that period of time
            //TODO filter all topics
            Data.Statistics.TopicStatistics topicStats = Statistics.topicStatistics.Find(param => param.Topic == SelectedTopic.Model);
            Dictionary<long, TopicAnswerStatistics> topicAnswersDaily = topicStats.GetTopicAnswersDaily(from, to);

            //For History Panel

            switch (graphType)
            {
                case OpenStatisticsPanelMessage.HISTORY_PANEL:

                    //list of all Days as long
                    List<long> dates = new List<long>();
                    long currentdate = new DateTime(from).Date.Ticks; //Start Datum
                    while (currentdate < to)
                    {
                        dates.Add(currentdate);
                        currentdate += TimeSpan.TicksPerDay;
                    }

                    //Points for the Answered Path
                    List<Point> unscaledPointsAnswered = new List<Point>();

                    foreach (long date in dates)
                    {
                        if (topicAnswersDaily.ContainsKey(date))
                        {
                            unscaledPointsAnswered.Add(new Point(date, topicAnswersDaily[date].Answered));
                        }
                        else
                        {
                            unscaledPointsAnswered.Add(new Point(date, 0));
                        }
                    }

                    //Max and Min Values for Skaling 
                    double xMax = unscaledPointsAnswered.Max(point => point.X);
                    double xMin = unscaledPointsAnswered.Min(point => point.X);
                    double yMax = topicStats.CardStatistics.Count;
                    double yMin = 0;

                    LineGraphVM.AddPahtUnscaled(unscaledPointsAnswered,xMax,xMin, yMax,yMin);

                    //Graph Axis Setup

                    LineGraphVM.VerticalUnit = "%";
                    LineGraphVM.VerticalNumbers = new ObservableCollection<string> { "100", "  80", "  60", "  40", "  20", "   0" };

                    //Adding Dates for Horizontal Axis
                    LineGraphVM.HorizontalUnit = "date";
                    List<string> datesFormatted = new List<string>();
                    foreach (long date in dates)
                    {
                        DateTime dateInTime = new DateTime(date);
                        datesFormatted.Add(dateInTime.ToString("dd-MM"));
                    }
                    LineGraphVM.HorizontalNumbers = new ObservableCollection<string>(datesFormatted);
                    break;
            }
        }


        private void OpenTopicSelectionWindowMethod()
        {
            Messenger.Instance.Send<OpenTopicSelectionWindowMessage>(null);
        }

        private void OpenStatisticsPanelMethod(int panelIndex)
        {
            SetGraph(panelIndex, DateTime.Now.Date.Ticks, DateTime.Now.Date.Ticks + TimeSpan.FromDays(10).Ticks);


            //Sending Message to MessageListener to change Panel
            OpenStatisticsPanelMessage messageObject = new OpenStatisticsPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenStatisticsPanelMessage>(messageObject);
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
