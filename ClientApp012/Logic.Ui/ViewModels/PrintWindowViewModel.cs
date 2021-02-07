using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Services.Printing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Documents;
using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Services.MessageBusWithParameter;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class PrintWindowViewModel
    {
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand PrintIt { get; set; }
        public RelayCommand PrintWindowPreviewRC { get; set; }
        public RelayCommand CloseWindow { get; }

        public bool isChecked = false;
        public bool Landscape
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("Landscape");
            }
        }

        public int scaleInteger = 90;
        public int ScalingFactor
        {
            get { return scaleInteger; }
            set
            {
                scaleInteger = value;
                OnPropertyChanged("ScalingFactor");
            }
        }

        public int pageInteger = 1;
        public int NumberOfPages {
            get { return pageInteger; }
            set
            {
                pageInteger = value;
                OnPropertyChanged("NumberOfPages");
            }
        }

        public PrintWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            PrintIt = new RelayCommand(param => PrintItMethod(param));
            PrintWindowPreviewRC = new RelayCommand(param => PrintWindowPreviewMethod(param));
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


        private void PrintWindowPreviewMethod(object param)
        {
            PrintAllCards instance = new PrintAllCards();
            FixedDocumentSequence preview = instance.PrintWindowPreview((DataGrid)param);
            SetPrintPreviewMessage message = new SetPrintPreviewMessage();
            message.FixedDocumentSequence = preview;
            Messenger.Instance.Send<SetPrintPreviewMessage>(message);

        }

        private void PrintItMethod(object param)
        {
            PrintAllCards instance = new PrintAllCards();
            instance.Landscape = this.Landscape;
            instance.ScalingFactor = ScalingFactor;
            instance.NumberOfPages = NumberOfPages;
            instance.PrintCardsDirectly(param);
        }

        private void CloseWindowMethod(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
    }
}
