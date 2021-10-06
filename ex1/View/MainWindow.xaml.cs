using ex1.View;
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
using System.ComponentModel;

namespace ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MenuWindow father;
        public MainWindow(MenuWindow creator)
        {
            father = creator;
            InitializeComponent();
        }

        void closeWindow()
        {
            ((FlightInfoViewModel)this.DataContext).VM_close();
            father.Show();
        }
        // Go back to menu window when the client
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void MainWindow_Closing(object sender, CancelEventArgs e) => closeWindow();
        private void MediaPlayer_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}