using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class StatisticsTopicSelectionWindowViewModel : INotifyPropertyChanged
    {

        //Refrenzes
        public RootViewModel RootViewModel { get; set; }
        private StatisticsWindowViewModel StatisticsWindowVM { get; set; }


        //Commands for StaticsTopicSelectionWindow
        public RelayCommand SelectedTopicCommand { get; }


        

        public StatisticsTopicSelectionWindowViewModel(RootViewModel model, StatisticsWindowViewModel statisticsVM)
        {
            //Refrenzing to the model
            RootViewModel = model;
            StatisticsWindowVM = statisticsVM;

            //Adding relay commands
            SelectedTopicCommand = new RelayCommand((param) => SelectedTopicCommandMethod(param));

        }


        private void SelectedTopicCommandMethod(object topic)
        {
            TopicViewModel topicVM = (TopicViewModel)topic;
            StatisticsWindowVM.SelectedTopic = topicVM;
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
