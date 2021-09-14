using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;


namespace ex1.Model
{
    public class FGHandlerInitializer
    {
        public IData initializeData(string pathFileExceptionFile, FGHandler handler)
        {
            string adress = "playback_small.xml";    //optional to cahnge the xml file.
            XMLParser p = new XMLParser(adress);

            string startNode = "input";             //optional to cahnge the start node of the XML.
            List<string> names = new List<string>();
            p.buildingTS(names, startNode);

            pathFileExceptionFile = "reg_flight.csv";
            IData data = new CSData(names, pathFileExceptionFile);
            handler.InitialHandler(data);
            return data;
        }

        public void RunFlight(FGHandler handler)
        {
            Thread thread = new Thread(new ThreadStart(handler.Start));
            thread.Start();
        }
    }
}
