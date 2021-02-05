using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels.LineGraph.Shapes
{
    public class ShapePath : IShape
    {
        public PointCollection Points { get; set; }

        public Point StartPoint { get { return Points[0]; } set { StartPoint = value; } }

        public ShapePath(PointCollection points)
        {
            Points = points;
        }
    }
}
