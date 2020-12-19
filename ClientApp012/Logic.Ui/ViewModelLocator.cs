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
        public ClientCollectionViewModel MyList { get; set; }

        public ViewModelLocator()
        {
            MyList = new ClientCollectionViewModel();

            MainWindiwVM = new MainWindowViewModel(MyList);
            NewClientWindowVM = new NewClientWindowViewModel(MyList);

        }

        public MainWindowViewModel MainWindiwVM { get; }
        public NewClientWindowViewModel NewClientWindowVM {get;}
    }
}
