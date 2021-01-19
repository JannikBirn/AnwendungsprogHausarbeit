using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class RootViewModel : ViewModelBase<Root>
    {
        private TopicCollectionViewModel topicCollection;

        public TopicCollectionViewModel TopicCollection
        {
            get
            {
                return topicCollection;
            }
            set
            {
                topicCollection = value;
                OnPropertyChanged("TopicCollection");
            }
        }

        public RootViewModel() : base()
        {
            TopicCollection = new TopicCollectionViewModel();
            this.Model.TopicCollection = TopicCollection.Model;
        }

        public override void NewModelAssigned()
        {
            if (this.TopicCollection != null)
            {
                this.TopicCollection.Model = this.Model?.TopicCollection;
            }
        }
    }
}
