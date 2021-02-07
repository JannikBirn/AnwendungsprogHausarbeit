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
        //Path for the Path
        public PointCollection Path { get; set; }

        //Points that will generate the Path
        private PointCollection Points { get; set; }

        private Point startPoint;
        public Point StartPoint
        {
            get { return startPoint; }
            set
            {
                startPoint = value;
                OnPropertyChanged("StartPoint");
            }
        }

        private bool isCurved = false;

        public ShapePath(Point startPoint)
        {
            StartPoint = startPoint;
            Points = new PointCollection();
            Path = GetPath();
        }

        public void SetIsCurved(bool value)
        {
            isCurved = value;
            Path = GetPath();
        }

        public void AddPoint(Point point)
        {
            Points.Add(point);
            Path = GetPath();
        }

        private PointCollection GetPath()
        {
            PointCollection result;

            if (isCurved)
                result = new PointCollection(MakeCurvePoints(Points.ToArray(), 0.5f));
            else
            {
                result = new PointCollection();
                for (int i = 0; i < Points.Count; i++)
                {
                    AddPointsStraight(Points[i], result);
                }
            }

            return result;
        }

        private void AddPointsStraight(Point point, PointCollection points)
        {
            if (points.Count == 0)
                points.Add(StartPoint);
            else
                points.Add(points.Last());

            points.Add(point);
            points.Add(point);
        }



        /*
         * Source: Draw a smooth curve in WPF and C#
         * Author: RodStephens
         * Date: April 15, 2019
         * Download Date: 06.02.2021
         * URL: http://csharphelper.com/blog/2019/04/draw-a-smooth-curve-in-wpf-and-c/
         */
        // Make an array containing Bezier curve points and control points.
        private Point[] MakeCurvePoints(Point[] points, double tension)
        {
            if (points.Length < 2) return null;
            double control_scale = tension / 0.5 * 0.175;

            // Make a list containing the points and
            // appropriate control points.
            List<Point> result_points = new List<Point>();
            result_points.Add(points[0]);

            for (int i = 0; i < points.Length - 1; i++)
            {
                // Get the point and its neighbors.
                Point pt_before = points[Math.Max(i - 1, 0)];
                Point pt = points[i];
                Point pt_after = points[i + 1];
                Point pt_after2 = points[Math.Min(i + 2, points.Length - 1)];

                double dx1 = pt_after.X - pt_before.X;
                double dy1 = pt_after.Y - pt_before.Y;

                Point p1 = points[i];
                Point p4 = pt_after;

                double dx = pt_after.X - pt_before.X;
                double dy = pt_after.Y - pt_before.Y;
                Point p2 = new Point(
                    pt.X + control_scale * dx,
                    pt.Y + control_scale * dy);

                dx = pt_after2.X - pt.X;
                dy = pt_after2.Y - pt.Y;
                Point p3 = new Point(
                    pt_after.X - control_scale * dx,
                    pt_after.Y - control_scale * dy);

                // Save points p2, p3, and p4.
                result_points.Add(p2);
                result_points.Add(p3);
                result_points.Add(p4);
            }

            // Return the points.
            return result_points.ToArray();
        }


    }
}
