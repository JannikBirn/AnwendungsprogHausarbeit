using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class TopicViewModel : ViewModelSyncCollection<CardViewModel, Card, Topic> //soll das nicht ne Liste sein?
    {
        public TopicViewModel() : base()
        {
        }

        public int NextCardId()
        {
            return this.Model.NextCardId();
        }


        public int ID
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
