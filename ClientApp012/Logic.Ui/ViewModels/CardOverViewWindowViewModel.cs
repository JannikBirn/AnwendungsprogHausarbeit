using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Services.Printing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class CardOverViewWindowViewModel
    {
        public int TopicIndex { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand PrintTestPage { get; }
        public RelayCommand PrintWindow { get; }


        public CardOverViewWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            TopicIndex = 1;

            PrintTestPage = new RelayCommand(() => PrintTestPageMethod());
            PrintWindow = new RelayCommand(param => PrintWPFWindow(param));
        }

        private void PrintTestPageMethod()
        {
            //hier sollte die PrintMethode aufgerufen werden
            PrintTest printTest = new PrintTest();
            printTest.TestPrintWithDialogue();  //hier wird die Methode aus TestPrint ausgewählt
        }

        private void PrintWPFWindow(object element)
        {
            PrintWPFWindow instance = new PrintWPFWindow();
           // instance.PrintSimpleTextButton_Click((myCardOverviewWindow)element);
        }
    }
}
