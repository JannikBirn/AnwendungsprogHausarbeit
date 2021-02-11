using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using Services.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LearningCardWindowViewModel : INotifyPropertyChanged
    {
        //Open Panel Commands
        public MainWindowViewModel MainWindow { get; set; }
        public RelayCommand OpenLearningCardAnswerPanel { get; set; }
        public RelayCommand CloseFinshWindow { get; set; }
        public RelayCommand StartAnswering { get; set; }
        public RelayCommand CloseWindow { get; set; }
        public RelayCommand RestartLearning { get; set; }
        public RelayCommand LearingCardsF { get; set; }
        public RelayCommand LearingCardsT { get; set; }


      /*  public BitmapImage QuestionImage
        {
            get
            {
                if (CurrentCard.QuestionImage == "")
                { return null; }
                return new BitmapImage(new Uri(CurrentCard.QuestionImage));
            }
        }
      */

        public TopicViewModel Topic { get { return MainWindow.CurrentTopic; } }
        public CardViewModel CurrentCard 
        {
            get { return MainWindow.CurrentTopic[Count]; }
            set { MainWindow.CurrentTopic[Count] = value;}
        }

        public int count = 0;
        public int Count
        {
            get { return count; }
            set { count = value;
                OnPropertyChanged("Count");
            }
        }
        public String QuestionImagePathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionImage); } }
        public String AnswerImagePathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerImage); } }
        public String QuestionVideoPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionVideo); } }
        public String AnswerVideoPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerVideo); } }
        public String QuestionAudioPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionAudio); } }
        public String AnswerAudioPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerAudio); } }

        public bool hasStarted = true;
        public bool HasStarted
        {
            get { return hasStarted; }
            set
            {
                hasStarted = value;
                OnPropertyChanged("HasStarted");
            }
        }

        public bool topicQuestioningStarted = false;

         public LearningCardWindowViewModel(MainWindowViewModel model)
        {
            MainWindow = model;
            

            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            LearingCardsF = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_FALSE));
            LearingCardsT = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_TRUE));
            RestartLearning = new RelayCommand(() => Restart());
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
                Reset();
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else
            {
                Count++;
                StartAnsweringMethod();
            }

        }

        public void Reset()
        {
            HasStarted = true;
            Count = 0;
            topicQuestioningStarted = false;

        }
        public void Restart()
        {
            Reset();
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.CLOSE_PANEL);
        }

        private void CloseWindowMethod(object param)
        {
            Reset();
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
