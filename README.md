# Flight Gear Desktop App

Flight Analayzer Desktop App, ex1, Advanced Programming 2, biu

# Introduction
A desktop application for presenting and analayzing flight using Flight Gear.
The project is built in MVVM architecture in which: the view is the presentation of the app in screen,
the model is analayzing the input data and communicate with the FG, and the VM help them communicate.

## Overview

* [Ex1](./ex1)
  * [Model](./ex1/Model)
    * [Raw data from the CSV input file](./ex1/Model/Data.cs)
    * [Analayzed Data](./ex1/Model/DllData.cs)
    * [FG App Communicator](./ex1/Model/FGHandler.cs)
    * [Models Fasade](./ex1/Model/FlightInfoModel.cs)
    * [New Flight Initializer](./ex1/Model/FGHandlerInitializer.cs)
    * [XML Parser](./ex1/Model/XMLParser.cs)
  * [View Model](./ex1/ViewModel)
    * [VMs Facade](./ex1/ViewModel/FlightInfoViewModel.cs)
    * [Graphes VM](./ex1/ViewModel/GraphesVM.cs)
  * [View](./ex1/View)
    * [Add New Anomaly Detection Algorithm](./ex1/View/AddNewAlgorithm.cs)
    * [Graphs View](./ex1/View/Graphs.cs)
    * [Information Table View](./ex1/View/InformationTable.cs)
    * [Joystick View](./ex1/View/Joystick.cs)
    * [Main Window](./ex1/View/MainWindow.cs)
    * [Start Menu Window](./ex1/View/MenuWindow.cs)
    * [Media Player](./ex1/View/MediaPlayer.cs)
    * [Sliders View](./ex1/View/Sliders.cs)
  * [Plug-Ins](./ex1/plug-ins)
    * [Linear Anomaly Detection Algorithm](./ex1/plug-ins/LinearAnomalyDetector.dll)
    * [Hybrid Anomaly Detection Algorithm](./ex1/plug-ins/HybridAnomalyDetector.cs.dll)

# Pre requirements
* Flight Gear 2020.3.6 installed
* In FG settings-> AdditionalSettings, write "--generic=socket,in,10,127.0.0.1,6400,udp,playback_small --fdm=null".
* The telnet client should be running on the same machine as FlightGear itself.
* The input CSV file should have the attributes as in the playback_small.xml file (in the same order).

# Dll Interface
* Constructor receive: (1) string path_to_regular_flight (2) string path_to_anomaly_flight (3) string[] attributes_names.
* Should contain the functions:
* public int get_num_of_reports(); that return the number of anomaly reports.
* public AnomalyReport get_AR(int index); that return the indexed Anomaly Report.
* AnomalyReport- claas that contain the following:
*       public string f1;
        public string f2;
        public int num_reg_points;
        public List<float> reg_shape = new List<float>();
        public float threshold;
        public bool is_anomaly = false;
        public List<int> anomalies = new List<int>();
