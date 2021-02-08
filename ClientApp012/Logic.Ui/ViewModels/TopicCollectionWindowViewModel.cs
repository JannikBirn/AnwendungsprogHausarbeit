using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class TopicCollectionWindowViewModel
    {
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand OpenStatisticWindow { get; }
        public TopicCollectionWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            OpenStatisticWindow = new RelayCommand(() => OpenStatisticWindowMethod());
        }

        private void OpenStatisticWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenStatisticsWindowMessage());
        }
    }

}
