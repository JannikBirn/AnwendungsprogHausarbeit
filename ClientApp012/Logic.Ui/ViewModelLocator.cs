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

        public RootViewModel RootViewModel { get; set; }

        public ViewModelLocator()
        {
            RootViewModel = new RootViewModel();

            //TopicViewModel topicVM = new TopicViewModel();         
            //CardViewModel cardVM = topicVM[2];
            //cardVM.Model.QuestionText;

            MyList = new ClientCollectionViewModel();

            MainWindiwVM = new MainWindowViewModel(MyList);
            NewClientWindowVM = new NewClientWindowViewModel(MyList);

        }

        public MainWindowViewModel MainWindiwVM { get; }
        public NewClientWindowViewModel NewClientWindowVM {get;}
    }
}
