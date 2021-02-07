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

        public LineGraphViewModel()
        {

            //Axis
            HorizontalNumbers = new ObservableCollection<string>();

            //for (int i = 0; i < 5; i++)
            //{
            //    HorizontalNumbers.Add("" + i);
            //}

            VerticalNumbers = new ObservableCollection<string>();

            //for (int i = 10; i < 15; i++)
            //{
            //    VerticalNumbers.Add("" + i);
            //}

            //Shapes
            Shapes = new ObservableCollection<IShape>();
            Shapes.Add(new ShapeLine(0.1, 0, 0.1, 1));


            //var shape = new ShapePath(new Point(0, 1));
            //shape.AddPoint(new Point(0.1, 0.9));
            //shape.AddPoint(new Point(0.2, 0.3));
            //shape.AddPoint(new Point(0.5, 0.5));
            //Shapes.Add(shape);

        }

        public void AddPahtUnscaled(List<Point> points, double xMax, double xMin, double yMax, double yMin, string color)
        {
            List<Point> normalizedList = points.Select(point => new Point(1.0 * (point.X - xMin) / (xMax - xMin), 1.0 * (point.Y - yMin) / (yMax - yMin))).ToList();

            AddPath(normalizedList[0], normalizedList, color);
        }

        public void AddPath(Point startPoint, List<Point> points, string color)
        {
            ShapePath path = new ShapePath(new Point(startPoint.X, 1 - startPoint.Y));
            Point[] sortedPoints = points.Select(point => new Point(point.X, 1 - point.Y)).ToArray();
            foreach (Point point in sortedPoints)
            {
                path.AddPoint(point);
            }
            path.Color = color;
            path.SetIsCurved(false);
            Shapes.Add(path);
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
