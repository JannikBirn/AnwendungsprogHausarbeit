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

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class CardOverViewWindowViewModel
    {
        public int TopicIndex { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand PrintTestPage { get; }
        public RelayCommand PrintWindow { get; }
        public RelayCommand PrintCards { get; }

        public CardOverViewWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            TopicIndex = 1;

            PrintTestPage = new RelayCommand(() => PrintTestPageMethod());
            PrintWindow = new RelayCommand(param => PrintWPFWindowMethod(param));
            PrintCards = new RelayCommand(param => PrintCardsMethod(param));
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

        private void PrintCardsMethod(object param)
        {
            PrintAllCards instance = new PrintAllCards();
            instance.PrintCards(param);
        }

    }
}
