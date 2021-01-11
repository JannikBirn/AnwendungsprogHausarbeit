using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class TopicViewModel : ViewModelSyncCollection<CardViewModel, Card, Topic>
    {
        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }
    }
}
