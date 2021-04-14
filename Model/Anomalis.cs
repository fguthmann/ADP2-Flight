using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1.Model
{
    public class Anomalis
    {
        private IData data;
        private Dictionary<string, string> correlatives = new();
        public Dictionary<string, string> Correlatives { get { return correlatives; } }
        Dictionary<string, List<DataPoint>> drawings = new();
        Dictionary<string, List<int>> anomalies = new();

        private ObservableCollection<DataPoint> draw = new();

        public ObservableCollection<DataPoint> Draw { get { return draw; } }
        public List<int> getAnomalies(string attr)
        {
            return anomalies[attr];
        }
        public void setAttr(string attr)
        {
            Draw.Clear();
            int n = drawings.Count;
            for (int i = 0; i < n; i++)
            {
                Draw.Add(drawings[attr][i]);
            }
        }

        //should receive an anomaly detector as well.
        //the setter will update all the Collections with the AD.
        public void setData(IData info)
        {
            data = info;
        }
    }
}