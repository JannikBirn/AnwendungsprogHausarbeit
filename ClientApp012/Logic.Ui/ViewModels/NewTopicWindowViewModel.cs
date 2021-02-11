using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.Serialization;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class NewTopicWindowViewModel : INotifyPropertyChanged
    {
        private string topicImagePath;

        public String TopicImagePath
        {
            get => topicImagePath;
            set
            {
                topicImagePath = value;
                OnPropertyChanged("TopicImagePath");
                OnPropertyChanged("TopicImage");
            }
        }

        public BitmapImage TopicImage
        {
            get
            {
                if (TopicImagePath == null)
                    return null;
                return new BitmapImage(new Uri(TopicImagePath));
            }
        }

        public TopicCollectionViewModel TopicCollection;
        public String Name { get; set; }
        public TopicCollectionViewModel TCVM { get; set; }
        public RelayCommand AddTopic { get; }
        public RelayCommand CloseWindow { get; }
        public RelayCommand LoadTopicImage { get; }


        public NewTopicWindowViewModel(RootViewModel model)
        {
            AddTopic = new RelayCommand(() => AddTopicMethod());
            LoadTopicImage = new RelayCommand(() => LoadTopicImageMethod());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            TopicCollection = model.TopicCollection;
        }

        private void AddTopicMethod()
        {
            if (!String.IsNullOrEmpty(Name) || Name != "Insert a title for the topic!")
            {
                string localpath = "";
                long topicId = DateTime.Now.Ticks;
                if (TopicImage != null)
                {
                    localpath = Save(TopicImagePath, "TopicImage", topicId);
                }

                // Check ob Text angegeben wurde

                TopicViewModel tvm = new TopicViewModel(topicId);
                tvm.Name = Name;
                tvm.Img = localpath;

                TopicCollection.Add(tvm);
            }
        }

        private void LoadTopicImageMethod()
        {
            TopicImagePath = ResourceSerializer.LoadImagePath();
        }


        public String Save(string source, string folderName, long id)
        {
            return ResourceSerializer.SaveFile(source, $"{id}\\TopicImage{Path.GetExtension(source)}");
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
