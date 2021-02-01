using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper.AbstractViewModels
{
    public abstract class ViewModelBase<TypeOfModel> : INotifyPropertyChanged,
         IViewModel<TypeOfModel> where TypeOfModel : new()
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //entspricht private myModel
        private TypeOfModel model;
        public TypeOfModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                try
                {
                    this.NewModelAssigned();
                }
                catch (Exception e)
                {

                }

            }
        }
        public ViewModelBase(TypeOfModel modelObject)
        {
            this.Model = modelObject;
        }
        public ViewModelBase()
        {
            this.Model = new TypeOfModel();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public abstract void NewModelAssigned();

    }
}
