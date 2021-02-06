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
    public class LearningCardWindowViewModel : INotifyPropertyChanged
    {
        public RootViewModel RootViewModel { get; set; }

       // public CardViewModel CardViewModel { get; set; }

        //Open Panel Commands
        public RelayCommand OpenLearningCardQuestionPanel { get; }
        public RelayCommand OpenLearningCardAnswerPanel { get; }
        public RelayCommand OpenLearningCardFinishPanel { get; }
        public RelayCommand StartAnswering { get; }
        public RelayCommand EndAnswering { get; }

        public bool test = true;

        public bool HasStarted
        {
            get
            {
                return test;
            }

            set
            {
                test = value;
                OnPropertyChanged("HasStarted");
            }
        }

        public bool starting = true;


        public LearningCardWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;

            //  OpenLearningCardQuestionPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL));
            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            OpenLearningCardFinishPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL));
            EndAnswering = new RelayCommand(() => EndAnsweringMethod());
           

            //  QuestionText = RootViewModel.TopicCollection[0][0];
        }

        private void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }

        private void StartAnsweringMethod()
        {
           // CardViewModel.StartAnswering();
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL);
            HasStarted = false;
        }

        private void EndAnsweringMethod()
        {
            HasStarted = true;
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
