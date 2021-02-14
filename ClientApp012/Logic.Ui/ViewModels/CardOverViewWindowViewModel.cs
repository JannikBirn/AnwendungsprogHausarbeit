using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Services.Printing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class CardOverViewWindowViewModel
    {
        public int TopicIndex { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand PrintWindow { get; }
        public RelayCommand PrintAllCards { get; }
        public RelayCommand CloseWindow { get; }
        public CardOverViewWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            PrintWindow = new RelayCommand(param => PrintWPFWindowMethod(param));
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
            PrintAllCards = new RelayCommand((param) => PrintAllCardsMethod(param));
        }

     

        private void PrintAllCardsMethod(object allCards)
        {
            OpenPrintWindowMessage message = new OpenPrintWindowMessage();
            message.Grid = allCards;
            Messenger.Instance.Send(message);
            
        }

        private void PrintWPFWindowMethod(object param)
        {
            PrintWPFWindow instance = new PrintWPFWindow();
            instance.PrintWindow((Window)param);
        }

        private void CloseWindowMethod(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
    }
}
