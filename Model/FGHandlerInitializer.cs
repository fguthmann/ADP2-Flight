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
        public IData initializeData(string pathFileExceptionFile)
        {
            string adress = "playback_small.xml";
            XMLParser p = new XMLParser(adress);

            string startNode = "input";
            List<string> names = new List<string>();
            p.buildingTS(names, startNode);

            pathFileExceptionFile = "reg_flight.csv";
            return new CSData(names, pathFileExceptionFile);
        }

        public void RunFlight(FGHandler handler, IData data)
        {
            handler.InitialHandler(data);

            Thread thread = new Thread(new ThreadStart(handler.Start));
            thread.Start();
        }
    }
}
