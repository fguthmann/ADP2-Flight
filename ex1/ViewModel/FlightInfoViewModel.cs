using ex1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using OxyPlot;
using System.Linq;
using System.Reflection;

namespace ex1.ViewModel
{

    public class FlightInfoViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public FlightInfoModel model { get; private set; }
        // Notify that an element has been update to update all element
        public FlightInfoViewModel()
        {
            this.model = new FlightInfoModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            attrGraph = new();
            correlativeGraph = new();
            DotsGraph = new();
        }

        // Call the function that need to be update
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //private float convertion;

        public int VM_MaxFrame
        {
            get
            {
                return model.MaxFrame / 10;
            }
        }

        //Get the new value of the general information to show it where needed
        public float VM_Altimeter { get { return model.Altimeter; } }
        public float VM_AirSpeed { get { return model.AirSpeed; } }
        public float VM_Direction { get { return model.Direction; } }
        public float VM_Roll { get { return model.Roll; } }
        public float VM_Pitch { get { return model.Pitch; } }
        public float VM_Yaw { get { return model.Yaw; } }
        public float VM_Aileron { get { return model.Aileron * 300; } }
        public float VM_Elevator { get { return model.Elevator * 300; } }
        public float VM_Throttle { get { return model.Throttle; } }
        public float VM_Rudder { get { return model.Rudder; } }

        // Call the close function to close the program
        public void VM_close() { model.Close(); }

        // Slow forward plus the flight
        public void VM_SlowForwardPlus() { model.setTime((int)model.CurrentTime - 10); }

        // Slow forward the flight
        public void VM_SlowForward() { model.setSpeed(model.CurrentSpeed - 1); }

        // Play the flight
        public void VM_Play() { model.Play(); }

        // Pause the flight
        public void VM_Pause() { model.Pause(); }
        // Restart the flight from beginning
        public void VM_Stop()
        {
            model.Play();
            model.setTime(0);
            Thread.Sleep(200);
            model.Pause();

        }

        // Fast forward the flight
        public void VM_FastForward() { model.setSpeed(model.CurrentSpeed + 1); }

        // Fast forward plus the flight
        public void VM_FastForwardPlus() { model.setTime((int)model.CurrentTime + 10); }

        // Play the current time in second
        // Update the values of the different element when the frame is update
        public int VM_CurrentTime
        {
            get
            {
                if (correlativeGraph.AttrName != null)
                {
                    updateGraphes(model.CurrentTime * 10);
                }
                return model.CurrentTime;
            }
            set { model.setTime(value); }
        }



        // SHow the current time as string
        public string VM_TimeString { get { return model.TimeString; } }


        // Show the current speed
        public float VM_CurrentSpeed { get { return model.CurrentSpeed / (float)10; } }
        private string pathToDll;
        private ObservableCollection<string> _names = new();
        public ObservableCollection<string> names { get { return _names; } }
        public Anomalis anomalis = new();
        private void updateNames(List<string> src, ObservableCollection<string> dst)
        {
            dst.Clear();
            foreach(string s in src)
            {
                dst.Add(s);
            }
        }


        public void RunFlight(string pathFileNormalFile, string pathFileExceptionFile, string pathToDll)
        {
            IData data = model.StartFlight(pathFileExceptionFile);
            updateNames(data.getAttrNames(), names);
            this.pathToDll = pathToDll;

            Type[] externDllTypes = Assembly.LoadFile(@pathToDll).GetTypes();
            dynamic ad = Activator.CreateInstance(externDllTypes[0], pathFileNormalFile, pathFileNormalFile, names.ToArray<string>());

            DllData dlldata = new DllData(pathToDll, pathFileNormalFile, pathFileExceptionFile, names.ToList<string>());
            anomalis.setData(data, dlldata);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(names)));

            attrGraph.setData(data);
            correlativeGraph.setData(data);
            DotsGraph.setData(data, dlldata);
        }




        public CollectionProxy attrGraph { get; set; }
        public CollectionProxy correlativeGraph { get; set; }
        public MainGraph DotsGraph { get; set; }

        private string currentAttr;
        public string CurrentAttr
        {
            get { return currentAttr; }
            set
            {
                if(currentAttr != value)
                {
                    currentAttr = value;
                    NotifyPropertyChanged(nameof(CurrentAttr));
                }
            }
        }
        private string correlativeAttr;
        public string CorrelativeAttr
        {
            get { return correlativeAttr; }
            set
            {
                if (correlativeAttr != value)
                {
                    correlativeAttr = value;
                    NotifyPropertyChanged(nameof(CorrelativeAttr));
                }
            }
        }
        public void changeGraphPick(string attr)
        {
            currentAttr = attr;
            correlativeAttr = anomalis.getCorrelative(currentAttr);
            attrGraph.AttrName = currentAttr;
            DotsGraph.AttrName = currentAttr;
            correlativeGraph.AttrName = CorrelativeAttr;
            DotsGraph.CorrelativeName = CorrelativeAttr;
            anomalis.setAttr(currentAttr);

            updateGraphes(model.CurrentTime * 10);
        }

        private void updateGraphes(int time)
        {
            attrGraph.update(time);
            correlativeGraph.update(time);
            DotsGraph.update(time);
        }

        
        //public void MoveToExceptionTime(string exceptionFrame) { model.setTime(exceptionFrame); }


    }
}
