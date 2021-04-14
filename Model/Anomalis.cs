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
        private DllData dllData;
        public string getCorrelative(string key)
        {
            return dllData.Correlatives[key];
        }

        private ObservableCollection<DataPoint> draw = new();

        public ObservableCollection<DataPoint> Draw { get { return draw; } }
        public List<float> getAnomalies(string attr)
        {
            return dllData.Anomalies[attr];
        }

        public void setAttr(string attr)
        {
            Draw.Clear();

            foreach(DataPoint dp in dllData.Draws[attr])
            {
                Draw.Add(dp);
            }
        }

        //should receive an anomaly detector as well.
        //the setter will update all the Collections with the AD.
        public void setData(IData info, DllData dllDat)
        {
            data = info;
            dllData = dllDat;
        }
    }
}