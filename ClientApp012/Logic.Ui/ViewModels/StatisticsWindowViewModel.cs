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
            //Statistics.AddTestData(RootViewModel.TopicCollection[0].Model); // for testing purpose
            Statistics = new Statistics(RootViewModel.Model);
            //List<Card> cards = Statistics.topicStatistics[0].CardStatistics.GetCardsBetween(DateTime.Today.Ticks, DateTime.Today.AddDays(3).Ticks);


        }

        //private void SetGraph


        private void OpenTopicSelectionWindowMethod()
        {
            Messenger.Instance.Send<OpenTopicSelectionWindowMessage>(null);
        }

        private void OpenStatisticsPanelMethod(int panelIndex)
        {
            switch (panelIndex)
            {
                case OpenStatisticsPanelMessage.HISTORY_PANEL:
                    LineGraphVM.VerticalUnit = "%";
                    LineGraphVM.VerticalNumbers = new ObservableCollection<string>{"100",  "  80",  "  60", "  40", "  20", "   0"};
                    LineGraphVM.HorizontalUnit = "date";
                    break;
            }


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
