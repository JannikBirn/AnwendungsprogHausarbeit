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

        public RelayCommand OpenNewPanel{ get; }


        public StatisticsWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            OpenNewPanel = new RelayCommand(param => OpenStatisticsHistoryPanel(param));

        }

        private void OpenStatisticsHistoryPanel(object element)
        {
            OpenStatisticsPanelMessage messageObject = new OpenStatisticsPanelMessage();
            messageObject.PanelIndex = OpenStatisticsPanelMessage.HISTORY_PANEL;
            messageObject.Frame = element;

            Messenger.Instance.Send<OpenStatisticsPanelMessage>(messageObject);

        }

        //private void OpenNewClientWindowMethod()
        //{
        //    ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        //}

    }
}
