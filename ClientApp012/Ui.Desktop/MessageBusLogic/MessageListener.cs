﻿using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using De.HsFlensburg.ClientApp012.Ui.Desktop.StatisticsWindows;
using De.HsFlensburg.ClientApp012.Ui.Desktop.LearningCardWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace De.HsFlensburg.ClientApp012.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public bool myBindableProperty => true;

        //Window Instances
        private StatisticsWindow StatisticsWindow { get; set; }

        private LearningCardWindow LearningCardWindow { get; set; }

        private NewCardWindow NewCardWindow { get; set; }

        private NewTopicWindow NewTopicWindow { get; set; }

        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {

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
                LearningCardWindow = new LearningCardWindow();
                LearningCardWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenNewCardWindowMessage>(this, delegate ()
            {
                NewCardWindow = new NewCardWindow();
                NewCardWindow.ShowDialog();
            });

            ServiceBus.Instance.Register<OpenNewTopicWindowMessage>(this, delegate ()
            {
                NewTopicWindow = new NewTopicWindow();
                NewTopicWindow.ShowDialog();
            });

            Messenger.Instance.Register<OpenPrintWindowMessage>(this, delegate (OpenPrintWindowMessage message)
                {
                    PrintWindow myPrintWindow = new PrintWindow();
                    myPrintWindow.Grid1.ItemsSource = ((DataGrid)message.Grid).ItemsSource;
                    myPrintWindow.ShowDialog();
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
                    case OpenStatisticsPanelMessage.NO_PANEL:
                        statisticsFrame.Content =null;
                        break;
                }
            });

            Messenger.Instance.Register<OpenLearningCardPanelMessage>(this, delegate (OpenLearningCardPanelMessage messageObject)
            {
                Frame learningCardFrame = LearningCardWindow.LearningCardFrame;
                switch (messageObject.PanelIndex)
                {
                    case OpenLearningCardPanelMessage.QUESTION_PANEL:
                        learningCardFrame.Content = new LearningCardQuestionPanel();
                        break;
                    case OpenLearningCardPanelMessage.ANSWER_PANEL:
                        learningCardFrame.Content = new LearningCardAnswerPanel();
                        break;
                    case OpenLearningCardPanelMessage.FINISH_PANEL:
                        learningCardFrame.Content = new LearningCardFinishPanel();
                        break;
                    case OpenLearningCardPanelMessage.CLOSE_PANEL:
                        learningCardFrame.Content = "";
                        break;
                }
            });


            Messenger.Instance.Register<OpenTopicSelectionWindowMessage>(this, delegate (OpenTopicSelectionWindowMessage message)
            {
                StatisticsTopicSelectionWindow myWindow = new StatisticsTopicSelectionWindow();
                myWindow.ShowDialog();
            });

            Messenger.Instance.Register<SendAnswerMessage>(this, delegate (SendAnswerMessage message)
            {

            });
        }
    }
}
