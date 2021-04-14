using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1.Model
{
    public class MainGraph : ObservableCollection<ScatterPoint>
    {
        private IData data;
        private string attrName;
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

        public void setData(IData info)
        {
            data = info;
        }


        public void update(int frameIndex)
        {
            ClearItems();
            int i;
            for (i = Math.Max(0, frameIndex - 300); i <= frameIndex; i++)
            {
                Add(new ScatterPoint(data.getElement(AttrName, i), data.getElement(correlativeName, i), 1, 200));
            }
        }
    }
}
