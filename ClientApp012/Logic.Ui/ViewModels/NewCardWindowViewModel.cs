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
        public String QuestionText { set; get; }
        public String QuestionVideo { set; get; } //Video reference
        public String QuestionAudio { set; get; } //Audio reference
        public Image QuestionImage = null;
        public String QuestionImagePath { set; get; }
        public String AnswerText { set; get; }
        public String AnswerVideo { set; get; } //Video reference
        public String AnswerAudio { set; get; } //Audio reference
        public Image AnswerImage = null;
        public String AnswerImagePath { set; get; }

        public TopicViewModel Topic { get; set; }
        public RelayCommand AddCard { get; }

        public NewCardWindowViewModel(TopicViewModel model)
        {
            AddCard = new RelayCommand(() => AddCardMethod());
            Topic = model;
        }



        private void AddCardMethod()
        {
            if (QuestionImage != null)
            {
                QuestionImagePath = SaveImage(QuestionImage);
            }
            if (AnswerImage != null)
            {
                AnswerImagePath = SaveImage(AnswerImage);
            }

            CardViewModel cvm = new CardViewModel
            {
                QuestionText = QuestionText,
                QuestionVideo = QuestionVideo,
                QuestionImage = QuestionImagePath,
                QuestionAudio = QuestionAudio,
                AnswerText = AnswerText,
                AnswerVideo = AnswerVideo,
                AnswerImage = AnswerImagePath,
                AnswerAudio = AnswerAudio
            };

            Topic.Add(cvm);
        }

        private void OpenImage()
        {
            Image File;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg|";
            if (f.ShowDialog() == true)
            {
                File = Image.FromFile(f.FileName);
                questionBox.Image = File;
            }
        }

        private String SaveImage(Image image)
        {
            string sourcePath = Directory.GetCurrentDirectory() + "\\Resources\\";
            //        System.IO.File.Copy(image, sourcePath);
            //        string filePath = sourcePath + Path.GetFullPath(image);
            string filePath = "";
            return filePath;
        }
    }
}
