using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp012.Services.Printing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class PrintWindowViewModel
    {
        public RootViewModel RootViewModel { get; set; }
        public RelayCommand PrintIt { get; set; }
        public bool Landscape { get; set; }
        public int ScalingFactor { get; set; }
        public int NumberOfPages { get; set; }

        public PrintWindowViewModel(RootViewModel model)
        {
            RootViewModel = model;
            PrintIt = new RelayCommand(param => PrintItMethod(param));
        }

        private void PrintItMethod(object param)
        {
            PrintAllCards instance = new PrintAllCards();
            instance.Landscape = Landscape;
            instance.ScalingFactor = ScalingFactor;
            instance.NumberOfPages = NumberOfPages;
            instance.PrintCardsDirectly(param);
        }
    }
}
