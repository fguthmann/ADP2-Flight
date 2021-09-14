using ex1.Model;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1.ViewModel
{
    public enum GraphesNames { ATTR = 0, COR = 1, DOT = 2, ANOM = 3};
    public class GraphesVM
    {
        public ObservableCollection<DataPoint> AttrGraph { get; private set; } = new();
        public ObservableCollection<DataPoint> CorrelativeGraph { get; private set; } = new();
        public ObservableCollection<ScatterPoint> DotsGraph { get; private set; }
        public ObservableCollection<ScatterPoint> AnomalisGraph { get; private set; } = new();
        public ObservableCollection<DataPoint> Shape { get; private set; } = new();
        public ObservableCollection<DataPoint> Circle { get; private set; } = new();

        public GraphesVM()
        {
            DotsGraph = new();
        }
        public void RemoveShapes()
        {
            Shape.Clear();
            Circle.Clear();
        }
        public void DrawCircle(List<float> circle_data)
        {

        }
        public void DrawShape(List<float> shape_data)
        {
            for (int i = 0; i < shape_data.Count; i += 2)
                Shape.Add(new DataPoint(shape_data[i], shape_data[i + 1]));
        }

        public void EmptyGraphes()
        {
            AttrGraph.Clear();
            CorrelativeGraph.Clear();
            DotsGraph.Clear();
            AnomalisGraph.Clear();
        }
        public void UpdateGraph(List<float> vals, GraphesNames name)
        {
            if (name == GraphesNames.ATTR)
                for (int i = 0; i < vals.Count; i++)
                    AttrGraph.Add(new DataPoint(i, vals[i]));
            if (name == GraphesNames.COR)
                for (int i = 0; i < vals.Count; i++)
                    CorrelativeGraph.Add(new DataPoint(i, vals[i]));
            if (name == GraphesNames.DOT)
                for (int i = 0; i < vals.Count / 2; i += 2)
                    DotsGraph.Add(new ScatterPoint(vals[i], vals[i+1])) ;
            if (name == GraphesNames.ANOM)
                for (int i = 0; i < vals.Count / 2; i += 2)
                    AnomalisGraph.Add(new ScatterPoint(vals[i], vals[i+1])) ;
        }
    }
}
