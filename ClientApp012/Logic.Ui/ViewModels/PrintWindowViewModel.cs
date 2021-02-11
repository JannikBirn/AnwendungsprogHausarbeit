using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Services.Printing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class PrintWindowViewModel
    {
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand CloseWindow { get; }
        public RelayCommand PrintIt { get; set; }

        public bool isLandscape=false;
        public bool Landscape
        {
            get
            {
                return isLandscape;
            }
            set
            {
                isLandscape = value;
                OnPropertyChanged("Landscape");
            }
        }

        public int scaling = 90;
        public int ScalingFactor
        {
            get
            {
                return scaling;
            }
            set
            {
                //if entry is bigger then 120, set it to 90
                if (value > 120 || value < 10)
                {
                    value = 90;
                }
                scaling = value;
                OnPropertyChanged("ScalingFactor");
            }
        }
        public int copies = 1;
        public int NumberOfPages
        {
            get
            {
                return copies;
            }
            set
            {
                //if number of copies is bigger then 20, set it to 1
                if(value >20 || value < 1)
                {
                    value = 1;
                }
                copies = value;
                OnPropertyChanged("NumberOfPages");
            }
        }
        public int fontSize = 14;
        public int FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                //if number of copies is bigger then 20, set it to 1
                if (value > 100 || value < 5)
                {
                    value = 14;
                }
                fontSize = value;
                OnPropertyChanged("FontSize");
            }
        }
        public PrintWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            PrintIt = new RelayCommand(param => PrintItMethod(param));
            CloseWindow = new RelayCommand(param => CloseWindowMethod(param));
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

        private void PrintItMethod(object param)
        {
            PrintAllCards instance = new PrintAllCards();
            instance.Landscape = Landscape;
            instance.ScalingFactor = ScalingFactor;
            instance.NumberOfPages = NumberOfPages;
            instance.fontSize = FontSize;
            instance.PrintCardsDirectly(param);
        }

        private void CloseWindowMethod(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
    }
}
