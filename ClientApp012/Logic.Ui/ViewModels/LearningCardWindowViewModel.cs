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
using System.Windows.Threading;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LearningCardWindowViewModel : INotifyPropertyChanged
    {
        //Open Panel Commands
        public MainWindowViewModel MainWindow { get; set; }
        //RelaCommands
        public RelayCommand OpenLearningCardAnswerPanel { get; set; }
        public RelayCommand StartAnswering { get; set; }
        public RelayCommand CloseWindow { get; set; }
        public RelayCommand RestartLearning { get; set; }
        public RelayCommand LearingCardsF { get; set; }
        public RelayCommand LearingCardsT { get; set; }
        public RelayCommand PlayVideo { get; set; }
        public RelayCommand PauseVideo { get; set; }
        public RelayCommand ReplayVideo { get; set; }
        public RelayCommand ResetLearning { get; set; }

        // Propertys
        public BitmapImage QuestionImagePathAbsolute 
        {
            get
            {      //creates a copy of the original so it's possible to delete   
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                if (BinarySerializer.GetAbsolutePath(CurrentCard.QuestionImage) != "")
                {
                    bitmapImage.UriSource = new Uri(BinarySerializer.GetAbsolutePath(CurrentCard.QuestionImage));
                    bitmapImage.EndInit();
                    return bitmapImage;
                } else
                {
                    return null;
                }

                 } 
        }
        public BitmapImage AnswerImagePathAbsolute 
        { 
            get
            {    //creates a copy of the original so it's possible to delete
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                if (BinarySerializer.GetAbsolutePath(CurrentCard.AnswerImage) != "")
                {
                    bitmapImage.UriSource = new Uri(BinarySerializer.GetAbsolutePath(CurrentCard.AnswerImage));
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
                else
                {
                    return null;
                }
            } 
        }

        public String questionVideoPathAbsolute = "";
        public String QuestionVideoPathAbsolute
        {
            get
            {
                if (BinarySerializer.GetAbsolutePath(CurrentCard.QuestionVideo) != "")
                {
                return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionVideo);
                }
                else
                {
                    return questionVideoPathAbsolute = "";
                   
                }
            }
            set
            {
                questionVideoPathAbsolute = value;
                OnPropertyChanged("QuestionVideoPathAbsolute");
            }
        }
        public String answerVideoPathAbsolute = "";
        public String AnswerVideoPathAbsolute
        {
            get
            {
                if (BinarySerializer.GetAbsolutePath(CurrentCard.AnswerVideo) != "")
                {
                    return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerVideo);
                }
                else 
                {
                    return answerVideoPathAbsolute = ""; }
                }
            set 
            {
                answerVideoPathAbsolute = value;
                OnPropertyChanged("AnswerVideoPathAbsolute");
            }
        }
        public String questionAudioPathAbsolute = "";
        public String QuestionAudioPathAbsolute 
        {
            get 
            { 
                if(BinarySerializer.GetAbsolutePath(CurrentCard.QuestionAudio) != "")
                {
                    return BinarySerializer.GetAbsolutePath(CurrentCard.QuestionAudio);
                }
            else
                {
                    return questionAudioPathAbsolute = "";
                }
            }
            set
            {
                questionAudioPathAbsolute = value;
                OnPropertyChanged("QuestionAudioPathAbsolute");
            }
        }
        public String answerAudioPathAbsolute ="";
        public String AnswerAudioPathAbsolute
        { 
            get 
            { if(BinarySerializer.GetAbsolutePath(CurrentCard.AnswerAudio) != "")
                {
                    return BinarySerializer.GetAbsolutePath(CurrentCard.AnswerAudio);
                }
                else
                {
                    return answerAudioPathAbsolute = "";
                }
            }
            set
            {
                answerAudioPathAbsolute = value;
                OnPropertyChanged("AnswerAudioPathAbsolute");
            }
        }

        public TopicViewModel Topic { get { return MainWindow.CurrentTopic; } }
        public CardViewModel CurrentCard
        {
            get { return MainWindow.CurrentTopic[IndexCard]; }
            set { MainWindow.CurrentTopic[IndexCard] = value; }
        }

        public int indexCard = 0;
        public int IndexCard
        {
            get { return indexCard; }
            set { indexCard = value;
                OnPropertyChanged("IndexCard");
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

        public int TrueAnswers
        {
            get { return trueAnswers; }
            set { trueAnswers = value;
                OnPropertyChanged("TrueAnswers");
            }
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

        public String visibiltyControllButtons = "Hidden";
        public String VisibiltyControllButtons
        {
            get
            {
                if (AnswerAudioPathAbsolute != "" || QuestionAudioPathAbsolute != "" || QuestionVideoPathAbsolute != "" || AnswerVideoPathAbsolute != "")
                {
                    return "Visible";
                }
                else
                {
                    return visibiltyControllButtons;
                }
            }
            set { visibiltyControllButtons = value;
                OnPropertyChanged("VisibiltyControllButtons");
                }
         }
        public String feedback = "";
        public String Feedback
        {
            get
            {
                if (TrueAnswers == 0)
                    return "Not bad";
                else if (TrueAnswers <= (Topic.Count * 3 / 2))
                    return "Next time";
                else
                    return "Very good!";
            }
            set 
            {
                feedback = value;
                OnPropertyChanged("Feedback");
            }
        }
        //Variables
        public int learnRounds = 3;
        public bool topicQuestioningStarted = false;

        public LearningCardWindowViewModel(MainWindowViewModel model)
        {
            //referenz to the model
            MainWindow = model;

            //adding relaycommands
            StartAnswering = new RelayCommand(() => StartAnsweringMethod());
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            LearingCardsF = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_FALSE));
            LearingCardsT = new RelayCommand(() => LearningCardMethod(SendAnswerMessage.ANSWER_TRUE));
            RestartLearning = new RelayCommand(() => Restart());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            PauseVideo = new RelayCommand(() => PauseVideoMethod());
            PlayVideo = new RelayCommand(() => PlayVideoMethod());
            ReplayVideo = new RelayCommand(() => ReplayVideoMethod());
            ResetLearning = new RelayCommand(() => Reset());
        }
        //to open and close panels
        public void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;

            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }

        //bindet to Start button
        public void StartAnsweringMethod()
        {
            if (!topicQuestioningStarted)
            {
                Topic.StartQuestioning();
                topicQuestioningStarted = true;
            }
            while(!CheckForLearning(CurrentCard))
            {
                if (IndexCard < Topic.Count -1)
                {
                    CurrentCard.FinishAnswer(false);
                    IndexCard++;
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
                TrueAnswers++;
       
            if (Topic.Count-1 == IndexCard && learnRounds == 1)
            {
                Topic.FinishQuestioning();
                OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL);
            }
            else if(Topic.Count-1 == IndexCard)
            {
                learnRounds--;
                IndexCard = 0;
                StartAnsweringMethod();
            }
            else
            {
                IndexCard++;
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
            IndexCard = 0;
            learnRounds = 3;
            HasStarted = true;
            trueAnswers = 0;
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
            AnswerVideoPathAbsolute = "";
            AnswerVideoPathAbsolute = BinarySerializer.GetAbsolutePath(CurrentCard.AnswerVideo);
            QuestionAudioPathAbsolute = "";
            QuestionAudioPathAbsolute = BinarySerializer.GetAbsolutePath(CurrentCard.QuestionAudio);
            AnswerAudioPathAbsolute = "";
            AnswerAudioPathAbsolute = BinarySerializer.GetAbsolutePath(CurrentCard.AnswerAudio);
            VideoAudioControl = "Play";
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
