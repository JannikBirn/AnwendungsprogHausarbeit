using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels.LineGraphShapes
{
    public interface IShape
    {
        //In Percente between 0 and 1
        double X1 { get; set; }
        double Y1 { get; set; }
    }
}
