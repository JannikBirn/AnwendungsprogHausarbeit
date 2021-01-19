using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class TopicCollectionViewModel : ViewModelSyncCollection<TopicViewModel, Topic, TopicCollection>
    {
        private TopicViewModel topicViewModel;

        public TopicViewModel TopicViewModel
        {
            get
            {
                return topicViewModel;
            }
            set
            {
                topicViewModel = value;
                OnPropertyChanged("TopicViewModel");
            }
        }

        public TopicCollectionViewModel(): base()
        {
            TopicViewModel = new TopicViewModel();
            //this.Model.TopicViewModel = TopicCollection.Model;
        }

        public override void NewModelAssigned()
        {
            if (this.TopicViewModel != null)
            {
                //this.TopicViewModel.Model = this.Model?.TopicViewModel;
            }
        }
    }
}
