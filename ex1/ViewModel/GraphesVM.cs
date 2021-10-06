using ex1.Model;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1.ViewModel
{
    public enum GraphesNames { MAIN = 0, SECOND = 1};
    public class GraphesVM : INotifyPropertyChanged
    {
        public ObservableCollection<DataPoint> AttrGraph { get; private set; } = new();
        public ObservableCollection<DataPoint> CorrelativeGraph { get; private set; } = new();
        public ObservableCollection<ScatterPoint> DotsGraph { get; private set; }
        public ObservableCollection<ScatterPoint> AnomalisGraph { get; private set; } = new();
        public ObservableCollection<DataPoint> Shape { get; private set; } = new();
        private float x;

        public float X
        {
            get => x;
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }
        private float y;

        public float Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }
        private float radius;

        public float Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged("Radius");
            }
        }
        private float circle_thick;

        public float CircleThick
        {
            get => circle_thick;
            set
            {
                circle_thick = value;
                OnPropertyChanged("CircleThick");
            }
        }
        private float line_thick;

        public float LineThick
        {
            get => line_thick;
            set
            {
                line_thick = value;
                OnPropertyChanged("LineThick");
            }
        }

        public GraphesVM()
        {
            DotsGraph = new();
        }
        public void RemoveShapes()
        {
            Shape.Clear();
            LineThick = 0;
            CircleThick = 0;
        }
        public void DrawCircle(List<float> circle_data)
        {
            X = circle_data[0];
            Y = circle_data[1];
            Radius = circle_data[2] * 2;
            CircleThick = 1;
        }
        public void DrawShape(List<float> shape_data)
        {
            for (int i = 0; i < shape_data.Count; i += 2)
                Shape.Add(new DataPoint(shape_data[i], shape_data[i + 1]));
        }
        public void DrawLine(List<float> line_data)
        {
            X = line_data[0];
            Y = line_data[1];
            LineThick = 1;
        }

        public void EmptyGraphes()
        {
            AttrGraph.Clear();
            CorrelativeGraph.Clear();
            DotsGraph.Clear();
            AnomalisGraph.Clear();
        }
        public void UpdateGraph(List<float> vals, bool isAttr)
        {
            if (isAttr)
                for (int i = 0; i < vals.Count; i++)
                    AttrGraph.Add(new DataPoint(i, vals[i]));
            else
                for (int i = 0; i < vals.Count; i++)
                    CorrelativeGraph.Add(new DataPoint(i, vals[i]));

        }
        public void UpdateDots(List<float> vals, List<float> correlatives)
        {
                for (int i = 0; i < vals.Count; i++)
                    DotsGraph.Add(new ScatterPoint(vals[i], correlatives[i], 3));
        }
        public void UpdateAnomalies(List<float> vals)
        {
            int n = vals.Count / 2;
            for (int i = 0; i < n; i++)
                AnomalisGraph.Add(new ScatterPoint(vals[i], vals[i + n], 3));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
