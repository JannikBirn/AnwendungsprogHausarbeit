using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Microsoft.Win32;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    class NewCardWindowViewModel
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


        public NewCardWindowViewModel(TopicViewModel model)
        {
            AddCard = new RelayCommand(() => AddCardMethod());
            LoadQuestionImage = new RelayCommand(() => LoadQuestionImageMethod());
            LoadAnswerImage = new RelayCommand(() => LoadAnswerImageMethod());
            LoadQuestionVideo = new RelayCommand(() => LoadQuestionVideoMethod());
            LoadAnswerVideo = new RelayCommand(() => LoadAnswerVideoMethod());
            LoadQuestionAudio = new RelayCommand(() => LoadQuestionAudioMethod());
            LoadAnswerAudio = new RelayCommand(() => LoadAnswerAudioMethod());
            Topic = model;
        }

        private void AddCardMethod()
        {
            if (QuestionImage != null)
            {
                QuestionImagePath = SaveImage(QuestionImage, QuestionImagePath);
            }
            if (AnswerImage != null)
            {
                AnswerImagePath = SaveImage(AnswerImage, AnswerImagePath);
            }
            if (!String.IsNullOrEmpty(QuestionAudioPath))
            {
                QuestionAudioPath = SaveAudio(QuestionAudioPath);
            }
            if (!String.IsNullOrEmpty(AnswerAudioPath))
            {
                AnswerAudioPath = SaveAudio(AnswerAudioPath);
            }
            if (!String.IsNullOrEmpty(QuestionVideoPath))
            {
                QuestionVideoPath = SaveVideo(QuestionVideoPath);
            }
            if (!String.IsNullOrEmpty(AnswerVideoPath))
            {
                AnswerVideoPath = SaveVideo(AnswerVideoPath);
            }

            CardViewModel cvm = new CardViewModel
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
                Filter = "Image files (*.jpg, *.png)|*.jpg; *.png)"
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
                Filter = "Video files (*.mp4)|*.mp4)"
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
                Filter = "Image files (*.jpg, *.png)|*.jpg; *.png)"
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
                Filter = "Video files (*.mp4)|*.mp4)"
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
                Filter = "Audio files (*.mp3, *.wav)|*.mp3, *.wav)"
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
                Filter = "Audio files (*.mp3, *.wav)|*.mp3, *.wav)"
            };
            if (dialog.ShowDialog() == true)
            {
                AnswerAudioPath = dialog.FileName; // Audio reference
            }
        }
        private String SaveImage(Image image, string sourcePath)
        {
            string assetPath = $@"{Directory.GetCurrentDirectory()}\Assets\ImageFiles";
            if (!Directory.Exists(assetPath))
            {
                Directory.CreateDirectory(assetPath);
            }
            string destPath = $@"{assetPath}\{Path.GetFileName(sourcePath)}";
            image.Save(destPath);
            return destPath;
        }
        private String SaveAudio(string sourcePath)
        {
            string assetPath = $@"{Directory.GetCurrentDirectory()}\Assets\AudioFiles";
            if (!Directory.Exists(assetPath))
            {
                Directory.CreateDirectory(assetPath);
            }
            string destPath = $@"{assetPath}\{Path.GetFileName(sourcePath)}";
            File.Copy(sourcePath, assetPath);
            return destPath;
        }
        private String SaveVideo(string sourcePath)
        {
            string assetPath = $@"{Directory.GetCurrentDirectory()}\Assets\VideoFiles";
            if (!Directory.Exists(assetPath))
            {
                Directory.CreateDirectory(assetPath);
            }
            string destPath = $@"{assetPath}\{Path.GetFileName(sourcePath)}";
            File.Copy(sourcePath, assetPath);
            return destPath;
        }
    }
}
