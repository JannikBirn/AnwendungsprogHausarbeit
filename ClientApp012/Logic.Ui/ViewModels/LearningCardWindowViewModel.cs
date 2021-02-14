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
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LearningCardWindowViewModel : INotifyPropertyChanged
    {
        //Open Panel Commands
        public MainWindowViewModel MainWindow { get; set; }
        public RelayCommand OpenLearningCardAnswerPanel { get; set; }
        public RelayCommand StartAnswering { get; set; }
        public RelayCommand CloseWindow { get; set; }
        public RelayCommand RestartLearning { get; set; }
        public RelayCommand LearingCardsF { get; set; }
        public RelayCommand LearingCardsT { get; set; }
        public RelayCommand PlayVideo { get; set; }
        public RelayCommand PauseVideo { get; set; }
        public RelayCommand ReplayVideo { get; set; }

        public String QuestionImagePathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionImage); } }
        public String AnswerImagePathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerImage); } }

        public String questionViedeoPath = "";
        public String QuestionVideoPathAbsolute
        {
            get { return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionVideo); }
            set { questionViedeoPath = value; }
        }
        public String AnswerVideoPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerVideo); } }
        public String QuestionAudioPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionAudio); } }
        public String AnswerAudioPathAbsolute { get { return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerAudio); } }

       

        public TopicViewModel Topic { get { return MainWindow.CurrentTopic; } }
        public CardViewModel CurrentCard 
        {
            get { return MainWindow.CurrentTopic[Count]; }
            set { MainWindow.CurrentTopic[Count] = value;}
        }

        public int count = 0;
        public int learnRounds = 3;
        public bool topicQuestioningStarted = false;
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
            set
            {
                hasStarted = value;
                OnPropertyChanged("HasStarted");
            }
        }

        public int trueAnswers = 0;

        public string TrueAnswers
        {
            get { return trueAnswers.ToString(); }
        }
        
        public string videoAudioControl = "play";
        public string VideoAudioControl
        { 
          get { return videoAudioControl; }
          set {
                videoAudioControl = value;
                OnPropertyChanged("VideoAudioControl");
            } 
        }  

         public LearningCardWindowViewModel(MainWindowViewModel model)
        {
            MainWindow = model;
            

            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            LearingCardsF = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_FALSE));
            LearingCardsT = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_TRUE));
            RestartLearning = new RelayCommand(() => Restart());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            PauseVideo = new RelayCommand(() => PauseVideoMethod());
            PlayVideo = new RelayCommand(() => PlayVideoMethod());
            ReplayVideo = new RelayCommand(() => ReplayVideoMethod());
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
                if (Count < Topic.Count)
                {
                    CurrentCard.FinishAnswer(false);
                    Count++;
                }
                else
                {
                    return;
                }
            }

            CurrentCard.StartAnswering();
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL);
            HasStarted = false;
        }


        public void LearningCardMethod(bool answer)
        {
            CurrentCard.FinishAnswer(answer);
            if (answer)
                trueAnswers++;
       
            if (Topic.Count - 1 == Count && learnRounds == 1)
            {
                Reset();
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else if(Topic.Count - 1 == Count)
            {
                learnRounds--;
                Count = 0;
                StartAnsweringMethod();

            }
            else
            {
                Count++;
                StartAnsweringMethod();
            }

        }

        //Checking last 3 card answers
        private bool CheckForLearning(CardViewModel card)
        {
            int countTrues = 0;

            if (card.cardAnswers.Count > 3)

            {
                for (int i = 0; i < 3; i++)
                {
                    if (card.cardAnswers[card.cardAnswers.Count -1 - i].IsAnswerCorrect)
                    {
                        countTrues++;
                    }
                }
            }
            return countTrues < 3;
        }

        public void Reset()
        {
            Count = 0;
            learnRounds = 3;
            trueAnswers = 0;
            topicQuestioningStarted = false;

        }
        public void Restart()
        {
            Reset();
            HasStarted = true;
            OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.CLOSE_PANEL);
        }

        private void CloseWindowMethod(object param)
        {
            Reset();
            Window window = (Window)param;
            window.Close();
        }

        public void PlayVideoMethod() 
        {
            VideoAudioControl = "Play";

        }

        public void PauseVideoMethod()
        {
            VideoAudioControl = "Pause";

        }

        public void ReplayVideoMethod()
        {
            QuestionVideoPathAbsolute = "";
            QuestionVideoPathAbsolute = BinarySerializer.GetAbsolutePath(CurrentCard.QuestionVideo);

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
