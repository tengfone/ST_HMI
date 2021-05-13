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
using System.Windows.Threading;

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


        void timer_Tick(object sender, EventArgs e)
        {
            datetime_text.Content = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {


            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_slidingdoor.Visibility = Visibility.Collapsed;
                tt_interface.Visibility = Visibility.Collapsed;
                tt_piechart.Visibility = Visibility.Collapsed;
                tt_notifications.Visibility = Visibility.Collapsed;
                tt_profile.Visibility = Visibility.Collapsed;
                tt_firmware.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_slidingdoor.Visibility = Visibility.Visible;
                tt_interface.Visibility = Visibility.Visible;
                tt_piechart.Visibility = Visibility.Visible;
                tt_notifications.Visibility = Visibility.Visible;
                tt_profile.Visibility = Visibility.Visible;
                tt_firmware.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
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

        private void LV_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Homebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridSysOver, 99);
            Canvas.SetZIndex(GridSysInt, 1);
            Canvas.SetZIndex(GridPlatOver, 1);
            Canvas.SetZIndex(GridUserProf, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 1);
            Canvas.SetZIndex(GridAlarmsOver, 1);
            Canvas.SetZIndex(GridFirmwareUpdate, 1);
            Canvas.SetZIndex(GridUserProf, 1);
        }

        private void Sysintbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridSysInt, 99);
            Canvas.SetZIndex(GridSysOver, 1);
            Canvas.SetZIndex(GridPlatOver, 1);
            Canvas.SetZIndex(GridAlarmsOver, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 1);
            Canvas.SetZIndex(GridFirmwareUpdate, 1);
            Canvas.SetZIndex(GridUserProf, 1);
        }
        private void SlidingDoorbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridPlatOver, 99);
            Canvas.SetZIndex(GridSysInt, 1);
            Canvas.SetZIndex(GridSysOver, 1);
            Canvas.SetZIndex(GridAlarmsOver, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 1);
            Canvas.SetZIndex(GridFirmwareUpdate, 1);
            Canvas.SetZIndex(GridUserProf, 1);
        }

        private void UserProfilebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridPlatOver, 1);
            Canvas.SetZIndex(GridSysInt, 1);
            Canvas.SetZIndex(GridSysOver, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 1);
            Canvas.SetZIndex(GridAlarmsOver, 1);
            Canvas.SetZIndex(GridFirmwareUpdate, 1);
            Canvas.SetZIndex(GridUserProf, 99);
        }

        private void AlarmsOverviewbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridPlatOver, 1);
            Canvas.SetZIndex(GridSysInt, 1);
            Canvas.SetZIndex(GridSysOver, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 1);
            Canvas.SetZIndex(GridAlarmsOver, 99);
            Canvas.SetZIndex(GridFirmwareUpdate, 1);
            Canvas.SetZIndex(GridUserProf, 1);
        }

        private void AnalyticsOverviewbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridPlatOver, 1);
            Canvas.SetZIndex(GridSysInt, 1);
            Canvas.SetZIndex(GridSysOver, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 99);
            Canvas.SetZIndex(GridAlarmsOver, 1);
            Canvas.SetZIndex(GridFirmwareUpdate, 1);
            Canvas.SetZIndex(GridUserProf, 1);
        }

        private void FirmwareUpdatebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetZIndex(GridPlatOver, 1);
            Canvas.SetZIndex(GridSysInt, 1);
            Canvas.SetZIndex(GridSysOver, 1);
            Canvas.SetZIndex(GridAnalyticsOver, 1);
            Canvas.SetZIndex(GridAlarmsOver, 1);
            Canvas.SetZIndex(GridFirmwareUpdate, 99);
            Canvas.SetZIndex(GridUserProf, 1);
        }
    }
}
