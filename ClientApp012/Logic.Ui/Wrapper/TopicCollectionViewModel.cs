using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class TopicCollectionViewModel :
        ViewModelSyncCollection<TopicViewModel, Topic, TopicCollection>
    {
        //private TopicViewModel topicViewModel;

        public int NextTopicId()
        {
            return this.Model.NextTopicId();
        }

        public TopicCollectionViewModel() : base()
        {

            //OnPropertyChanged("TopicCollectionViewModel");
            //OnPropertyChanged("TopicCollection");

            //TopicViewModel = new TopicViewModel();
            //this.Model[0] = TopicViewModel.Model;
        }

        public override void NewModelAssigned()
        {
            //if (this.TopicViewModel != null)
            //{
                //this.TopicViewModel.Model[0] = this.Model?[0];
            //}
        }
    }
}
