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
    public class CardOverViewWindowViewModel : List<TopicViewModel>
    {

        private TopicViewModel topic;
        //public RelayCommand PrintTestPage { get; }
        //public RelayCommand PrintWindow { get; }

        public TopicViewModel Topic
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
                //OnPropertyChanged("Topic");
            }
        }


        public CardOverViewWindowViewModel()
        {
            Topic = new TopicViewModel();
           // this.Model.Topic = Topic.Model;

            //myCardList = new Topic();

            //foreach (Card card in myCardList)
            //{
            //    this.Add(new TopcViewModel(card);
            //}


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
