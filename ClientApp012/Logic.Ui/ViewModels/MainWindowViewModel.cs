using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
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
        public ClientCollectionViewModel MyList { get; set; }
        public TopicCollectionViewModel TopicCollectionObject { get; set; }
        public RelayCommand OpenNewClientWindow { get; }

        public MainWindowViewModel(ClientCollectionViewModel model)
        {
            OpenNewClientWindow = new RelayCommand(() => OpenNewClientWindowMethod());
            MyList = model;
        }

        private void OpenNewClientWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        }

        private void AddClientToListMethod()
        {
            ClientViewModel clientVM = new ClientViewModel();
            //clientVM.Id = Int16.Parse(IdTextBox.Text);
            //clientVM.Name = NameTextBox.Text;
            MyList.Add(clientVM);            
        }

        private void SerializeToBinMethod()
        {
            //BinarySerializerFileHandler.Save(TopicCollectionObject.Model);
        }

        private void DeserializeFromBinMethod()
        {
            TopicCollectionObject = new TopicCollectionViewModel();
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
