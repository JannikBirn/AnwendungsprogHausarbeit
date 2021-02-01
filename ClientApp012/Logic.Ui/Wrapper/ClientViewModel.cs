using De.HsFlensburg.ClientApp012.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.Wrapper
{
    public class ClientViewModel
    {
        public Client myClient = new Client();

        public ClientViewModel(Client client)
        {
            this.myClient = client; //das this darf nicht sein
        }

        public ClientViewModel()
        {

        }

        public int Id
        {
            get
            {
                return myClient.Id;
            }
            set
            {
                myClient.Id = value;
            }
        }

        public String Name
        {
            get
            {
                return myClient.Name;
            }
            set
            {
                myClient.Name = value;
            }
        }

    }
}
