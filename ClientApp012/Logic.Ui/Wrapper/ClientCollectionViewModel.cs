using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{    
    public class ClientCollectionViewModel : ObservableCollection<ClientViewModel>
    {
        public ClientCollection myClients;
        private bool syncDisabled = false;


        public ClientCollectionViewModel()
        {
            //eigene Model-Collection instantiieren
            myClients = new ClientCollection();

            this.CollectionChanged += ViewModelCollectionChanged;
            myClients.CollectionChanged += ModelCollectionChanged;

            //Alle Listenelemente des Models holen und Wrappen
            //foreach (client client in myclients)
            //{
            //    this.add(new clientviewmodel(client));
            //}
        }

        private void ViewModelCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var client in e.NewItems.OfType<ClientViewModel>().Select(v => v.myClient).OfType<Client>())
                        myClients.Add(client);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var client in e.OldItems.OfType<ClientViewModel>().Select(v => v.myClient).OfType<Client>())
                        myClients.Remove(client);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    myClients.Clear();
                    break;
            }
            syncDisabled = false;
        }
        private void ModelCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            if (syncDisabled) return;
            syncDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var client in e.NewItems.OfType<Client>())
                        Add(new ClientViewModel(client));
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var client in e.OldItems.OfType<Client>())
                        Remove(GetViewModelOfModel(client));
                    break;
                case NotifyCollectionChangedAction.Reset:
                    this.Clear();
                    break;
            }
            syncDisabled = false;
        }

        private ClientViewModel GetViewModelOfModel(Client client)
        {
            foreach(ClientViewModel cvm in this)
            {
                if (cvm.myClient.Equals(client)) return cvm;
            }
            return null;
        }
    }
}
