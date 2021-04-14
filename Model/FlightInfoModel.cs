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
        public FlightInfoModel()
        {
            Fg_handler = new FGClient();
            Fg_handler.Subscribe(this);
        }

        public void UpdateElements(int currentFrame)
        {
            Altimeter = Fg_handler.GetElement("altimeter_indicated-altitude-ft", currentFrame);
            AirSpeed = Fg_handler.GetElement("airspeed-kt", currentFrame);
            Direction = Fg_handler.GetElement("heading-deg", currentFrame);
            Roll = Fg_handler.GetElement("roll-deg", currentFrame);
            Pitch = Fg_handler.GetElement("pitch-deg", currentFrame);
            Yaw = Fg_handler.GetElement("side-slip-deg", currentFrame);
            Aileron = Fg_handler.GetElement("aileron", currentFrame);
            Elevator = Fg_handler.GetElement("elevator", currentFrame);
            Throttle = Fg_handler.GetElement("throttle", currentFrame);
            Rudder = Fg_handler.GetElement("rudder", currentFrame);
            CurrentTime = Fg_handler.CurrentFrame /10;
            CurrentSpeed = Fg_handler.FramesPerSecond;
            TimeString = TimeSpan.FromSeconds(currentTime).ToString("hh':'mm':'ss");
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

        public IData StartFlight (string inputCSV)
        {
            FGHandlerInitializer fghi = new FGHandlerInitializer();
            IData data = fghi.initializeData(inputCSV);
            fghi.RunFlight(Fg_handler, data);
            MaxFrame = Fg_handler.MaxFrame;
            NotifyPropertyChanged(nameof(MaxFrame));
            return data;
        }

        public void Close()
        {
            Fg_handler.Close();

        }

        public void Play(){ Fg_handler.Pause = false;}

        public void Pause(){ Fg_handler.Pause = true;}


        private int currentTime;
        public int CurrentTime
        {
            get{ return currentTime;}
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
            get{ return timestring;}
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
            get{ return currentSpeed;}
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
            get { return maxFrame;}
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
            get { return altimeter;}
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
            get { return airSpeed;}
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
            get { return direction; }
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
            get { return roll;}
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
            get { return pitch;}
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
            get { return yaw;}
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
            get { return aileron;}
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
            get { return elevator;}
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
            get { return throttle;}
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
            get { return rudder;}
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
