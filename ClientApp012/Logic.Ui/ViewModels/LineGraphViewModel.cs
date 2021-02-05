﻿using De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels.LineGraph.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace De.HsFlensburg.ClientApp012.Logic.Ui.ViewModels
{
    public class LineGraphViewModel : INotifyPropertyChanged
    {        
        //Axis
        private ObservableCollection<string> verticallNumbers;
        public ObservableCollection<string> VerticalNumbers
        {
            get { return verticallNumbers; }
            set
            {
                verticallNumbers = value;
                OnPropertyChanged("VerticalNumbers");
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

        //Shapes - Lines
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

            for (int i = 0; i < 10; i++)
            {
                HorizontalNumbers.Add("" + i);
            }

            VerticalNumbers = new ObservableCollection<string>();

            for (int i = 10; i < 20; i++)
            {
                VerticalNumbers.Add("" + i);
            }

            //Shapes
            Shapes = new ObservableCollection<IShape>();
            //Shapes.Add(new ShapeLine(0, 1, 0.1, 0.8));
            //Shapes.Add(new ShapeLine(0.1, 0.8, 0.2, 0.7));


            PointCollection myPointCollection = new PointCollection();

            myPointCollection.Add(new Point(0, 1));
            myPointCollection.Add(new Point(0, 0.9));
            myPointCollection.Add(new Point(0.1, 0.9));

            myPointCollection.Add(new Point(0.1, 0.9));
            myPointCollection.Add(new Point(0.2, 0.9));
            myPointCollection.Add(new Point(0.2, 0.8));

            myPointCollection.Add(new Point(0.2, 0.8));
            myPointCollection.Add(new Point(0.2, 0.5));
            myPointCollection.Add(new Point(0.5, 0.5));


            Shapes.Add(new ShapePath(myPointCollection));



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
