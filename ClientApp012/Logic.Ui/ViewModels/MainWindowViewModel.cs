using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using De.HsFlensburg.ClientApp012.Services.Printing;
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

        //public TopicCollectionViewModel TopicCollectionVM { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand OpenNewClientWindow { get; }
        public RelayCommand SerializeToBin { get; }
        public RelayCommand DeserializeFromBin { get; }
        public RelayCommand PrintTestPage { get; }
        public RelayCommand PrintWindow { get; }


        public MainWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            OpenNewClientWindow = new RelayCommand(() => OpenNewClientWindowMethod());
            SerializeToBin = new RelayCommand(() => SerializeToBinMethod());
            DeserializeFromBin = new RelayCommand(() => DeserializeFromBinMethod());

            PrintTestPage = new RelayCommand(() => PrintTestPageMethod());
            PrintWindow = new RelayCommand(param => PrintWPFWindow(param));

        }

        private void PrintTestPageMethod()
        {
            Services.Printing.PrintTest();
        }

        private void PrintWPFWindow(object element)
        {
            PrintWPFWindow instance = new PrintWPFWindow();
            instance.PrintWindow((Window)element);
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
            throw new NotImplementedException();
            //BinarySerializerFileHandler.Save(TopicCollectionObject.Model);
        }

        private void DeserializeFromBinMethod()
        {
            throw new NotImplementedException();
            //TopicCollectionObject = new TopicCollectionViewModel();
            //TopicCollectionObject.Model = BinarySerializerFileHandler.Load();
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
