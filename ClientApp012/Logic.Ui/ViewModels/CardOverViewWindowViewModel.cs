using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class CardOverViewWindowViewModel : List<CardViewModel>
    {

        private Topic myCardList;
        public RelayCommand PrintTestPage { get; }
        public RelayCommand PrintWindow { get; }

        public CardOverViewWindowViewModel()
        {
            myCardList = new Topic();

            foreach (Card card in myCardList)
            {
                this.Add(new CardViewModel(card);
            }


            PrintTestPage = new RelayCommand(() => PrintTestPageMethod());
            PrintWindow = new RelayCommand(param => PrintWPFWindow(param));

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
