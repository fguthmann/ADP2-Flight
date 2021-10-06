using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ex1.Model
{
    public class DllData
    {
        private Dictionary<string, Attribute> attributes = new();

        //where should the data binding be?
        //should put empty builder and initializer?
        //continue the getters
        //can I minimize the API?
        public DllData(string pathToDll, string pathFileExceptionFile, IData data)
        {
            //open the dll
            string pathFileNormalFile = "reg_flight.csv";
            Type[] externDllTypes = Assembly.LoadFile(@pathToDll).GetTypes();
            dynamic ad = Activator.CreateInstance(externDllTypes[0], pathFileNormalFile,
                pathFileExceptionFile, data.getAttrNames().ToArray<string>());

            //get the dll data for each attribute
            foreach (string s in data.getAttrNames())
            {
                Attribute tmp = new();
                tmp.name = s;
                tmp.values = data.getAttElements(s);
                attributes[s] = tmp;
            }
            //get anomalies data
            int n = ad.get_num_of_reports();
            for (int i = 0; i < n; i++)
            {
                dynamic ar = ad.get_AR(i);
                attributes[ar.f1].is_correlative = true;
                attributes[ar.f1].correlative_name = ar.f2;

                for (int j = 0; j < ar.reg_shape.Count; j++)         //copy shape.
                    attributes[ar.f1].regg_shape.Add(ar.reg_shape[j]);
                if (ar.num_reg_points == 1)                             //handle circle.
                {
                    attributes[ar.f1].is_circle = true;
                    attributes[ar.f1].regg_shape.Add(ar.threshold);
                }
                if (ar.is_anomaly)                                      //handle anomalies.
                {
                    attributes[ar.f1].is_anomaly = true;
                    attributes[ar.f1].anomalies = new List<int>(ar.anomalies);
                }
            }
        }
        public bool IsCorrelative(string attr) { return attributes[attr].is_correlative; }
        public string Correlative(string attr) { return attributes[attr].correlative_name; }
        public List<float> GetVals(string attr) { return attributes[attr].values; }
        public bool IsCircle(string attr) { return attributes[attr].is_circle; }
        public List<int> GetAnomalies(string attr, int start, int end)
        {
            List<int> anoms = new();
            foreach(int index in attributes[attr].anomalies)
            {
                if (index >= start && index <= end)
                    anoms.Add(index);
            }
            return anoms;
        }
        public List<float> GetShape(string attr)
        {
            return attributes[attr].regg_shape;
        }
        public bool IsAnomaly(string attr)
        {
            return attributes[attr].is_anomaly;
        }

        //find next anomaly out of current sequence of anomalies.
        private int findNextAnomaly(List<int> anoms, int index)
        {
            for(index++; index < anoms.Count; index++)
            {
                if (anoms[index] - anoms[index - 1] > 1)
                    return anoms[index];
            }
            return anoms[0];
        }
        public int FindNextAnomaly(string attr, int frame)
        {
            int tmp;
            for(int i = 0; i > attributes[attr].anomalies.Count; i++)
            {
                if (attributes[attr].anomalies[i] > frame)
                {
                    if (attributes[attr].anomalies[i] - frame > 1)
                        return attributes[attr].anomalies[i];
                    return findNextAnomaly(attributes[attr].anomalies, i);
                }
            }
            return attributes[attr].anomalies[0];
        }

        private class Attribute
        {
            public string name;
            public bool is_correlative = false;
            public string correlative_name;
            public List<float> values = new();
            public bool is_circle = false;
            public List<float> regg_shape = new();
            public bool is_anomaly = false;
            public List<int> anomalies = new();
        }
    }
    public class Point
    {
        float x, y;
        Point(float a, float b)
        {
            x = a;
            y = b;
        }
    }
    public class AnomalyReport
    {
        public string f1;
        public string f2;
        public int num_reg_points;
        public List<float> reg_shape = new();
        public bool is_anomaly = false;
        public List<int> anomalies = new();
        public AnomalyReport(string s1, string s2)
        {
            f1 = s1;
            f2 = s2;
        }
    }
}
