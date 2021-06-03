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

namespace ST_HMI.UserControls
{
    /// <summary>
    /// Interaction logic for PSDSelection.xaml
    /// </summary>
    /// 
    public partial class PSDSelection : Window
    {
        public string psdType { get; set; }
        public PSDSelection()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            psdTypes.Items.Add("Full Height PSD");
            psdTypes.Items.Add("Half Height PSD");
            psdTypes.Items.Add("Emergency Exit Door");

        }

        private void selectPSD(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void cancelPSDSelection(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void psdTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string psdType = psdTypes.SelectedItem.ToString();
            System.Diagnostics.Debug.WriteLine(psdType);
            this.psdType = psdType;
        }
    }
}
