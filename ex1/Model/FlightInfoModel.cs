using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1.Model
{
    public class FlightInfoModel : INotifyPropertyChanged, IObserver<int>
    {
        private FGHandler Fg_handler;
        private IData data;
        private DllData dllData;
        public FlightInfoModel()
        {
            Fg_handler = new FGClient();
            Fg_handler.Subscribe(this);
        }

        public void UpdateElements(int currentFrame)
        {
            Altimeter = GetElement("altimeter_indicated-altitude-ft", currentFrame);
            AirSpeed = GetElement("airspeed-kt", currentFrame);
            Direction = GetElement("heading-deg", currentFrame);
            Roll = GetElement("roll-deg", currentFrame);
            Pitch = GetElement("pitch-deg", currentFrame);
            Yaw = GetElement("side-slip-deg", currentFrame);
            Aileron = GetElement("aileron", currentFrame);
            Elevator = GetElement("elevator", currentFrame);
            Throttle = GetElement("throttle", currentFrame);
            Rudder = GetElement("rudder", currentFrame);
            CurrentTime = Fg_handler.CurrentFrame /10;
            CurrentSpeed = Fg_handler.FramesPerSecond;
            TimeString = TimeSpan.FromSeconds(currentTime).ToString("hh':'mm':'ss");        //maybe should pass to VM
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //This will update the listeners anytime we update an important stat, mostly currentFrame.
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void OnCompleted(){}
        public void OnError(Exception error){}
        public void OnNext(int value){ UpdateElements(value);}
        //should return void/////////////////////////////////////////////////////////////////
        public List<string> StartFlight (string DllPath, string inputCSV)
        {
            FGHandlerInitializer fghi = new FGHandlerInitializer();
            data = fghi.initializeData(inputCSV, Fg_handler);
            //should remove data from constructor//////////////////////////////////////
            dllData = new(DllPath, inputCSV, data);
            fghi.RunFlight(Fg_handler);
            MaxFrame = Fg_handler.MaxFrame;
            NotifyPropertyChanged(nameof(MaxFrame));
            return data.getAttrNames();
        }
        private float GetElement(string element, int frame) { return data.getElement(element, frame); }

        public void Close() { Fg_handler.Close();}
        public void Play(){ Fg_handler.Pause = false;}
        public void Pause(){ Fg_handler.Pause = true;}

        public string GetCorelative(string attr)
        {
            if (dllData.IsCorrelative(attr))
                return dllData.Correlative(attr);
            return null;
        }
        public bool IsCircle(string attr)
        {
            return dllData.IsCircle(attr);
        }
        public List<float> GetShape(string attr)
        {
            return dllData.GetShape(attr);
        }
        /*Return all vals in specific range, including anomalies.*/
        public List<float> GetRange(string attr, int start_index, int end_index)
        {
            return data.getAttElements(attr).GetRange(Math.Max(0, start_index), Math.Max(0, Math.Min(maxFrame, end_index - start_index)));
        }

        public List<float> GetAnomalies(string attr, int curr_frame)
        {
            List<float> anoms = new();
            foreach(int i in dllData.GetAnomalies(attr, Math.Max(0, curr_frame - 300), Math.Min(MaxFrame, curr_frame)))
                anoms.Add(data.getElement(attr, i));
            return anoms;
        }

        private int currentTime;
        public int CurrentTime
        {
            get=> currentTime;
            set
            {
                if (currentTime != value)
                {
                    currentTime = value;
                    NotifyPropertyChanged(nameof(CurrentTime));
                }
            }
        }
        public void setTime(int second){ Fg_handler.CurrentFrame = second * 10;}
        private string timestring;
        public string TimeString
        {
            get=> timestring;
            set
            {
                if (timestring != value)
                {
                    timestring = value;
                    NotifyPropertyChanged(nameof(TimeString));
                }
            }
        }
        public void setSpeed(float speed){ Fg_handler.FramesPerSecond = (int) speed;}
        private float currentSpeed;
        public float CurrentSpeed
        {
            get=> currentSpeed;
            set
            {
                if (currentSpeed != value)
                {
                    currentSpeed = value;
                    NotifyPropertyChanged(nameof(CurrentSpeed));
                }
            }
        }

        private int maxFrame;
        public int MaxFrame
        {
            get => maxFrame;
            set
            {
                if (value != maxFrame)
                {
                    maxFrame = value;
                    NotifyPropertyChanged(nameof(MaxFrame));
                }
            }
        }

        private float altimeter;
        public float Altimeter
        {
            get => altimeter;
            set
            {
                if (altimeter != value)
                {
                    altimeter = value;
                    NotifyPropertyChanged(nameof(Altimeter));
                }
            }
        }
        private float airSpeed;
        public float AirSpeed
        {
            get => airSpeed;
            set
            {
                if (airSpeed != value)
                {
                    airSpeed = value;
                    NotifyPropertyChanged(nameof(AirSpeed));
                }
            }
        }
        private float direction;
        public float Direction
        {
            get => direction;
            set
            {
                if (direction != value)
                {
                    direction = value;
                    NotifyPropertyChanged(nameof(Direction));
                }
            }
        }
        private float roll;
        public float Roll
        {
            get => roll;
            set
            {
                if (roll != value)
                {
                    roll = value;
                    NotifyPropertyChanged(nameof(Roll));
                }
            }
        }
        private float pitch;
        public float Pitch
        {
            get => pitch;
            set
            {
                if (pitch != value)
                {
                    pitch = value;
                    NotifyPropertyChanged(nameof(Pitch));
                }
            }
        }
        private float yaw;
        public float Yaw
        {
            get => yaw;
            set
            {
                if (yaw != value)
                {
                    yaw = value;
                    NotifyPropertyChanged(nameof(Yaw));
                }
            }
        }
        private float aileron;
        public float Aileron
        {
            get => aileron;
            set
            {
                if (aileron != value)
                {
                    aileron = value;
                    NotifyPropertyChanged(nameof(Aileron));
                }
            }
        }
        private float elevator;
        public float Elevator
        {
            get => elevator;
            set
            {
                if (elevator != value)
                {
                    elevator = value;
                    NotifyPropertyChanged(nameof(Elevator));
                }
            }
        }
        private float throttle;
        public float Throttle
        {
            get => throttle;
            set
            {
                if (throttle != value)
                {
                    throttle = value;
                    NotifyPropertyChanged(nameof(Throttle));
                }
            }
        }
        private float rudder;
        public float Rudder
        {
            get => rudder;
            set
            {
                if (rudder != value)
                {
                    rudder = value;
                    NotifyPropertyChanged(nameof(Rudder));
                }
            }
        }
    }
}
