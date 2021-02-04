using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.MessageBusMessages
{
    public class OpenStatisticsPanelMessage
    {
        public const int HISTORY_PANEL = 0, TIME_PANEL = 1, QUALITY_PANEL = 2;
        public int PanelIndex { get; set; }
        public object Frame { get; set; }
    }
}
