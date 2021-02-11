using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using De.HsFlensburg.ClientApp012.Services.Printing;
using Services.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
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
        public RelayCommand CloseWindow { get; }
        public TopicViewModel CurrentTopic { get; set; }
        public MainWindowViewModel(RootViewModel model)
        {
            //Referenzing to the model
            RootViewModel = model;

            
            //Auto load cards on startup
                DeserializeFromBinMethod();

            //Adding relay commands
            SerializeToBin = new RelayCommand(() => SerializeToBinMethod());
            DeserializeFromBin = new RelayCommand(() => DeserializeFromBinMethod());
            OpenCardOverView = new RelayCommand(() => OpenCardOverViewMethod()); //opens new Window for Card Overview
            OpenStatisticsWindow = new RelayCommand(() => OpenStatisticsWindowMethod());
            OpenLearningCardWindow = new RelayCommand(() => OpenLaerningCardWindowMethod());
            OpenNewCardWindow = new RelayCommand(() => OpenNewCardWindowMethod());
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            OpenNewTopicWindow = new RelayCommand(() => OpenNewTopicWindowMethod());
            SelectedTopicCommand = new RelayCommand((param) => SelectedTopicCommandMethod(param));
        }

        private void SelectedTopicCommandMethod(object param)
        {
            CurrentTopic = (TopicViewModel) param;
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

            RootViewModel.Model = (Root) BinarySerializer.BinaryDeserialize(fullPath);

        }
        //Close current window
        private void CloseWindowMethod(object param)
        {
            Window window = (Window)param;
            window.Close();
        }

        //Methods for the Relay Commands to open windows

        private void OpenNewTopicWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewTopicWindowMessage());
        }

        private void OpenNewCardWindowMethod()
        {
            if (CurrentTopic != null) { 
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
    }
}
