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
        public GraphesVM graphes { get; init; } = new();
        // Notify that an element has been update to update all element
        public FlightInfoViewModel()
        {
            this.model = new FlightInfoModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        // Call the function that need to be update
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //private float convertion;
        public int VM_MaxFrame => model.MaxFrame / 10;
        //Get the new value of the general information to show it where needed
        public float VM_Altimeter => model.Altimeter;
        public float VM_AirSpeed => model.AirSpeed;
        public float VM_Direction => model.Direction;
        public float VM_Roll => model.Roll;
        public float VM_Pitch => model.Pitch;
        public float VM_Yaw => model.Yaw;
        public float VM_Aileron => model.Aileron * 300;
        public float VM_Elevator => model.Elevator * 300;
        public float VM_Throttle => model.Throttle;
        public float VM_Rudder => model.Rudder;

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
            Thread.Sleep(100);
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
                ////////////////////////////////////////////////check if needed
                UpdateGraphes();
                return model.CurrentTime;
            }
            set { model.setTime(value); }
        }

        // SHow the current time as string
        public string VM_TimeString
        {
            get
            {
                if(model.TimeString != null)
                    UpdateGraphes();
                return model.TimeString; ;
            }
        }

        // Show the current speed
        public float VM_CurrentSpeed => model.CurrentSpeed / (float)10;
        private string pathToDll;
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private ObservableCollection<string> _names = new();
        public ObservableCollection<string> names { get => _names; }
        //public Anomalis anomalis = new();
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
            this.pathToDll = pathToDll;
            List<string> new_names = model.StartFlight(pathToDll, pathFileExceptionFile);
            updateNames(new_names, names);

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(names)));

        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////
        /// </summary>
        public string attribute = new("Choose Attribute");
        public string correlative = new("No Correlative");
        private void UpdateGraphes()
        {
            graphes.EmptyGraphes();
            if (attribute.Equals("Choose Attribute"))
                return;
            int frame = model.CurrentTime * 10;
            graphes.UpdateGraph(model.GetRange(attribute, 0, frame), GraphesNames.ATTR);
            if (correlative.Equals("No Correlative"))
                return;
            graphes.UpdateGraph(model.GetRange(correlative, 0, frame), GraphesNames.COR);
            graphes.UpdateGraph(model.GetRange(attribute, frame - 300, frame), GraphesNames.DOT);
            graphes.UpdateGraph(model.GetAnomalies(attribute, frame), GraphesNames.ANOM);
        }
        public void ChangeAttrPick(string attr)
        {
            attribute = attr;
            correlative = "No Correlative";
            graphes.RemoveShapes();
            if (model.GetCorelative(attribute) == null)
                return;
            correlative = model.GetCorelative(attribute);
            if (model.IsCircle(attribute))
                graphes.DrawCircle(model.GetShape(attribute));
            else
                graphes.DrawShape(model.GetShape(attribute));
            UpdateGraphes();
        }

        //public void MoveToExceptionTime(string exceptionFrame) { model.setTime(exceptionFrame); }
    }
}
