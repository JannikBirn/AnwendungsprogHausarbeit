using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages
{
    public class SendAnswerMessage
    {
        public const bool ANSWER_TRUE = true;
        public const bool ANSWER_FALSE = false;
        public bool Answer { get; set; }
    }
}
