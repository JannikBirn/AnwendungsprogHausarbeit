using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using De.HsFlensburg.ClientApp012.Services.Serialization;
using Services.Serialization;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public const string FILE_NAME = "appdata.dat";

        //public TopicCollectionViewModel TopicCollectionVM { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand SerializeToBin { get; }
        public RelayCommand DeserializeFromBin { get; }
        public RelayCommand OpenCardOverView { get; }
        public RelayCommand OpenStatisticsWindow { get; }
        public RelayCommand OpenLearningCardWindow { get; }
        public RelayCommand OpenNewCardWindow { get; }
        public RelayCommand OpenNewTopicWindow { get; }
        public RelayCommand SelectedTopicCommand { get; }
        public RelayCommand DeleteTopic { get; set; }

        public BitmapImage TopicImage
        {
            get
            {
                if (CurrentTopic == null)
                {
                    return null;
                }
                if (CurrentTopic.Img == null)

                    return null;

                //creates a copy of the original so it's possible to delete
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = new Uri(BinarySerializer.GetAbsolutePath(CurrentTopic.Img));
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private TopicViewModel currentTopic;
        public TopicViewModel CurrentTopic
        {
            get => currentTopic;
            set
            {
                currentTopic = value;
                OnPropertyChanged("CurrentTopic");
                OnPropertyChanged("TopicImage");
            }
        }

        public MainWindowViewModel(RootViewModel model)
        {
            //Referenzing to the model
            RootViewModel = model;


            //Auto load cards on startup
            DeserializeFromBinMethod();


            //Adding relay commands
            SerializeToBin = new RelayCommand(() => SerializeToBinMethod());
            DeserializeFromBin = new RelayCommand(() => DeserializeFromBinMethod());
            OpenCardOverView = new RelayCommand(() => OpenCardOverViewMethod()); 
            OpenStatisticsWindow = new RelayCommand(() => OpenStatisticsWindowMethod());
            OpenLearningCardWindow = new RelayCommand(() => OpenLaerningCardWindowMethod());
            OpenNewCardWindow = new RelayCommand(() => OpenNewCardWindowMethod());
            OpenNewTopicWindow = new RelayCommand(() => OpenNewTopicWindowMethod());
            SelectedTopicCommand = new RelayCommand((param) => SelectedTopicCommandMethod(param));
            DeleteTopic = new RelayCommand(param => DeleteTopicMethod(param));
        }

        //deletes folder of topic
        private void DeleteTopicMethod(object param)
        {
            TopicViewModel topicToDelete = CurrentTopic;
            CurrentTopic = null;

            ResourceSerializer.DeleteDirectory($"{topicToDelete.ID}");
            RootViewModel.TopicCollection.Remove(topicToDelete);
            SerializeToBinMethod();

        }

        private void SelectedTopicCommandMethod(object param)
        {
            CurrentTopic = (TopicViewModel)param;
        }


        //Serialization

        private void SerializeToBinMethod()
        {
            string fullPath = BinarySerializer.PERSISTENT_DATA_PATH + FILE_NAME;
            Console.WriteLine("Writing Data to path:" + fullPath);

            BinarySerializer.BinarySerialize(RootViewModel.Model, fullPath);
        }

        private void DeserializeFromBinMethod()
        {
            string fullPath = BinarySerializer.PERSISTENT_DATA_PATH + FILE_NAME;
            Console.WriteLine("Reading Data from path:" + fullPath);

            object root = BinarySerializer.BinaryDeserialize(fullPath);
            if (root != null)
                RootViewModel.Model = (Root)root;
        }
        //Methods for the Relay Commands to open windows

        private void OpenNewTopicWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewTopicWindowMessage());
        }

        private void OpenNewCardWindowMethod()
        {
            if (CurrentTopic != null)
            {
                ServiceBus.Instance.Send(new OpenNewCardWindowMessage());
            }
        }

        private void OpenCardOverViewMethod()
        {
            ServiceBus.Instance.Send(new OpenNewCardOverViewMessage());
        }

        private void OpenStatisticsWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenStatisticsWindowMessage());
        }

        private void OpenLaerningCardWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenLearningCardWindowMessage());
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
