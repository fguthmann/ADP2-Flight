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
using System.Threading;

namespace ex1.View
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SlowForwardPlus_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_SlowForwardPlus();
        }

        private void SlowForward_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_SlowForward();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_Play();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_Stop();
        }

        private void FastForward_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_FastForward();
        }

        private void FastForwardSuper_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_FastForwardPlus();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            ((FlightInfoViewModel)this.DataContext).VM_Pause();
        }
    }
}