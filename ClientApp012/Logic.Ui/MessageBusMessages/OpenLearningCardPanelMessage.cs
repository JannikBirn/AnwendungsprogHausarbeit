using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages
{
    public class OpenLearningCardPanelMessage
    {
        public const int QUESTION_PANEL = 0, ANSWER_PANEL = 1, FINISH_PANEL = 2, CLOSE_PANEL = 3;
        public int PanelIndex { get; set; }
    }
}
