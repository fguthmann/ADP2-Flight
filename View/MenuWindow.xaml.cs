using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using ex1.ViewModel;
using OxyPlot;


namespace ex1.View
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private string pathFileExceptionFile;
        private bool ExceptionFlightFileDownload;
        private MainWindow runFlight;
        public MenuWindow()
        {
            FlightInfoViewModel flightInfoViewModel = new();

            runFlight = new MainWindow();
            runFlight.DataContext = flightInfoViewModel;
            DataContext = flightInfoViewModel;

            InitializeComponent();
            ExceptionFlightFileDownload = false;
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            App.Current.Shutdown();


        }


        //Start the flight and close our menu window
        private void RunFlight_Click(object sender, RoutedEventArgs e)
        {
            
           // if (ExceptionFlightFileDownload && NormalFlightFileDownload)
            {
                //runFlight.DataContext = (FlightInfoViewModel)this.DataContext);
                runFlight.Show();
                ((FlightInfoViewModel)this.DataContext).RunFlight(pathFileExceptionFile);
                this.Close();
            }
        }

        // Upload our exception flight file
        private void exceptionFLight_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Download file
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pathFileExceptionFile = System.IO.Path.GetFullPath(files[0]);
                string fileNameExceptionFile = System.IO.Path.GetFileName(files[0]);


                // Show that file ha been download correctly
                ExceptionFLight.Content = "Exception flight file downloaded";
                ExceptionFlightFileDownload = true;

            }
        }

        private void PickAnomalyException_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string pathAlgorithmFile = System.IO.Path.GetFullPath(files[0]);
            ((FlightInfoViewModel)DataContext).newAlgorithm(pathAlgorithmFile);
            // Show that file ha been download correctly
            ExceptionFLight.Content = "Exception algorithm downloaded";

        }
    }
}