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
        //public TopicCollectionViewModel TopicCollectionVM { get; set; }

        public ViewModelLocator()
        {
            RootViewModel = new RootViewModel();
            //TopicCollectionVM = RootViewModel.TopicCollection;

            //Adding a test vm
            TopicViewModel test = new TopicViewModel();
            test.Name = "Deutsch";
            RootViewModel.TopicCollection.Add(test);

            RootViewModel.TopicCollection[0].Add(new CardViewModel());


            //TopicCollectionVM = new TopicCollectionViewModel();

            //TopicViewModel topicVM = new TopicViewModel();         
            //CardViewModel cardVM = topicVM[2];
            //cardVM.Model.QuestionText;


            MainWindowVM = new MainWindowViewModel(RootViewModel);
            //NewClientWindowVM = new NewClientWindowViewModel(RootVM);
            CardOverViewWindowVM = new CardOverViewWindowViewModel(RootViewModel);
        }

        public MainWindowViewModel MainWindowVM { get; }
        public NewClientWindowViewModel NewClientWindowVM { get; }
        public CardOverViewWindowViewModel CardOverViewWindowVM { get; }
    }
}
