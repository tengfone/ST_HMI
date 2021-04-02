using Caliburn.Micro;
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

namespace ST_HMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<DoorModel> items = new List<DoorModel>();
            items.Add(new DoorModel() { DoorNum = "PSD1", URI = "Assets/PSDOpening.png" });
            items.Add(new DoorModel() { DoorNum = "PSD2", URI = "Assets/PSDLock.png" });
            items.Add(new DoorModel() { DoorNum = "PSD3", URI = "Assets/PSDInhibit.png" });
            items.Add(new DoorModel() { DoorNum = "PSD4", URI = "Assets/EEDLock.png" });
            items.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDerror.png" });
            items.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDOpening.png" });
            DoorsDataBinding.ItemsSource = items;
            System.Windows.Threading.DispatcherTimer LiveTime = new System.Windows.Threading.DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        class DoorModel
        {
            public string DoorNum { get; set; }
            public string URI { get; set; }

        }

        void timer_Tick(object sender, EventArgs e)
        {
            datetime_text.Content = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
        }

        void change_language(object sender, EventArgs e)
        {
            if (language_text.Content.Equals("EN")) {
                language_text.Content = "CN";
            } else
            {
                language_text.Content = "EN";
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {


            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_slidingdoor.Visibility = Visibility.Collapsed;
                tt_dashboard.Visibility = Visibility.Collapsed;
                tt_piechart.Visibility = Visibility.Collapsed;
                tt_notifications.Visibility = Visibility.Collapsed;
                tt_profile.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_slidingdoor.Visibility = Visibility.Visible;
                tt_dashboard.Visibility = Visibility.Visible;
                tt_piechart.Visibility = Visibility.Visible;
                tt_notifications.Visibility = Visibility.Visible;
                tt_profile.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
