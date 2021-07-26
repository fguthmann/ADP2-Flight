using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regression;

namespace ex1.Model
{
    public class MainGraph : ObservableCollection<ScatterPoint>
    {
        private IData data;
        private string attrName;
        DllData dllData;
        public Dictionary<string, List<float>> Anomalies { get { return dllData.Anomalies; } }
        public string AttrName
        {
            get
            {
                return attrName;
            }
            set
            {
                if (attrName != value)
                {
                    attrName = value;
                }
            }
        }

        private string correlativeName;
        public string CorrelativeName
        {
            get
            {
                return correlativeName;
            }
            set
            {
                if (correlativeName != value)
                {
                    correlativeName = value;
                    ClearItems();
                }
            }
        }

        public void setData(IData info, DllData dll)
        {
            data = info;
            dllData = dll;
        }


        public void update(int frameIndex)
        {
            ClearItems();
            int i;
            for (i = Math.Max(0, frameIndex - 300); i <= frameIndex; i++)
            {
                if (!Anomalies[attrName].Contains(i))
                {
                    Add(new ScatterPoint(data.getElement(AttrName, i), data.getElement(correlativeName, i), 1, 200));
                    continue;
                }
                Add(new ScatterPoint(data.getElement(AttrName, i), data.getElement(correlativeName, i), 1, 800));
            }
        }
    }
}
