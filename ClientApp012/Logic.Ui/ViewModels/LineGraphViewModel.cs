using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels.LineGraph.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LineGraphViewModel : INotifyPropertyChanged
    {
        //Axis
        private string verticalUnit;
        public string VerticalUnit
        {
            get { return verticalUnit; }
            set
            {
                verticalUnit = value;
                OnPropertyChanged("VerticalUnit");

            }

        }
        private ObservableCollection<string> verticallNumbers;
        public ObservableCollection<string> VerticalNumbers
        {
            get
            {
                return new ObservableCollection<string>(verticallNumbers.Skip(1).Reverse());
            }
            set
            {
                verticallNumbers = value;
                OnPropertyChanged("VerticalNumbers");
            }
        }
        public string VerticalNumberFirst
        {
            get
            {
                return verticallNumbers.First();
            }
        }

        private string horizontalUnit;
        public string HorizontalUnit
        {
            get { return horizontalUnit; }
            set
            {
                horizontalUnit = value;
                OnPropertyChanged("HorizontalUnit");

            }

        }
        private ObservableCollection<string> horizontalNumbers;
        public ObservableCollection<string> HorizontalNumbers
        {
            get { return horizontalNumbers; }
            set
            {
                horizontalNumbers = value;
                OnPropertyChanged("HorizontalNumbers");
            }
        }

        //Shapes - Lines - Paths
        private ObservableCollection<IShape> shapes;
        public ObservableCollection<IShape> Shapes
        {
            get { return shapes; }
            set
            {
                shapes = value;
                OnPropertyChanged("Shapes");
            }
        }

        public ShapePath FirstLine { get; set; }
        public ShapePath SecondLine { get; set; }
        public ShapePath ThirdLine { get; set; }


        public LineGraphViewModel()
        {
            //Axis
            HorizontalNumbers = new ObservableCollection<string>();
            VerticalNumbers = new ObservableCollection<string>();

            //Shapes
            Shapes = new ObservableCollection<IShape>();
            Shapes.Add(new ShapeLine(0.1, 0, 0.1, 1));
        }

        public ShapePath GetPahtUnscaled(List<Point> points, long xMax, long xMin, long yMax, long yMin, string color)
        {
            List<Point> normalizedList = points.Select(
                point => new Point(1.0 * (point.X - xMin) / (xMax - xMin),
                1.0 * (point.Y - yMin) / (yMax - yMin))).ToList();

            return AddPath(normalizedList[0], normalizedList, color);
        }

        public ShapePath AddPath(Point startPoint, List<Point> points, string color)
        {
            ShapePath path = new ShapePath(
                new Point(startPoint.X, 1 - startPoint.Y));
            Point[] sortedPoints = points.Select(
                point => new Point(point.X, 1 - point.Y)).ToArray();
            foreach (Point point in sortedPoints)
            {
                path.AddPoint(point);
            }
            path.Color = color;
            path.SetIsCurved(false);
            return path;            
        }

        //For the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
