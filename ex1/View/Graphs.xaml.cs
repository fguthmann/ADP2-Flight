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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ex1.ViewModel;

namespace ex1.View
{
    /// <summary>
    /// Interaction logic for Graphs.xaml
    /// </summary>
    public partial class Graphs : UserControl
    {
        public Graphs()
        {
            InitializeComponent();
            lineG = new OxyPlot.Wpf.LineSeries()
            {
                Color = System.Windows.Media.Color.FromRgb(200, 50, 50),
                StrokeThickness = 30,
            };
            pointsG = new OxyPlot.Wpf.ScatterSeries();
            anomsG = new OxyPlot.Wpf.ScatterSeries();

        }

        // send to the view model the element that has been selected
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            char[] separator = { ' ', ' ' };
            String[] strlist = sender.ToString().Split(separator, StringSplitOptions.None);
            string attr = strlist[1];
            ((FlightInfoViewModel)this.DataContext).ChangeAttrPick(attr);

        }

        private void JumpNextAnomaly(object sender, RoutedEventArgs e) => ((FlightInfoViewModel)this.DataContext).JumpNextAnomaly();

        /**
        // Take the user to exceptions points
        private void ExceptionPoints_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int exceptionFrame =  (int)sender;
            ((FlightInfoViewModel)this.DataContext).MoveToExceptionTime(exceptionFrame);
        }
        */

    }
}
