using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using Services.Serialization;
using De.HsFlensburg.ClientApp012.Services.Serialization;
using System.Windows;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class NewCardWindowViewModel : INotifyPropertyChanged
    {
        private string questionImagePath;
        private string answerImagePath;

        public String QuestionText { set; get; }
        public String QuestionVideoPath { set; get; } //Video reference
        public String QuestionAudioPath { set; get; } //Audio reference
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
        public String AnswerAudioPath { set; get; } //Audio reference

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
                if (QuestionImagePath == null)
                    return null;
                return new BitmapImage(new Uri(QuestionImagePath));
            }
        }
        public TopicViewModel Topic { get; set; }
        public RelayCommand AddCard { get; }
        public RelayCommand LoadQuestionImage { get; }
        public RelayCommand LoadAnswerImage { get; }
        public RelayCommand LoadQuestionVideo { get; }
        public RelayCommand LoadAnswerVideo { get; }
        public RelayCommand LoadQuestionAudio { get; }
        public RelayCommand LoadAnswerAudio { get; }
        public RelayCommand CloseWindow { get; }
        public MainWindowViewModel MainWindow { get; set; }


        public NewCardWindowViewModel(MainWindowViewModel model)
        {
            AddCard = new RelayCommand(() => AddCardMethod());
            LoadQuestionImage = new RelayCommand(() => LoadQuestionImageMethod());
            LoadAnswerImage = new RelayCommand(() => LoadAnswerImageMethod());
            LoadQuestionVideo = new RelayCommand(() => LoadQuestionVideoMethod());
            LoadAnswerVideo = new RelayCommand(() => LoadAnswerVideoMethod());
            LoadQuestionAudio = new RelayCommand(() => LoadQuestionAudioMethod());
            LoadAnswerAudio = new RelayCommand(() => LoadAnswerAudioMethod());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            MainWindow = model;
            Topic = model.CurrentTopic;
        }

        private void AddCardMethod()
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
        }

        private void LoadQuestionImageMethod()
        {
            QuestionImagePath = ResourceSerializer.LoadImagePath();
        }

        private void LoadQuestionVideoMethod()
        {
            QuestionVideoPath = ResourceSerializer.LoadVideoPath();
        }
        private void LoadQuestionAudioMethod()
        {
            QuestionAudioPath = ResourceSerializer.LoadAudioPath();
        }

        private void LoadAnswerImageMethod()
        {
            AnswerImagePath = ResourceSerializer.LoadImagePath();
        }

        private void LoadAnswerVideoMethod()
        {
            AnswerVideoPath = ResourceSerializer.LoadVideoPath();
        }

        private void LoadAnswerAudioMethod()
        {
            AnswerAudioPath = ResourceSerializer.LoadAudioPath();
        }

        public String Save(string source, string folderName, long id)
        {
            return ResourceSerializer.SaveFile(source, $"{MainWindow.CurrentTopic.ID}\\{id}\\{folderName}\\{Path.GetFileName(source)}");
        }

        private void CloseWindowMethod(object param)
        {
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
