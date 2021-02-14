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

        private Visibility topicCanvas = Visibility.Hidden;
        public Visibility TopicCanvas
        {
            get { return topicCanvas; }
            set
            {
                topicCanvas = value;
                OnPropertyChanged("TopicCanvas");
            }
        }

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
        public RelayCommand DeleteTopicImage { get; }



        public NewTopicWindowViewModel(RootViewModel model)
        {
            AddTopic = new RelayCommand(param => AddTopicMethod(param));
            LoadTopicImage = new RelayCommand(() => LoadTopicImageMethod());
            DeleteTopicImage = new RelayCommand(() => DeleteTopicImageMethod());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            TopicCollection = model.TopicCollection;
        }

        private void AddTopicMethod(object param)
        {

            if (!String.IsNullOrEmpty(Name))

            {
                string localpath = "";
                long topicId = DateTime.Now.Ticks;
                if (TopicImage != null)
                {
                    localpath = Save(TopicImagePath, "TopicImage", topicId);
                }

                // Check ob Text angegeben wurde

                TopicViewModel tvm = new TopicViewModel(topicId)
                {
                    Name = Name,
                    Img = localpath
                };

                TopicCollection.Add(tvm);

                topicImagePath = null;
                Name = null;

                CloseWindowMethod(param);
            }
        }

        private void LoadTopicImageMethod()
        {
            
            TopicImagePath = ResourceSerializer.LoadImagePath();
            TopicCanvas = Visibility.Visible;
        }
        private void DeleteTopicImageMethod()
        {
            TopicImagePath = null;
            topicImagePath = null;
            TopicCanvas = Visibility.Hidden;
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
