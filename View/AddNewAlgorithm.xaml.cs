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

namespace ex1.View
{
    /// Interaction logic for AddNewAlgorithm.xaml
    public partial class AddNewAlgorithm : Window
    {
        public AddNewAlgorithm()
        {
            InitializeComponent();
        }
        public string pathNewAlgorithm;
        public string fileNewAlgorithm;

        //Drop new algorithm file
        private void NewAlogrithm_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Download file
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pathNewAlgorithm = System.IO.Path.GetFullPath(files[0]);
                fileNewAlgorithm = System.IO.Path.GetFileName(files[0]);
                this.Close();

            }

        }
    }
}