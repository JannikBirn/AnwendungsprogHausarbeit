using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class CardOverViewWindowViewModel
    {
        public RootViewModel RootViewModel { get; set; }
        public int TopicIndex { get; set; }
        //public RelayCommand PrintTestPage { get; }
        //public RelayCommand PrintWindow { get; }

        public CardOverViewWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            TopicIndex = 1;

            //PrintTestPage = new RelayCommand(() => PrintTestPageMethod());
            //PrintWindow = new RelayCommand(param => PrintWPFWindow(param));
        }

        private void PrintTestPageMethod()
        {
            //  Services.Printing.PrintTest();
        }

        private void PrintWPFWindow(object element)
        {
            //PrintWPFWindow instance = new PrintWPFWindow();
            // instance.PrintWindow((Window)element);
        }
    }
}
