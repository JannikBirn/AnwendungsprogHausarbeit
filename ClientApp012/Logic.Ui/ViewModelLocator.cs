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
        public TopicCollectionViewModel TopicCollectionVM { get; set; }


        public ViewModelLocator()
        {
            RootViewModel = new RootViewModel();
            TopicCollectionVM = RootViewModel.TopicCollection;
            //TopicCollectionVM = new TopicCollectionViewModel();

            //TopicViewModel topicVM = new TopicViewModel();         
            //CardViewModel cardVM = topicVM[2];
            //cardVM.Model.QuestionText;


            MainWindiwVM = new MainWindowViewModel(RootViewModel);
            //NewClientWindowVM = new NewClientWindowViewModel(RootVM);

        }

        public MainWindowViewModel MainWindiwVM { get; }
        public NewClientWindowViewModel NewClientWindowVM {get;}
    }
}
