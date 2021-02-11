using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LearningCardWindowViewModel : INotifyPropertyChanged
    {
        //Open Panel Commands
        public RelayCommand OpenLearningCardAnswerPanel { get; }
        public RelayCommand CloseFinshWindow { get; }
        public RelayCommand StartAnswering { get; }
        public RelayCommand CloseWindow { get; }
        public RelayCommand Reset { get; }
        public RelayCommand LearingCardsF { get; }
        public RelayCommand LearingCardsT { get; }

        public CardViewModel currentCard;
        public TopicViewModel Topic { get; set; }
        public CardViewModel CurrentCard 
        {
            get{ return Topic[Count]; }
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
            get { return hasStarted; }
            set { hasStarted = value;               
                OnPropertyChanged("HasStarted");
            }
        }

        public bool topicQuestioningStarted = false;

         public LearningCardWindowViewModel(MainWindowViewModel model)
        {
            Topic = model.CurrentTopic;

            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            LearingCardsF = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_FALSE));
            LearingCardsT = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_TRUE));
            Reset = new RelayCommand(() => reset());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
        }

        public void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }


        public void StartAnsweringMethod()
        {
            if (!topicQuestioningStarted)
            {
                Topic.StartQuestioning();
                topicQuestioningStarted = true;
            }

            while(!CheckForLearning(CurrentCard))
            {     
               Count++;
            }

            CurrentCard.StartAnswering();
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL);
            HasStarted = false;
        }


        public void LearningCardMethod(bool answer)
        {
            CurrentCard.FinishAnswer(answer);
       
            if (Topic.Count - 1 == Count)
            {
                Topic.FinishQuestioning();
                reset();
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
            Count = 0;
            topicQuestioningStarted = false;

        }
        public void Restart()
        {
            reset();
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.CLOSE_PANEL);
        }

        private void CloseWindowMethod(object param)
        {
            reset();
            Window window = (Window)param;
            window.Close();
        }

        private bool CheckForLearning(CardViewModel card)
        {
            int countTrues = 0;
        
            if(card.cardAnswers != null)
            { foreach( CardAnswer answers in card.cardAnswers)
                {
                    if(answers.IsAnswerCorrect)
                    {
                        countTrues++;
                    }
                }
            }
            return countTrues <=3;
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
