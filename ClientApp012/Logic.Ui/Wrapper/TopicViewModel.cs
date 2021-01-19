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
        private CardViewModel cardViewModel;

        public CardViewModel CardViewModel
        {
            get
            {
                return cardViewModel;
            }
            set
            {
                cardViewModel = value;
                OnPropertyChanged("CardViewModel");
            }
        }

        public TopicViewModel() : base()
        {
            CardViewModel = new CardViewModel();

            //this.Model.Name = 
            //this.Model.Img
            //this.Model.TopicStatistics

        }

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }
    }
}
