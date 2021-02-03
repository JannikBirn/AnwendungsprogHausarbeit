using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui
{
    public class ViewModelLocator
    {
        public RootViewModel RootViewModel { get; set; }

        public ViewModelLocator()
        {
            //Initialsing Model ViewModel
            RootViewModel = new RootViewModel();


            // Initialising Window View Models
            MainWindowVM = new MainWindowViewModel(RootViewModel);
            //NewClientWindowVM = new NewClientWindowViewModel(RootVM);
            CardOverViewWindowVM = new CardOverViewWindowViewModel(RootViewModel);
            StatisticsWindowVM = new StatisticsWindowViewModel(RootViewModel);

        }

        public MainWindowViewModel MainWindowVM { get; }
        public NewClientWindowViewModel NewClientWindowVM { get; }
        public CardOverViewWindowViewModel CardOverViewWindowVM { get; }
        public StatisticsWindowViewModel StatisticsWindowVM { get; }
    }
}
