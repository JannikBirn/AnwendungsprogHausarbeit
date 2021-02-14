using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.IO;
using De.HsFlensburg.ClientApp012.Services.Serialization;
using System.Windows;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;
using System.Windows.Media;
using System.Windows.Ink;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class NewCardWindowViewModel : INotifyPropertyChanged
    {
        private string questionImagePath;
        private string answerImagePath;
        private string questionAudioPath;
        private string answerAudioPath;

        private WMPLib.WindowsMediaPlayer audioPlayer = new WMPLib.WindowsMediaPlayer();

        private Visibility questionPlayBtn = Visibility.Hidden;
        public Visibility QuestionPlayBtn
        {
            get { return questionPlayBtn; }
            set
            {
                questionPlayBtn = value;
                OnPropertyChanged("QuestionPlayBtn");
            }
        }
        private Visibility questionStopBtn = Visibility.Hidden;
        public Visibility QuestionStopBtn
        {
            get { return questionStopBtn; }
            set
            {
                questionStopBtn = value;
                OnPropertyChanged("QuestionStopBtn");
            }
        }


        private Visibility answerPlayBtn = Visibility.Hidden;
        public Visibility AnswerPlayBtn
        {
            get { return answerPlayBtn; }
            set
            {
                answerPlayBtn = value;
                OnPropertyChanged("AnswerPlayBtn");
            }
        }
        private Visibility answerStopBtn = Visibility.Hidden;
        public Visibility AnswerStopBtn
        {
            get { return answerStopBtn; }
            set
            {
                answerStopBtn = value;
                OnPropertyChanged("AnswerStopBtn");
            }
        }




        private Visibility answerCanvas;
        public Visibility AnswerCanvas
        {
            get { return answerCanvas; }
            set
            {
                answerCanvas = value;
                OnPropertyChanged("AnswerCanvas");
            }
        }


        private Visibility questionCanvas;
        public Visibility QuestionCanvas
        {
            get { return questionCanvas; }
            set
            {
                questionCanvas = value;
                OnPropertyChanged("QuestionCanvas");
            }
        }

        public String QuestionText { set; get; }
        public String QuestionVideoPath { set; get; } //Video reference
        public String QuestionAudioPath //Audio reference
        {
            get => questionAudioPath;
            set
            {
                questionAudioPath = value;
                OnPropertyChanged("QuestionAudioPath");
            }
        }
        public String QuestionImagePath
        {
            get => questionImagePath;
            set
            {
                questionImagePath = value;
                OnPropertyChanged("QuestionImagePath");
                OnPropertyChanged("QuestionImage");
            }
        }
        public BitmapImage QuestionImage
        {
            get
            {
                if (QuestionImagePath == null)
                    return null;
                return new BitmapImage(new Uri(QuestionImagePath));
            }
        }


        public String AnswerText { set; get; }
        public String AnswerVideoPath { set; get; } //Video reference
        public String AnswerAudioPath
        {
            get => answerAudioPath;
            set
            {
                answerAudioPath = value;
                OnPropertyChanged("AnswerAudioPath");

            }
        } //Audio reference

        public String AnswerImagePath
        {
            get => answerImagePath;
            set
            {
                answerImagePath = value;
                OnPropertyChanged("AnswerImagePath");
                OnPropertyChanged("AnswerImage");
            }
        }
        public BitmapImage AnswerImage
        {
            get
            {
                if (AnswerImagePath == null)
                    return null;
                return new BitmapImage(new Uri(AnswerImagePath));
            }
        }
        public TopicViewModel Topic { get; set; }
        public RelayCommand AddCard { get; }
        public RelayCommand LoadQuestionImage { get; }
        public RelayCommand DeleteQuestionImage { get; }
        public RelayCommand LoadAnswerImage { get; }
        public RelayCommand DeleteAnswerImage { get; }
        public RelayCommand LoadQuestionVideo { get; }
        public RelayCommand DeleteQuestionVideo { get; }
        public RelayCommand LoadAnswerVideo { get; }
        public RelayCommand DeleteAnswerVideo { get; }
        public RelayCommand LoadQuestionAudio { get; }
        public RelayCommand DeleteQuestionAudio { get; }
        public RelayCommand LoadAnswerAudio { get; }
        public RelayCommand DeleteAnswerAudio { get; }
        public RelayCommand PlayQuestionAudio { get; }
        public RelayCommand PlayAnswerAudio { get; }
        public RelayCommand StopAudio { get; }
        public RelayCommand CloseWindow { get; }
        public RelayCommand AddAndClose { get; }

        public MainWindowViewModel MainWindow { get; set; }


        public NewCardWindowViewModel(MainWindowViewModel model)
        {

            AddCard = new RelayCommand(param => AddCardMethod(param));
            LoadQuestionImage = new RelayCommand(() => LoadQuestionImageMethod());
            LoadAnswerImage = new RelayCommand(() => LoadAnswerImageMethod());
            LoadQuestionVideo = new RelayCommand(() => LoadQuestionVideoMethod());
            LoadAnswerVideo = new RelayCommand(() => LoadAnswerVideoMethod());
            LoadQuestionAudio = new RelayCommand(() => LoadQuestionAudioMethod());
            LoadAnswerAudio = new RelayCommand(() => LoadAnswerAudioMethod());
            DeleteQuestionImage = new RelayCommand(() => DeleteQuestionImageMethod());
            DeleteQuestionAudio = new RelayCommand(() => DeleteQuestionAudioMethod());
            DeleteQuestionVideo = new RelayCommand(() => DeleteQuestionVideoMethod());
            DeleteAnswerImage = new RelayCommand(() => DeleteAnswerImageMethod());
            DeleteAnswerAudio = new RelayCommand(() => DeleteAnswerAudioMethod());
            DeleteAnswerVideo = new RelayCommand(() => DeleteAnswerVideoMethod());
            PlayAnswerAudio = new RelayCommand(() => PlayAnswerAudioMethod());
            PlayQuestionAudio = new RelayCommand(() => PlayQuestionAudioMethod());
            StopAudio = new RelayCommand(() => StopAudioMethod());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            MainWindow = model;
            Topic = model.CurrentTopic;
        }

        private void AddCardMethod(object param)
        {
            if (!String.IsNullOrEmpty(QuestionText) && !String.IsNullOrEmpty(AnswerText))
            {
                string questionimagepath = "";
                string answerimagepath = "";
                string questionaudiopath = "";
                string answeraudiopath = "";
                string questionvideopath = "";
                string answervideopath = "";

                long cardId = DateTime.Now.Ticks;
                if (!String.IsNullOrEmpty(QuestionImagePath))
                {
                    questionimagepath = Save(QuestionImagePath, "QuestionImage", cardId);
                }
                if (!String.IsNullOrEmpty(AnswerImagePath))
                {

                    answerimagepath = Save(AnswerImagePath, "AnswerImage", cardId);
                }
                if (!String.IsNullOrEmpty(QuestionAudioPath))
                {
                    questionaudiopath = Save(QuestionAudioPath, "QuestionAudio", cardId);
                }
                if (!String.IsNullOrEmpty(AnswerAudioPath))
                {
                    answeraudiopath = Save(AnswerAudioPath, "AnswerAudio", cardId);
                }
                if (!String.IsNullOrEmpty(QuestionVideoPath))
                {
                    questionvideopath = Save(QuestionVideoPath, "QuestionVideo", cardId);
                }
                if (!String.IsNullOrEmpty(AnswerVideoPath))
                {
                    answervideopath = Save(AnswerVideoPath, "AnswerVideo", cardId);
                }

                // Check ob Text angegeben wurde

                if (questionimagepath != "")
                { questionvideopath = ""; }
                if (questionvideopath != "")
                { questionimagepath = ""; }
                if (answerimagepath != "")
                { answervideopath = ""; }
                if (answervideopath != "")
                { answerimagepath = ""; }

                CardViewModel cvm = new CardViewModel(cardId)
                {
                    QuestionText = QuestionText,
                    QuestionVideo = questionvideopath,
                    QuestionImage = questionimagepath,
                    QuestionAudio = questionaudiopath,
                    AnswerText = AnswerText,
                    AnswerVideo = answervideopath,
                    AnswerImage = answerimagepath,
                    AnswerAudio = answeraudiopath
                };
                MainWindow.CurrentTopic.Add(cvm);

                CloseWindowMethod(param);
            }
        }

        private void LoadQuestionImageMethod()
        {
            QuestionImagePath = ResourceSerializer.LoadImagePath();
            QuestionCanvas = Visibility.Visible;
        }

        private void DeleteQuestionImageMethod()
        {
            questionImagePath = null;
            QuestionImagePath = null;
            QuestionCanvas = Visibility.Hidden;
        }

        private void LoadQuestionVideoMethod()
        {
            QuestionVideoPath = ResourceSerializer.LoadVideoPath();
        }
        private void DeleteQuestionVideoMethod()
        {
            QuestionVideoPath = null;
        }
        private void LoadQuestionAudioMethod()
        {
            QuestionAudioPath = ResourceSerializer.LoadAudioPath();
            QuestionPlayBtn = Visibility.Visible;
            QuestionStopBtn = Visibility.Visible;
        }
        private void DeleteQuestionAudioMethod()
        {
            questionAudioPath = null;
            QuestionAudioPath = null;
            QuestionPlayBtn = Visibility.Hidden;
            QuestionStopBtn = Visibility.Hidden;
        }
        private void LoadAnswerImageMethod()
        {
            AnswerImagePath = ResourceSerializer.LoadImagePath();
            AnswerCanvas = Visibility.Visible;
        }
        private void DeleteAnswerImageMethod()
        {
            answerImagePath = null;
            AnswerImagePath = null;
            AnswerCanvas = Visibility.Hidden;
        }

        private void LoadAnswerVideoMethod()
        {
            AnswerVideoPath = ResourceSerializer.LoadVideoPath();
        }
        private void DeleteAnswerVideoMethod()
        {
            AnswerVideoPath = null;
        }

        private void LoadAnswerAudioMethod()
        {
            AnswerAudioPath = ResourceSerializer.LoadAudioPath();
            AnswerPlayBtn = Visibility.Visible;
            AnswerStopBtn = Visibility.Visible;
        }
        private void DeleteAnswerAudioMethod()
        {
            answerAudioPath = null;
            AnswerAudioPath = null;
            AnswerPlayBtn = Visibility.Hidden;
            AnswerStopBtn = Visibility.Hidden;
        }

        public String Save(string source, string folderName, long id)
        {
            return ResourceSerializer.SaveFile(source, $"{MainWindow.CurrentTopic.ID}\\{id}\\{folderName}\\{Path.GetFileName(source)}");
        }

        public void PlayQuestionAudioMethod()
        {
            if (questionAudioPath != null)
                audioPlayer.URL = QuestionAudioPath;
            audioPlayer.controls.play();
        }
        public void PlayAnswerAudioMethod()
        {
            if (!String.IsNullOrEmpty(AnswerAudioPath))
                audioPlayer.URL = AnswerAudioPath;
            audioPlayer.controls.play();
        }
        public void StopAudioMethod()
        {

            audioPlayer.controls.stop();
        }



        private void CloseWindowMethod(object param)
        {
            questionImagePath = null;
            answerImagePath = null;
            QuestionVideoPath = null;
            AnswerVideoPath = null;
            QuestionAudioPath = null;
            AnswerAudioPath = null;
            QuestionText = null;
            AnswerText = null;

            Window window = (Window)param;
            window.Close();
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
