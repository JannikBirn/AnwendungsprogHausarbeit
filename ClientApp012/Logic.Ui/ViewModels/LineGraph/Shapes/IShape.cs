using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels.LineGraph.Shapes
{
    public class IShape : INotifyPropertyChanged
    {
        private bool isInvisible;
        public bool IsInvisible
        {
            get => isInvisible;
            set
            {
                isInvisible = value;
                OnPropertyChanged("IsInvisible");
                OnPropertyChanged("Color");
            }
        }
        public string color;

        public string Color
        {
            get
            {
                if (IsInvisible)
                    return "#00000000";
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
        //For the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
