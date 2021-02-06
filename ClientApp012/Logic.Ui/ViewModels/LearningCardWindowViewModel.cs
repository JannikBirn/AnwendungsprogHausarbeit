using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LearningCardWindowViewModel
    {
        public RootViewModel RootViewModel { get; set; }

        public CardViewModel QuestionText { get;}

        //Open Panel Commands
        public RelayCommand OpenLearningCardQuestionPanel { get; }
        public RelayCommand OpenLearningCardAnswerPanel { get; }
        public RelayCommand OpenLearningCardFinishPanel { get; }


        public LearningCardWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;

            OpenLearningCardQuestionPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.QUESTION_PANEL));
            OpenLearningCardAnswerPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.ANSWER_PANEL));
            OpenLearningCardFinishPanel = new RelayCommand(() => OpenLearningCardPanelMethod(OpenLearningCardPanelMessage.FINISH_PANEL));

            //  QuestionText = RootViewModel.TopicCollection[0][0];
        }

        private void OpenLearningCardPanelMethod(int panelIndex)
        {
            OpenLearningCardPanelMessage messageObject = new OpenLearningCardPanelMessage();
            messageObject.PanelIndex = panelIndex;


            Messenger.Instance.Send<OpenLearningCardPanelMessage>(messageObject);
        }
    }
}
