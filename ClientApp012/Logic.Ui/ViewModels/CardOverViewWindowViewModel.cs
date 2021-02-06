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
        public RelayCommand PrintTestPage { get; }
        public RelayCommand PrintWindow { get; }
        public RelayCommand PrintAllCards { get; }
        public RelayCommand CloseWindow { get; }
        public bool DirectPrinting { get; } //geht noch nicht
        public CardOverViewWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            PrintTestPage = new RelayCommand(() => PrintTestPageMethod());
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

        private void PrintTestPageMethod()
        {
            //hier sollte die PrintMethode aufgerufen werden
            PrintTest instance = new PrintTest();
            instance.TestPrintWithDialogue();  //hier wird die Methode aus TestPrint ausgewählt
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
