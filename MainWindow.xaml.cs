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
        List<DoorModel> items = new List<DoorModel>();
        List<DoorModel> items2 = new List<DoorModel>();
        List<DoorModel> items3 = new List<DoorModel>();
        List<SummaryValues> platformValues;
        List<DoorIndicator> indicators = new List<DoorIndicator>();
        List<DoorIndicator> indicators2 = new List<DoorIndicator>();
        List<DoorIndicator> indicators3 = new List<DoorIndicator>();
        int summaryValuesCounter = 0;
        public MainWindow()
        {
            InitializeComponent();

            // platform 1 doors
            items.Add(new DoorModel() { DoorNum = "PSD1", URI = "Assets/PSDOpening.png" });
            items.Add(new DoorModel() { DoorNum = "PSD2", URI = "Assets/PSDLock.png" });
            items.Add(new DoorModel() { DoorNum = "PSD3", URI = "Assets/PSDInhibit.png" });
            items.Add(new DoorModel() { DoorNum = "PSD4", URI = "Assets/EEDLock.png" });
            items.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDerror.png" });
            items.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDOpening.png" });

            // platform 1 indicators
            indicators.Add(new DoorIndicator() { DoorNum = "PSD1", URI = "Assets/PSD_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD2", URI = "Assets/PSD_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD3", URI = "Assets/EED_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "Assets/EED_halfheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "Assets/PSD_fullheight_faulty.png" });

            // platform 2 doors
            items2.Add(new DoorModel() { DoorNum = "PSD1", URI = "Assets/PSDOpening.png" });
            items2.Add(new DoorModel() { DoorNum = "PSD3", URI = "Assets/PSDInhibit.png" });
            items2.Add(new DoorModel() { DoorNum = "PSD3", URI = "Assets/PSDOpening.png" });
            items2.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDerror.png" });
            items2.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDOpening.png" });

            // platform 2 indicators
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "Assets/PSD_fullheight_faulty.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "Assets/PSD_fullheight_faulty.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "Assets/PSD_fullheight_faulty.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "Assets/PSD_fullheight_faulty.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "Assets/PSD_fullheight_faulty.png" });

            // platform 3 doors
            items3.Add(new DoorModel() { DoorNum = "PSD3", URI = "Assets/PSDInhibit.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD2", URI = "Assets/PSDLock.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD3", URI = "Assets/PSDInhibit.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDOpening.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDOpening.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD5", URI = "Assets/PSDOpening.png" });

            // platform 3 indicators
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "Assets/EED_halfheight.png" });

            platformValues = new List<SummaryValues>();
            platformValues.Add(new SummaryValues() { titleLabel = "Doors Failed to Open/close", valueLabel = "1" });
            platformValues.Add(new SummaryValues() { titleLabel = "Platform Voltage", valueLabel = "80V" });
            titleLabel.Content = platformValues[0].titleLabel;
            valueLabel.Content =  platformValues[0].valueLabel;

            DoorsDataBinding.ItemsSource = items;
            IndicatorsDataBinding.ItemsSource = indicators;
            IndicatorsDataBinding2.ItemsSource = indicators2;
            IndicatorsDataBinding3.ItemsSource = indicators3;

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

        class DoorIndicator
        {
            public string DoorNum { get; set; }
            public string URI { get; set; }
        }

        class SummaryValues
        {
            public string titleLabel { get; set; }
            public string valueLabel { get; set; }

        }

        void ChangePlatform1(object sender, EventArgs e)
        {
            DoorsDataBinding.ItemsSource = items;
        }
        void ChangePlatform2(object sender, EventArgs e)
        {
            DoorsDataBinding.ItemsSource = items2;
        }

        void ChangePlatform3(object sender, EventArgs e)
        {
            DoorsDataBinding.ItemsSource = items3;
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

        void nextLabel(object sender, EventArgs e)
        {
            summaryValuesCounter++;
            if (summaryValuesCounter == platformValues.Count - 1)
            {
                nextbtn.IsEnabled = false;
                backbtn.IsEnabled = true;
            }
 
            titleLabel.Content = platformValues[summaryValuesCounter].titleLabel;
            valueLabel.Content = platformValues[summaryValuesCounter].valueLabel;
            
        }

        void previousLabel(object sender, EventArgs e)
        {
            summaryValuesCounter--;
            if (summaryValuesCounter == 0)
            {
                backbtn.IsEnabled = false;
                nextbtn.IsEnabled = true;
            }
   
            titleLabel.Content = platformValues[summaryValuesCounter].titleLabel;
            valueLabel.Content = platformValues[summaryValuesCounter].valueLabel;
            
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
