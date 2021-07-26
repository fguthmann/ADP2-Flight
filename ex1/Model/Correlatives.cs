using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1.Model
{
    public class Correlatives
    {
        Dictionary<string, string> correlatives = new();
        public string getCorrelative(string key)
        {
            string s = "";
            correlatives.TryGetValue(key, out s);
            return s;
        }


        public Correlatives(List<string> attributes)
        {
            int i = attributes.Count - 1;
            foreach(string attribute in attributes)
            {
                //get correlative from Anomally Detector (second param) and add both of them to the dictionary
                //but for testing the view:
                correlatives.Add(attribute, attributes[i]);
                i--;
            }
        }

    }
}
