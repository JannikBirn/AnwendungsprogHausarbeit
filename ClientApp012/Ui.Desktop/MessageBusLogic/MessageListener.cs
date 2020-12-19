using De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp012.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;

        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            // Reaction to a message
            ServiceBus.Instance.Register<OpenNewClientWindowMessage>(this, delegate ()
            {
                NewClientWindow myWindow = new NewClientWindow();
                myWindow.ShowDialog();
            });
        }
    }
}
