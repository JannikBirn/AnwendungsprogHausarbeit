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
        public RelayCommand OpenTopicCollectionWindow { get; }
        

        public MainWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            SerializeToBin = new RelayCommand(() => SerializeToBinMethod());
            DeserializeFromBin = new RelayCommand(() => DeserializeFromBinMethod());
            OpenCardOverView = new RelayCommand(() => OpenCardOverViewMethod()); //opens new Window for Card Overview
            OpenStatisticsWindow = new RelayCommand(() => OpenStatisticsWindowMethod());
            OpenLearningCardWindow = new RelayCommand(() => OpenLearningCardWindowMethod());
            OpenTopicCollectionWindow = new RelayCommand(() => OpenTopicCollectionWindowMethod());


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

        //Methods for the Relay Commands to open windows

        private void OpenCardOverViewMethod()
        {
            ServiceBus.Instance.Send(new OpenNewCardOverViewMessage());
        }

        private void OpenStatisticsWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenStatisticsWindowMessage());
        }

        private void OpenLearningCardWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenLearningCardWindowMessage());
        }
        private void OpenTopicCollectionWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenTopicCollectionWindowMessage());
        }
    }
}
