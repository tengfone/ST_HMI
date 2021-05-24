using ST_HMI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        // need to work on this
        Dictionary<int, PlatformModel> platforms = new Dictionary<int, PlatformModel>();

        ObservableCollection<DoorModel> psdCollection1 = new ObservableCollection<DoorModel>();
        PlatformStatusModel platformStatusModel1 = new PlatformStatusModel();
        List<AlarmsModel> alarmsGeneric = new List<AlarmsModel>(); 

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
        List<OverviewModel> platformValues;

        List<DoorIndicator> indicators = new List<DoorIndicator>();
        List<DoorIndicator> indicators2 = new List<DoorIndicator>();
        List<DoorIndicator> indicators3 = new List<DoorIndicator>();

        int platformStatusCounter = 0;
        int summaryValuesCounter = 0;
        int doorAnimationCounter = 1;

        DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Send);
        DispatcherTimer platformStatusTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };


        Boolean REMOVE_PSD = false;

        public PlatformOverview()
        {
            InitializeComponent();

            platformStatusTimer.Tick += new EventHandler(platform_status_change);
            platformStatusTimer.Start();

            // Placeholder for alarms 
            alarmsGeneric.Add(new AlarmsModel { date = "<ON>    03-08 16:27:07    PSD DSI  SUCCESS", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarmsGeneric.Add(new AlarmsModel { date = "<OFF>    02-03 15:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarmsGeneric.Add(new AlarmsModel { date = "<ON>    01-01 14:27:07    PSD DSI  SUCCESS", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarmsGeneric.Add(new AlarmsModel { date = "<OFF>    01-08 13:22:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarmsGeneric.Add(new AlarmsModel { date = "<ON>    01-08 12:27:07    PSD DSI  SUCCESS", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });

            // ONE PLATFORM
            platformStatusModel1 = new PlatformStatusModel() { cLStatus = "Live", inputStatus = "-", signalingStatus = "Healthy" };
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
            platforms.Add(1, new PlatformModel() { platformStatuses = platformStatusModel1, psdCollection = psdCollection1 });



       

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
            indicators.Add(new DoorIndicator() { DoorNum = "PSD1", URI = "../Assets/PSD_fullheight.png", Visibility = "Collapsed" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD2", URI = "../Assets/PSD_fullheight.png", Visibility = "Collapsed" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD3", URI = "../Assets/PSD_fullheight.png", Visibility = "Collapsed" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD4", URI = "../Assets/PSD_fullheight.png", Visibility = "Collapsed" });
            indicators.Add(new DoorIndicator() { DoorNum = "PSD5", URI = "../Assets/PSD_fullheight.png", Visibility = "Collapsed" });

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

            platformValues = new List<OverviewModel>();
            platformValues.Add(new OverviewModel() { titleLabel = "Doors Failed to Open/close", valueLabel = "1" });
            platformValues.Add(new OverviewModel() { titleLabel = "Platform Voltage", valueLabel = "80V" });
            titleLabel.Content = platformValues[0].titleLabel;
            valueLabel.Content = platformValues[0].valueLabel;

            DoorsDataBinding.ItemsSource = platforms[1].psdCollection;
            IndicatorsDataBinding.ItemsSource = platforms[1].psdCollection;


            IndicatorsDataBinding2.ItemsSource = indicators2;
            IndicatorsDataBinding3.ItemsSource = indicators3;

            dispatcherTimer.Tick += Animation;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();

            // Initialize for Counter
            backbtn.IsEnabled = false;
        }

        private void platform_status_change(object sender, EventArgs e)
        {
            // should create platform class array 
            if (platformStatusCounter == 0)
            {
                foreach (KeyValuePair<int, PlatformModel> platformT in platforms)
                {
                    platform1StatusTitle.Content = "Signalling Status";
                    platform2StatusTitle.Content = "Signalling Status";
                    platform3StatusTitle.Content = "Signalling Status";

                    platform1StatusContent.Content = platformT.Value.platformStatuses.signalingStatus;
                    platform2StatusContent.Content = platformT.Value.platformStatuses.signalingStatus;
                    platform3StatusContent.Content = platformT.Value.platformStatuses.signalingStatus;

                }
                platformStatusCounter++;

            }
            else if (platformStatusCounter == 1)
            {
                foreach (var platformT in platforms)
                {
                    platform1StatusTitle.Content = "C & L Status";
                    platform2StatusTitle.Content = "C & L Status";
                    platform3StatusTitle.Content = "C & L Status";

                    platform1StatusContent.Content = platformT.Value.platformStatuses.cLStatus;
                    platform2StatusContent.Content = platformT.Value.platformStatuses.cLStatus;
                    platform3StatusContent.Content = platformT.Value.platformStatuses.cLStatus;

                }
                platformStatusCounter++;
            }
            else if (platformStatusCounter == 2)
            {
                foreach (var platformT in platforms)
                {
                    platform1StatusTitle.Content = "Input Status";
                    platform2StatusTitle.Content = "Input Status";
                    platform3StatusTitle.Content = "Input Status";

                    platform1StatusContent.Content = platformT.Value.platformStatuses.inputStatus;
                    platform2StatusContent.Content = platformT.Value.platformStatuses.inputStatus;
                    platform3StatusContent.Content = platformT.Value.platformStatuses.inputStatus;

                }
                platformStatusCounter = 0;
            }
          
        }


        private void PSDPopup_click(object sender, MouseButtonEventArgs e)
        {
            if (!REMOVE_PSD)
            {
                PSDPopup psdPopupWindow = new PSDPopup();
                string psdDoor = ((Image)sender).Tag.ToString();
                psdPopupWindow.psdSubTitlePopup.Text = psdDoor;
                string doorNum = psdDoor.Substring(3);
                psdPopupWindow.psdTitlePopup.Text = $"Door {doorNum} - South Bound";
                // psdPopupWindow.alarmsDataGrid.ItemsSource = 
                psdPopupWindow.Show();
            }
        }

        private void Animation(object sender, EventArgs e)
        {
           /*Dictionary<int, DoorModel> dict = DoorsDataBinding.ItemsSource as Dictionary<int, DoorModel>;*/
            //System.Diagnostics.Debug.WriteLine(platforms[1].psdCollection.);
            /* Platform 1 door animation*/
            if (doorAnimationCounter == 1)
            {
                foreach (var doorModel in platforms[1].psdCollection)
                {
                    doorModel.URI = "../Assets/Animation/fd2.png";
                }
                doorAnimationCounter++;
            } else if (doorAnimationCounter == 2)
            {
                foreach (var doorModel in platforms[1].psdCollection)
                {
                    doorModel.URI = "../Assets/Animation/fd3.png";
                }
                doorAnimationCounter++;
            }
            else if (doorAnimationCounter == 3)
            {
                foreach (var doorModel in platforms[1].psdCollection)
                {
                    doorModel.URI = "../Assets/Animation/fd4.png";
                }
                doorAnimationCounter++;
            }
            else if (doorAnimationCounter == 4)
            {
                foreach (var doorModel in platforms[1].psdCollection)
                {
                    doorModel.URI = "../Assets/Animation/fd5.png";
                }
                doorAnimationCounter++;
            }
            else if (doorAnimationCounter == 5)
            {
                foreach (var doorModel in platforms[1].psdCollection)
                {
                    doorModel.URI = "../Assets/Animation/fd1.png";
                }
                doorAnimationCounter = 1;
            }

            /*Dictionary<int, DoorModel> dict = DoorsDataBinding.ItemsSource as Dictionary<int, DoorModel>;
            System.Diagnostics.Debug.WriteLine(dict[1].URI);
            if (dict[1].URI == "../Assets/Animation/fd1.png")
            {
                platforms[1].psdDict[1].URI = "../Assets/Animation/fd2.png";
                DoorsDataBinding.ItemsSource = platforms[1].psdDict;
            }
            else if (dict[1].URI == "../Assets/Animation/fd2.png")
            {
                platforms[1].psdDict[1].URI = "../Assets/Animation/fd3.png";
                DoorsDataBinding.ItemsSource = platforms[1].psdDict;
            }
            else if (dict[1].URI == "../Assets/Animation/fd3.png")
            {
                platforms[1].psdDict[1].URI = "../Assets/Animation/fd4.png";
                DoorsDataBinding.ItemsSource = platforms[1].psdDict;
            }
            else if (dict[1].URI == "../Assets/Animation/fd4.png")
            {
                platforms[1].psdDict[1].URI = "../Assets/Animation/fd5.png";
                DoorsDataBinding.ItemsSource = platforms[1].psdDict;
            }
            else if (dict[1].URI == "../Assets/Animation/fd5.png")
            {
                platforms[1].psdDict[1].URI = "../Assets/Animation/fd1.png";
                DoorsDataBinding.ItemsSource = platforms[1].psdDict;
            }*/
        }

        class DoorIndicator
        {
            public string DoorNum { get; set; }
            public string URI { get; set; }

            public string Visibility { get; set; }
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

        void Edit_mode(object sender, RoutedEventArgs e)
        {
            foreach (var i in indicators)
            {
                i.Visibility = "Visible";
            }
            btn_editPSD.Visibility = Visibility.Hidden;
            btn_addPSD.Visibility = Visibility.Visible;
            btn_removePSD.Visibility = Visibility.Visible;
            btn_UneditPSD.Visibility = Visibility.Visible;
            REMOVE_PSD = !REMOVE_PSD;
        }

        void UnEdit_mode(object sender, RoutedEventArgs e)
        {
            btn_UneditPSD.Visibility = Visibility.Hidden;
            btn_editPSD.Visibility = Visibility.Visible;
            btn_addPSD.Visibility = Visibility.Hidden;
            btn_removePSD.Visibility = Visibility.Collapsed;
            REMOVE_PSD = !REMOVE_PSD;
        }

        void Remove_PSD(object sender, EventArgs e)
        {
            string doorNum = "";

            System.Diagnostics.Debug.WriteLine("trying to remove door");
            if (sender is TextBlock)
            {
                doorNum = ((TextBlock)sender).Text;
            }else if (sender is Button)
            {
                doorNum = ((Button)sender).Tag.ToString();
            }

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
