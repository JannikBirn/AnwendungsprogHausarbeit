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

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class NewCardWindowViewModel
    {
        public Image QuestionImage = null;
        public Image AnswerImage = null;

       
        public String QuestionText { set; get; }
        public String QuestionVideoPath { set; get; } //Video reference
        public String QuestionAudioPath { set; get; } //Audio reference
        public String QuestionImagePath { set; get; }
        public String AnswerText { set; get; }
        public String AnswerVideoPath { set; get; } //Video reference
        public String AnswerAudioPath { set; get; } //Audio reference
        public String AnswerImagePath { set; get; }

        public TopicViewModel Topic { get; set; }
        public RelayCommand AddCard { get; }
        public RelayCommand LoadQuestionImage { get; }
        public RelayCommand LoadAnswerImage { get; }
        public RelayCommand LoadQuestionVideo { get; }
        public RelayCommand LoadAnswerVideo { get; }
        public RelayCommand LoadQuestionAudio { get; }
        public RelayCommand LoadAnswerAudio { get; }


        public NewCardWindowViewModel(RootViewModel model)
        {
            AddCard = new RelayCommand(() => AddCardMethod());
            LoadQuestionImage = new RelayCommand(() => LoadQuestionImageMethod());
            LoadAnswerImage = new RelayCommand(() => LoadAnswerImageMethod());
            LoadQuestionVideo = new RelayCommand(() => LoadQuestionVideoMethod());
            LoadAnswerVideo = new RelayCommand(() => LoadAnswerVideoMethod());
            LoadQuestionAudio = new RelayCommand(() => LoadQuestionAudioMethod());
            LoadAnswerAudio = new RelayCommand(() => LoadAnswerAudioMethod());
            Topic = model.TopicCollection[0];
        }

        private void AddCardMethod()
        {
            long cardId = DateTime.Now.Ticks;
            if (QuestionImage != null)
            {
                QuestionImagePath = Save(QuestionImagePath, "QuestionImage", cardId);
            }
            if (AnswerImage != null)
            {
                AnswerImagePath = Save(AnswerImagePath, "AnswerImage", cardId);
            }
            if (!String.IsNullOrEmpty(QuestionAudioPath))
            {
                QuestionAudioPath = Save(QuestionAudioPath, "QuestionAudio", cardId);
            }
            if (!String.IsNullOrEmpty(AnswerAudioPath))
            {
                AnswerAudioPath = Save(AnswerAudioPath, "AnswerAudio", cardId);
            }
            if (!String.IsNullOrEmpty(QuestionVideoPath))
            {
                QuestionVideoPath = Save(QuestionVideoPath, "QuestionVideo", cardId);
            }
            if (!String.IsNullOrEmpty(AnswerVideoPath))
            {
                AnswerVideoPath = Save(AnswerVideoPath, "AnswerVideo", cardId);
            }

            // Check ob Text angegeben wurde

            
            CardViewModel cvm = new CardViewModel(cardId)

            {
                QuestionText = QuestionText,
                QuestionVideo = QuestionVideoPath,
                QuestionImage = QuestionImagePath,
                QuestionAudio = QuestionAudioPath,
                AnswerText = AnswerText,
                AnswerVideo = AnswerVideoPath,
                AnswerImage = AnswerImagePath,
                AnswerAudio = AnswerAudioPath
            };
            
            Topic.Add(cvm);
          
        }

        private void LoadQuestionImageMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.png) | *.jpg; *.png"
            };
            if (dialog.ShowDialog() == true)
            {
                QuestionImage = Image.FromFile(dialog.FileName);
                QuestionImagePath = dialog.FileName;
            }
        }

        private void LoadQuestionVideoMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Video Files (*.mp4; *.mpeg; *.mov; *.mkv; *.m4v) | *.mp4; *.mpeg; *.mov; *.mkv; *.m4v"
            };
            if (dialog.ShowDialog() == true)
            {
                QuestionVideoPath = dialog.FileName; // Video reference
            }
        }

        private void LoadAnswerImageMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.png) | *.jpg; *.png"
            };
            if (dialog.ShowDialog() == true)
            {
                AnswerImage = Image.FromFile(dialog.FileName);
                AnswerImagePath = dialog.FileName;
            }
        }

        private void LoadAnswerVideoMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Video Files (*.mp4; *.mpeg; *.mov; *.mkv; *.m4v) | *.mp4; *.mpeg; *.mov; *.mkv; *.m4v"
            };
            if (dialog.ShowDialog() == true)
            {
                AnswerVideoPath = dialog.FileName; // Video reference
            }
        }

        private void LoadQuestionAudioMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Audio Files (*.mp3; *.wav)| *.mp3; *.wav"
            };
            if (dialog.ShowDialog() == true)
            {
                QuestionAudioPath = dialog.FileName; // Audio reference
            }
        }
        private void LoadAnswerAudioMethod()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Audio Files (*.mp3; *.wav)| *.mp3; *.wav"
            };
            if (dialog.ShowDialog() == true)
            {
                AnswerAudioPath = dialog.FileName; // Audio reference
            }
        }

        public String Save(string source, string folderName, long id)
        {
            return ResourceSerializer.SaveFile(source, $"\\{Topic.ID}\\{id}\\{folderName}\\{Path.GetExtension(source)}");

        }
    }
}
