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
        public RelayCommand StartQuestioning {get; }
        public RelayCommand StartAnswering { get; }
        public RelayCommand EndAnswering { get; }
        public RelayCommand LearingCardsF { get; }
        public RelayCommand LearingCardsT { get; }
        public RelayCommand LearingCards { get; }

        public CardViewModel currentCard;
        public TopicViewModel CurrentTopic
        {
            get { return RootViewModel.TopicCollection[0]; }
        }
        public CardViewModel CurrentCard 
        {
            get{ return CurrentTopic[Count]; }
        }

        public int count = 0;
        public int Count
        {
            get { return count; }
            set { count = value;
                OnPropertyChanged("Count");
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
            //LearingCards = new RelayCommand(() => LearningCardMethod());
        }

        public void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }


        public void StartAnsweringMethod()
        {
            CurrentCard.StartAnswering();
         
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL);
            HasStarted = false;
        }


        public void LearningCardMethod(bool answer)
        {
            CurrentCard.FinishAnswer(answer);
            if (CurrentTopic.Count - 1 == Count)
            {
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else
            {
                Count++;
                StartAnsweringMethod();
            }

        }

        public void LearningCardMethodFalse()
        {
            CurrentCard.FinishAnswer(false);
            if (CurrentTopic.Count-1 == Count)
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
            CurrentCard.FinishAnswer(true);
            if (CurrentTopic.Count-1 == Count)
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
