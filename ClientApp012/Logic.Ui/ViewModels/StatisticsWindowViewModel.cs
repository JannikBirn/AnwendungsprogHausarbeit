using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class StatisticsWindowViewModel
    {

        //public TopicCollectionViewModel TopicCollectionVM { get; set; }
        public RootViewModel RootViewModel { get; set; }

        public RelayCommand OpenStatisticsHistoryPanel { get; }
        public RelayCommand OpenStatisticsTimePanel { get; }
        public RelayCommand OpenStatisticsQualityPanel { get; }


        public StatisticsWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            OpenStatisticsHistoryPanel = new RelayCommand(() => OpenStatisticsPanelMethod( OpenStatisticsPanelMessage.HISTORY_PANEL));
            OpenStatisticsTimePanel = new RelayCommand(() => OpenStatisticsPanelMethod( OpenStatisticsPanelMessage.TIME_PANEL));
            OpenStatisticsQualityPanel = new RelayCommand(() => OpenStatisticsPanelMethod( OpenStatisticsPanelMessage.QUALITY_PANEL));

        }      

        private void OpenStatisticsPanelMethod(int panelIndex)
        {
            OpenStatisticsPanelMessage messageObject = new OpenStatisticsPanelMessage();
            messageObject.PanelIndex = panelIndex;


            Messenger.Instance.Send<OpenStatisticsPanelMessage>(messageObject);
        }
    }
}
