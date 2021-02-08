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
        public RelayCommand OpenLearningCardAnswerPanel { get; }
        public RelayCommand CloseFinshWindow { get; }
        public RelayCommand StartAnswering { get; }
        public RelayCommand Reset { get; }
        public RelayCommand LearingCardsF { get; }
        public RelayCommand LearingCardsT { get; }

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

        public bool questioning = false;

         public LearningCardWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;

            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            LearingCardsF = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_FALSE));
            LearingCardsT = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_TRUE));
            Reset = new RelayCommand(() => reset());
        }

        public void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }


        public void StartAnsweringMethod()
        {
            if (!questioning)
            {
                CurrentTopic.StartQuestioning();
                questioning = true;
            }
            CurrentCard.StartAnswering();
         
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL);
            HasStarted = false;
        }


        public void LearningCardMethod(bool answer)
        {
            CurrentCard.FinishAnswer(answer);
       
            if (CurrentTopic.Count - 1 == Count)
            {
                CurrentTopic.FinishQuestioning();
                questioning = false;
                Count = 0;
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else
            {
                Count++;
                StartAnsweringMethod();
            }

        } 

        public void reset()
        {
            HasStarted = true;
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.CLOSE_PANEL);
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
