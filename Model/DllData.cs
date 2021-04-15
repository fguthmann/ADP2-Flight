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
        private Dictionary<string, string> correlatives = new();
        private Dictionary<string, List<DataPoint>> draws = new();
        private Dictionary<string, List<float>> anomalies = new();

        public Dictionary<string, string> Correlatives { get { return correlatives; } }
        public Dictionary<string, List<DataPoint>> Draws { get { return draws; } }
        public Dictionary<string, List<float>> Anomalies { get { return anomalies; } }

        public DllData(string pathToDll, string pathFileNormalFile, string pathFileExceptionFile, List<string> names)
        {
            Type[] externDllTypes = Assembly.LoadFile(@pathToDll).GetTypes();
            dynamic ad = Activator.CreateInstance(externDllTypes[0], pathFileNormalFile, pathFileExceptionFile, names.ToArray<string>());

            //corellations
            int n = ad.getCoupleNum();
            for (int i = 0; i < n; i++)
            {
                if(!correlatives.ContainsKey(ad.getCorrelatives(i, true))){

                    correlatives.Add(ad.getCorrelatives(i, true), ad.getCorrelatives(i, false));
                }
                if(!correlatives.ContainsKey(ad.getCorrelatives(i, true))){

                    correlatives.Add(ad.getCorrelatives(i, false), ad.getCorrelatives(i, true));
                }
            }
            foreach (string s in names)
            {
                if (!correlatives.ContainsKey(s))
                {
                    correlatives.Add(s, " ");
                }
            }

            //Draw
            n = ad.getDrawNUmber();
            foreach (string attr in names)
            {
                List<DataPoint> points = new();
                for (int i = 0; i < n; i++)
                {
                    DataPoint tmp = new DataPoint(ad.getDraw(attr, i, true), ad.getDraw(attr, i, false));
                    points.Add(tmp);
                }
                draws.Add(attr, points);
            }


            //Anomalies
            n = names.Count;
            for (int i = 0; i < n; i++)
            {
                int m = ad.getNumOfAnomalies(names[i]);
                anomalies.Add(names[i], new List<float>());
                for (int j = 0; j < m; j++)
                {
                    anomalies[names[i]].Add(ad.getAnomaly(names[i], j));
                }
            }

        }
    }
}
