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
        public TopicCollectionViewModel(): base()
        {

        }

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }
    }
}
