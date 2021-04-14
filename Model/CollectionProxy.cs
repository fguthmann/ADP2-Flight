using OxyPlot;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ex1.Model
{
    public class CollectionProxy : ObservableCollection<DataPoint>
    {
        IData data;

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
                    ClearItems();
                }
            }
        }

        public void setData(IData info)
        {
            data = info;
        }

        private void addFrames(int frameIndex)
        {
            for (int i = this.Count + 1; i <= frameIndex; i++)
            {
                this.Add(new DataPoint(i, data.getElement(AttrName, i)));
            }
        }
        private void removeItems(int frameIndex)
        {
            for (int i = this.Count; i > frameIndex; i--)
            {
                RemoveItem(i);
            }
        }

        public void update(int frameIndex)
        {
            if (frameIndex > Count)
            {
                addFrames(frameIndex);
            }
            if (frameIndex < Count)
            {
                removeItems(frameIndex);
            }
        }

    }
}
