using System.ComponentModel;
using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;

namespace ex1.Model
{
    //FGHandler responsible on operating the FlightGear and managing the data.
    public interface FGHandler : IObservable<int>
    {
        //The index of the last frame.
        public int MaxFrame { get; set;}
        public int FramesPerSecond { get; set; }
        public int CurrentFrame { get; set; }
        public bool Pause { get; set; }
        public bool Work { get; set; }
        //Initial the handler with new data, allow use the same handler several times
        //for different projections.
        public void InitialHandler(IData iData);
        //Start the projection.
        public void Start();
        //Close the communication.
        public void Close();
    }


    //FGClient operating the FlightGear using client-server communication.
    public class FGClient : FGHandler
    {
        private Dictionary<int, string> frames = new();
        private List<IObserver<int>> observers = new();

        private int _maxFrame;
        public int MaxFrame
        {
            get { return _maxFrame;}
            set { _maxFrame = value;}
        }
        private int sleepDaur = 100;
        private int _framesPerSecond = 10;
        public int FramesPerSecond
        {
            get{ return _framesPerSecond;}
            set
            {
                _framesPerSecond = value;
                zeroSpeed = false;
                //MaxSpeed, can be set as const or global and even can be set by the user
                if (value >= 80)
                    _framesPerSecond = 80;
                if (value < 1)
                {
                    _framesPerSecond = 0;
                    zeroSpeed = true;
                    foreach (IObserver<int> o in observers)
                        o.OnNext(_currentFrame);
                    return;
                }
                sleepDaur = 1000 / _framesPerSecond;
                foreach (IObserver<int> o in observers)
                    o.OnNext(_currentFrame);
            }
        }
        private int _currentFrame = 0;
        public int CurrentFrame
        {
            get{ return _currentFrame;}
            set
            {
                if (value < 0)
                    value = 0;
                if (value > MaxFrame)
                {
                    value = MaxFrame;
                    Pause = true;
                }
                if (CurrentFrame != value)
                {
                    _currentFrame = value;
                    foreach (IObserver<int> o in observers)
                        o.OnNext(_currentFrame);
                }
            }
        }
        private bool _work = true;
        private bool zeroSpeed = false;
        private bool _pause = false;
        private object pause_lock = new object();
        public bool Pause
        {
            get
            {
                lock (pause_lock)
                    return _pause;
            }
            set
            {
                lock (pause_lock)
                    _pause = value; ;
            }
        }
        public bool Work
        {
            get{ return _work;}
            set
            {
                _work = value;
                Pause = !_work;
            }
        }
        public void InitialHandler(IData iData)
        {
            MaxFrame = iData.getMaxIndex();
            for (int i = 0; i < MaxFrame; i++)
                frames[i] = iData.getChunk(i);
            //default speed is 10 frames per second
        }
        /**
         * Thats the udp client, using udp client over tcp will allow us to login multiple time
         * to the same FG flight. Tcp client is in the buttom of this file under as a comment
         */
        private void sendUdpLine(UdpClient udpClient, int index)
        {
            string frame = frames[index];
            //sendings
            byte[] bytes = Encoding.ASCII.GetBytes(frame);
            udpClient.Send(bytes, bytes.Length, "localHost", 5400);
        }
        public void Start()
        {
            try
            {
                UdpClient udpClient = new UdpClient();
                while (Work)
                {
                    while (!zeroSpeed && !Pause)
                    {
                        sendUdpLine(udpClient, CurrentFrame);
                        CurrentFrame++;
                        Thread.Sleep(sleepDaur);
                    }
                    //prevent busy waiting
                    Thread.Sleep(200);
                }
                sendUdpLine(udpClient, 1);
                Thread.Sleep(200);
                udpClient.Close();
                Work = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void Close()
        {
            Work = false;
            FramesPerSecond = 10;
            CurrentFrame = 0;
        }
        public IDisposable Subscribe(IObserver<int> observer)
        {
            observers.Add(observer);
            return null;
        }
    }
}
/**
tcp client
    public void Start()
    {
        try
        {
            TcpClient tcpClient = new TcpClient("localHost", 5400);
            // Get a client stream for reading and writing.
            NetworkStream stream = tcpClient.GetStream();
            Console.WriteLine("Connected");
            while (Work)
            {
                while (!zeroSpeed && !Pause)
                {
                    CurrentFrame++;
                    string frame = data.getChunk(CurrentFrame);
                    //sendings
                    byte[] bytes = Encoding.ASCII.GetBytes(frame);
                    // Send the message to the connected TcpServer.
                    stream.Write(bytes, 0, frame.Length);
                    stream.Flush();
                    Thread.Sleep(sleepDaur);
                }
                //prevent busy waiting
                Thread.Sleep(200);
            }
            stream.Close();
            tcpClient.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
*/