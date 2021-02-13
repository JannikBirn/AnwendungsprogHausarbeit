using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class StatisticsTopicSelectionWindowViewModel
    {

        //Refrenzes
        public RootViewModel RootViewModel { get; set; }
        private StatisticsWindowViewModel StatisticsWindowVM { get; set; }


        //Commands for StaticsTopicSelectionWindow
        public RelayCommand SelectedTopicCommand { get; }
        public RelayCommand CloseWindow { get; }

        public List<KeyValuePair<long, string>> TopicList { get; set; }


        public StatisticsTopicSelectionWindowViewModel(RootViewModel model, StatisticsWindowViewModel statisticsVM)
        {
            //Refrenzing to the model
            RootViewModel = model;
            StatisticsWindowVM = statisticsVM;

            //Initialising Topic List
            RootViewModel.TopicCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(RefreshList);

            //Adding relay commands
            SelectedTopicCommand = new RelayCommand((param) => SelectedTopicCommandMethod(param));
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
        }

        private void RefreshList()
        {
            TopicList = new List<KeyValuePair<long, string>>();
            TopicList.Add(new KeyValuePair<long, string>(-1, "All"));

            foreach (TopicViewModel topicVM in RootViewModel.TopicCollection)
            {
                TopicList.Add(new KeyValuePair<long, string>(topicVM.ID, topicVM.Name));
            }
        }

        private void RefreshList(object sender, NotifyCollectionChangedEventArgs e)
        {
            RefreshList();
        }


        private void SelectedTopicCommandMethod(object topic)
        {
            //TopicViewModel topicVM = (TopicViewModel)topic;
            KeyValuePair<long, string> topicKey = (KeyValuePair<long, string>)topic;
            if (topicKey.Key == -1)
            {
                StatisticsWindowVM.SelectedTopic = null;
            }
            else
            {
                StatisticsWindowVM.SelectedTopic = RootViewModel.TopicCollection.First(topicVM => topicVM.ID == topicKey.Key && topicVM.Name == topicKey.Value);
            }
            StatisticsWindowVM.OpenStatisticsPanelMethod(StatisticsWindowVM.CurrentPanelIndex);
        }

        private void CloseWindowMethod(object param)
        {
            Window window = (Window)param;
            window.Close();
        }

    }
}
