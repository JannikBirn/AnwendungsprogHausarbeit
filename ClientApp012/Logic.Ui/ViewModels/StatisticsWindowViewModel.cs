using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class StatisticsWindowViewModel
    {

        //public TopicCollectionViewModel TopicCollectionVM { get; set; }
        public RootViewModel RootViewModel { get; set; }
        //public RelayCommand OpenNewClientWindow { get; }


        public StatisticsWindowViewModel(RootViewModel model)
        {
            //Refrenzing to the model
            RootViewModel = model;

            //Adding relay commands
            //OpenNewClientWindow = new RelayCommand(() => OpenNewClientWindowMethod());

        }



        //private void OpenNewClientWindowMethod()
        //{
        //    ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        //}
      
    }
}
