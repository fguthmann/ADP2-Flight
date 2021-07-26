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
        private string pathToDLL;
        private string pathFileExceptionFile = "anomaly_flight.csv";
        private string NormalFlightFileDownload = "reg_flight.csv";
        private bool ExceptionFlightFileDownload;
        private bool pathToDLLDownload;
        private MainWindow runFlight;
        public MenuWindow()
        {
            FlightInfoViewModel flightInfoViewModel = new();

            runFlight = new MainWindow();
            runFlight.DataContext = flightInfoViewModel;
            DataContext = flightInfoViewModel;

            InitializeComponent();

            pathToDLLDownload = false;
            ExceptionFlightFileDownload = false;
        }



        // Upload our normal flight file
       /* private void NormalFLight_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Download file
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pathFileNormalFlight = System.IO.Path.GetFullPath(files[0]);
                string fileNameNormalFlight = System.IO.Path.GetFileName(files[0]);

                // Show that file ha been download correctly
                FileNameLabel.Content = "Normal flight file downloaded";
                NormalFlightFileDownload = true;

            }
        }*/


        private void RegisterAlgo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InternCircleAlgo_Click(object sender, RoutedEventArgs e)
        {

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
                ((FlightInfoViewModel)this.DataContext).RunFlight(NormalFlightFileDownload, pathFileExceptionFile, pathToDLL);
                this.Hide();
                ExceptionFLight.Content = "Change exception flight file";
                DllBox.Content = "Change dll file";
            }
        }


        /**
        // Open window to drop file of new algorithm
        private void AddAlgorithm_Click(object sender, RoutedEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Download file
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pathToDLL = System.IO.Path.GetFullPath(files[0]);
                string pathToDLL = System.IO.Path.GetFileName(files[0]);


                // Show that file ha been download correctly
                ExceptionFLight.Content = "Exception flight file downloaded";
                ExceptionFlightFileDownload = true;

            }
        }
        */

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

        private void dllFileDrop_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Download file
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pathToDLL = System.IO.Path.GetFullPath(files[0]);


                // Show that file ha been download correctly
                DllBox.Content = "Dll file downloaded";
                ExceptionFlightFileDownload = true;

            }
        }
    }
}