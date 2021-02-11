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
        public TopicViewModel() : base() 
        {

        }

        public TopicViewModel(long id) : base()
        {
            this.Model.Id = id; 
        }

        public long ID
        {
            get
            {
                return this.Model.Id;
            }
        }

        public String Name
        {
            get
            {
                return this.Model.Name;
            }
            set
            {
                this.Model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public String Img
        {
            get
            {
                return this.Model.Img;
            }
            set
            {
                this.Model.Img = value;
                OnPropertyChanged("Img");
            }
        }

        public List<Card> StartQuestioning()
        {
            return this.Model.StartQuestioning();
        }

        public void FinishQuestioning()
        {
            this.Model.FinishQuestioning();
        }



        //public TopicStatistics TopicStatistics
        //{
        //    get
        //    {
        //        return this.Model.TopicStatistics;
        //    }
        //    set
        //    {
        //        this.Model.TopicStatistics = value;
        //        OnPropertyChanged("TopicStatistics");
        //    }
        //}



        public override void NewModelAssigned()
        {
            //throw new NotImplementedException();
        }
    }
}
