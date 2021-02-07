using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp012.Ui.Desktop.StatisticsWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace De.HsFlensburg.ClientApp012.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public bool myBindableProperty => true;

        //Window Instances
        private StatisticsWindow StatisticsWindow { get; set; }
        private PrintWindow PrintWindow{ get; set; }
        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            // Reaction to a message
            ServiceBus.Instance.Register<OpenNewClientWindowMessage>(this, delegate ()
            {
                NewClientWindow myWindow = new NewClientWindow();
                myWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenNewCardOverViewMessage>(this, delegate ()
            {
                CardOverviewWindow myWindow = new CardOverviewWindow();
                myWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenStatisticsWindowMessage>(this, delegate ()
            {
                    StatisticsWindow = new StatisticsWindow();
                StatisticsWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenLearningCardWindowMessage>(this, delegate ()
             {
               LearningCardWindow myWindow = new LearningCardWindow();
               myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenPrintWindowMessage>(this, delegate (OpenPrintWindowMessage message)
                {
                    PrintWindow  = new PrintWindow();
                    PrintWindow.Grid1.ItemsSource = ((DataGrid)message.Grid).ItemsSource;
                    PrintWindow.ShowDialog();
                });


            Messenger.Instance.Register<OpenStatisticsPanelMessage>(this, delegate (OpenStatisticsPanelMessage messageObject)
            {
                Frame statisticsFrame = StatisticsWindow.StatisticsFrame;
                switch (messageObject.PanelIndex)
                {
                    case OpenStatisticsPanelMessage.HISTORY_PANEL:
                        statisticsFrame.Content = new StatisticsHistoryPanel();
                        break;
                    case OpenStatisticsPanelMessage.TIME_PANEL:
                        statisticsFrame.Content = new StatisticsTimePanel();
                        break;
                    case OpenStatisticsPanelMessage.QUALITY_PANEL:
                        statisticsFrame.Content = new StatisticsQualityPanel();
                        break;
                }
            });
            Messenger.Instance.Register<OpenTopicSelectionWindowMessage>(this, delegate (OpenTopicSelectionWindowMessage message)
            {
                    StatisticsTopicSelectionWindow myWindow = new StatisticsTopicSelectionWindow();
                myWindow.ShowDialog();
            });

            Messenger.Instance.Register<SetPrintPreviewMessage>(this, delegate (SetPrintPreviewMessage message)
            {
                //PrintWindow.Grid1 = message.FixedDocumentSequence;
            });
        }
    }
}
