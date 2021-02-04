using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class StatisticsWindowViewModel : INotifyPropertyChanged
    {

        public RootViewModel RootViewModel { get; set; }

        //Open Panel Commands
        public RelayCommand OpenStatisticsHistoryPanel { get; }
        public RelayCommand OpenStatisticsTimePanel { get; }
        public RelayCommand OpenStatisticsQualityPanel { get; }

        //Open Topic Selection
        public RelayCommand OpenTopicSelectionWindow { get; }

        public TopicViewModel SelectedTopicVM { get; set; }


        public StatisticsWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            OpenStatisticsHistoryPanel = new RelayCommand(() => OpenStatisticsPanelMethod( OpenStatisticsPanelMessage.HISTORY_PANEL));
            OpenStatisticsTimePanel = new RelayCommand(() => OpenStatisticsPanelMethod( OpenStatisticsPanelMessage.TIME_PANEL));
            OpenStatisticsQualityPanel = new RelayCommand(() => OpenStatisticsPanelMethod( OpenStatisticsPanelMessage.QUALITY_PANEL));
            OpenTopicSelectionWindow = new RelayCommand(() => OpenTopicSelectionWindowMethod());
          
        }

        


        private void OpenTopicSelectionWindowMethod()
        {
            Messenger.Instance.Send<OpenTopicSelectionWindowMessage>(null);
        }

        private void OpenStatisticsPanelMethod(int panelIndex)
        {
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
