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
        public const string FILE_NAME = "\\ClientApp012\\appdata.dat";

        //public TopicCollectionViewModel TopicCollectionVM { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand OpenNewClientWindow { get; }
        public RelayCommand SerializeToBin { get; }
        public RelayCommand DeserializeFromBin { get; }
        public RelayCommand OpenCardOverView { get; }


        public MainWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            OpenNewClientWindow = new RelayCommand(() => OpenNewClientWindowMethod());
            SerializeToBin = new RelayCommand(() => SerializeToBinMethod());
            DeserializeFromBin = new RelayCommand(() => DeserializeFromBinMethod());
            OpenCardOverView = new RelayCommand(() => OpenCardOverViewMethod());

        }



        private void OpenNewClientWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        }

        private void AddClientToListMethod()
        {
            //ClientViewModel clientVM = new ClientViewModel();
            //clientVM.Id = Int16.Parse(IdTextBox.Text);
            //clientVM.Name = NameTextBox.Text;
            //MyList.Add(clientVM);            
        }

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

        private void OpenCardOverViewMethod()
        {
            ServiceBus.Instance.Send(new OpenNewCardOverViewMessage());
        }

        //private void DelCientInList(object sender, RoutedEventArgs e)
        //{
        //    ClientCollectionViewModel list = this.FindResource("myList") as ClientCollectionViewModel;
        //    if (list != null)
        //    {
        //        list.RemoveAt(0);
        //    }
        //}



        //private void DelCollection(object sender, RoutedEventArgs e)
        //{
        //    ClientCollectionViewModel list = this.FindResource("myList") as ClientCollectionViewModel;
        //    if (list != null)
        //    {
        //        list.Clear();
        //    }
        //}
    }
}
