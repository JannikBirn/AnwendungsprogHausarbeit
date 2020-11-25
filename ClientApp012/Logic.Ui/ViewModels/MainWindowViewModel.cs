using De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        public ClientCollectionViewModel MyList { get; set; }
        public RelayCommand AddClientToList { get; }

        public MainWindowViewModel()
        {
            AddClientToList = new RelayCommand(() => AddClientToListMethod());
            MyList = new ClientCollectionViewModel();
        }

        private void AddClientToListMethod()
        {
            ClientViewModel clientVM = new ClientViewModel();
            //clientVM.Id = Int16.Parse(IdTextBox.Text);
            //clientVM.Name = NameTextBox.Text;
            MyList.Add(clientVM);
            
        }



        //private void DelCientInList(object sender, RoutedEventArgs e)
        //{
        //    ClientCollectionViewModel list = this.FindResource("myList") as ClientCollectionViewModel;
        //    if (list != null)
        //    {
        //        list.RemoveAt(0);
        //    }
        //}



        //private void DelCollection(object sender, RoutedEventArgs e)
        //{
        //    ClientCollectionViewModel list = this.FindResource("myList") as ClientCollectionViewModel;
        //    if (list != null)
        //    {
        //        list.Clear();
        //    }
        //}
    }
}
