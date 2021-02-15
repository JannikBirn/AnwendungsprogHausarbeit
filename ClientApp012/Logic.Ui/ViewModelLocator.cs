using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;


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
            LineGraphVM = new LineGraphViewModel();
            StatisticsWindowVM = new StatisticsWindowViewModel(RootViewModel, LineGraphVM);
            StatisticsTopicSelectionWindowVM = new StatisticsTopicSelectionWindowViewModel(RootViewModel, StatisticsWindowVM);
            LearningCardWindowVM = new LearningCardWindowViewModel(MainWindowVM);
            PrintWindowVM = new PrintWindowViewModel(RootViewModel);
            NewCardWindowVM = new NewCardWindowViewModel(MainWindowVM);
            NewTopicWindowVM = new NewTopicWindowViewModel(RootViewModel);

        }

        public MainWindowViewModel MainWindowVM { get; }
        public CardOverViewWindowViewModel CardOverViewWindowVM { get; }
        public StatisticsWindowViewModel StatisticsWindowVM { get; }
        public StatisticsTopicSelectionWindowViewModel StatisticsTopicSelectionWindowVM { get; }
        public LineGraphViewModel LineGraphVM { get; }
        public LearningCardWindowViewModel LearningCardWindowVM { get; }
        public PrintWindowViewModel PrintWindowVM { get; }
        public NewCardWindowViewModel NewCardWindowVM { get; }
        public NewTopicWindowViewModel NewTopicWindowVM { get; }
    }
}
