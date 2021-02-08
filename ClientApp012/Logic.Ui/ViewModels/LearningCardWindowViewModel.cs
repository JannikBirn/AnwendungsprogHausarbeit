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

        //Open Panel Commands
        public RelayCommand OpenLearningCardQuestionPanel { get; }
        public RelayCommand OpenLearningCardAnswerPanel { get; }
        public RelayCommand OpenLearningCardFinishPanel { get; }
        public RelayCommand StartAnswering { get; }
        public RelayCommand EndAnswering { get; }
        public RelayCommand LearingCardsF { get; }
        public RelayCommand LearingCardsT { get; }

        

        public int count = 2;

        public int Count
        {
            get { return count; }
            set { count = value;
                OnPropertyChanged("Count");
            }
        }
        public TopicViewModel CurrentTopic
        {
            get
            {
                return RootViewModel.TopicCollection[0]; ;
            }
        }
        public bool hasStarted = true;
        public bool HasStarted
        {
            get
            {
                return hasStarted;
            }
            set
            {
                hasStarted = value;
                OnPropertyChanged("HasStarted");
            }
        }

         public LearningCardWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;

            //  OpenLearningCardQuestionPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL));
            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            LearingCardsF = new RelayCommand(() => LearningCardMethodFalse());
            LearingCardsT = new RelayCommand(() => LearningCardMethodTrue());
            EndAnswering = new RelayCommand(() => EndAnsweringMethod());
        }

        public void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }


        public void StartAnsweringMethod()
        {
            CurrentTopic[Count].StartAnswering();
         
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL);
            HasStarted = false;
        }

        public void LearningCardMethodFalse()
        {
            CurrentTopic[Count].FinishAnswer(false);
            if (CurrentTopic.Count == Count)
            {
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else
            {
                Count++;
                StartAnsweringMethod();
            }
           
        }

        public void LearningCardMethodTrue()
        {
            CurrentTopic[Count].FinishAnswer(true);
            if (CurrentTopic.Count == Count)
            {
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else 
            {
                Count++;
                StartAnsweringMethod();
            }
        }

        public void EndAnsweringMethod()
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
