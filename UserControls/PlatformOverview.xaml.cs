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
    /// Interaction logic for PlatformOverview.xaml
    /// </summary>
    public partial class PlatformOverview : UserControl
    {
        List<DoorModel> items_1 = new List<DoorModel>();
        List<DoorModel> items_2 = new List<DoorModel>();
        List<DoorModel> items_3 = new List<DoorModel>();
        List<DoorModel> items_4 = new List<DoorModel>();
        List<DoorModel> items_5 = new List<DoorModel>();

        List<DoorModel> items2_1 = new List<DoorModel>();
        List<DoorModel> items2_2 = new List<DoorModel>();
        List<DoorModel> items2_3 = new List<DoorModel>();
        List<DoorModel> items2_4 = new List<DoorModel>();
        List<DoorModel> items2_5 = new List<DoorModel>();

        List<DoorModel> items3 = new List<DoorModel>();
        List<SummaryValues> platformValues;
        List<DoorIndicator> indicators = new List<DoorIndicator>();
        List<DoorIndicator> indicators2 = new List<DoorIndicator>();
        List<DoorIndicator> indicators3 = new List<DoorIndicator>();
        int summaryValuesCounter = 0;

        DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Send);

        Boolean REMOVE_PSD = false;

        public PlatformOverview()
        {
            InitializeComponent();

            items_1.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd1.png" });
            items_1.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd1.png" });
            items_1.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd1.png" });
            items_1.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd1.png" });
            items_1.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd1.png" });

            items_2.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd2.png" });
            items_2.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd2.png" });
            items_2.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd2.png" });
            items_2.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd2.png" });
            items_2.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd2.png" });
                                                                   
            items_3.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd3.png" });
            items_3.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd3.png" });
            items_3.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd3.png" });
            items_3.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd3.png" });
            items_3.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd3.png" });
                                                                  
            items_4.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd4.png" });
            items_4.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd4.png" });
            items_4.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd4.png" });
            items_4.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd4.png" });
            items_4.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd4.png" });
                                                                   
            items_5.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd5.png" });
            items_5.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd5.png" });
            items_5.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd5.png" });
            items_5.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd5.png" });
            items_5.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd5.png" });

            // platform 1 indicators
            indicators.Add(new DoorIndicator() { DoorNum = "PSD1", URI = "../Assets/PSD_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD2", URI = "../Assets/PSD_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD3", URI = "../Assets/PSD_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/PSD_fullheight.png" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "../Assets/PSD_fullheight.png" });

            // platform 2 doors
            items2_1.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd5.png" });
            items2_1.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd5.png" });
            items2_1.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd5.png" });
            items2_1.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd5.png" });
            items2_1.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd5.png" });

            items2_2.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd4.png" });
            items2_2.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd4.png" });
            items2_2.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd4.png" });
            items2_2.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd4.png" });
            items2_2.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd4.png" });


            items2_3.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd3.png" });
            items2_3.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd3.png" });
            items2_3.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd3.png" });
            items2_3.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd3.png" });
            items2_3.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd3.png" });


            items2_4.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd2.png" });
            items2_4.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd2.png" });
            items2_4.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd2.png" });
            items2_4.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd2.png" });
            items2_4.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd2.png" });


            items2_5.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd1.png" });
            items2_5.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd1.png" });
            items2_5.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd1.png" });
            items2_5.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd1.png" });
            items2_5.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd1.png" });


            // platform 2 indicators
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD1", URI = "../Assets/PSD_fullheight.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD2", URI = "../Assets/PSD_fullheight.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD3", URI = "../Assets/PSD_fullheight.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/PSD_fullheight.png" });
            indicators2.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "../Assets/PSD_fullheight.png" });

            // platform 3 doors
            items3.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/PSDInhibit.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/PSDLock.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/PSDInhibit.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/PSDOpening.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/PSDOpening.png" });
            items3.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/PSDOpening.png" });

            // platform 3 indicators
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/EED_halfheight.png" });
            indicators3.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/EED_halfheight.png" });

            platformValues = new List<SummaryValues>();
            platformValues.Add(new SummaryValues() { titleLabel = "Doors Failed to Open/close", valueLabel = "1" });
            platformValues.Add(new SummaryValues() { titleLabel = "Platform Voltage", valueLabel = "80V" });
            titleLabel.Content = platformValues[0].titleLabel;
            valueLabel.Content = platformValues[0].valueLabel;

            DoorsDataBinding.ItemsSource = items_1;
            IndicatorsDataBinding.ItemsSource = indicators;
            IndicatorsDataBinding2.ItemsSource = indicators2;
            IndicatorsDataBinding3.ItemsSource = indicators3;

            dispatcherTimer.Tick += Animation;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();

            // Initialize for Counter
            backbtn.IsEnabled = false;
        }


        private void PSDPopup_click(object sender, MouseButtonEventArgs e)
        {
            PSDPopup psdPopupWindow = new PSDPopup("PSD1");
            psdPopupWindow.Show();
        }

        private void Animation(object sender, EventArgs e)
        {
            /*Platform 1 door animation*/
            if (DoorsDataBinding.ItemsSource == items_1)
            {
                DoorsDataBinding.ItemsSource = items_2;
            }
            else if (DoorsDataBinding.ItemsSource == items_2)
            {
                DoorsDataBinding.ItemsSource = items_3;
            }
            else if (DoorsDataBinding.ItemsSource == items_3)
            {
                DoorsDataBinding.ItemsSource = items_4;
            }
            else if (DoorsDataBinding.ItemsSource == items_4)
            {
                DoorsDataBinding.ItemsSource = items_5;
            }
            else if (DoorsDataBinding.ItemsSource == items_5)
                {
                    DoorsDataBinding.ItemsSource = items_1;
            }

            /*Platform 2 door animtaion*/
            if (DoorsDataBinding.ItemsSource == items2_1)
            {
                DoorsDataBinding.ItemsSource = items2_2;
            }
            else if (DoorsDataBinding.ItemsSource == items2_2)
            {
                DoorsDataBinding.ItemsSource = items2_3;
            }
            else if (DoorsDataBinding.ItemsSource == items2_3)
            {
                DoorsDataBinding.ItemsSource = items2_4;
            }
            else if (DoorsDataBinding.ItemsSource == items2_4)
            {
                DoorsDataBinding.ItemsSource = items2_5;
            }
            else if (DoorsDataBinding.ItemsSource == items2_5)
            {
                DoorsDataBinding.ItemsSource = items2_1;
            }
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

        void Add_PSD(object sender, EventArgs e)
        {
            List<DoorModel> doorItems = (List<DoorModel>)DoorsDataBinding.ItemsSource;
            int count = doorItems.Count;
            char c = doorItems[count - 1].DoorNum.Last();
            int num = (int)Char.GetNumericValue(c);
            string doorNum = "PSD" + (num + 1).ToString();

            items_1.Add(new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd1.png" });
            items_2.Add(new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd2.png" });
            items_3.Add(new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd3.png" });
            items_4.Add(new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd4.png" });
            items_5.Add(new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd5.png" });

            indicators.Add(new DoorIndicator() { DoorNum = doorNum, URI = "../Assets/PSD_fullheight.png" });
        }
        void Remove_PSD_True(object sender, EventArgs e)
        {
            REMOVE_PSD = !REMOVE_PSD;
            System.Diagnostics.Debug.WriteLine(REMOVE_PSD);
        }

        void Remove_PSD(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("trying to remove door");
            string doorNum = ((TextBlock)sender).Text;

            if (REMOVE_PSD)
            {
                System.Diagnostics.Debug.WriteLine("removing door");

                foreach (var n in items_1.Where(item => item.DoorNum == doorNum).ToArray()) items_1.Remove(n);
                foreach (var n in items_2.Where(item => item.DoorNum == doorNum).ToArray()) items_2.Remove(n);
                foreach (var n in items_3.Where(item => item.DoorNum == doorNum).ToArray()) items_3.Remove(n);
                foreach (var n in items_4.Where(item => item.DoorNum == doorNum).ToArray()) items_4.Remove(n);
                foreach (var n in items_5.Where(item => item.DoorNum == doorNum).ToArray()) items_5.Remove(n);

                indicators = indicators.Where(indicator => indicator.DoorNum == doorNum).ToList();
            }
        }

        void ChangePlatform1(object sender, EventArgs e)
        {
            DoorsDataBinding.ItemsSource = items_1;
        }
        void ChangePlatform2(object sender, EventArgs e)
        {
            DoorsDataBinding.ItemsSource = items2_1;
        }

        void ChangePlatform3(object sender, EventArgs e)
        {
            DoorsDataBinding.ItemsSource = items3;
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
    }
}
