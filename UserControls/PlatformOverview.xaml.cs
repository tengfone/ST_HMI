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

        // platform 1
        ObservableCollection<DoorModel> psdCollection1 = new ObservableCollection<DoorModel>();
        PlatformStatusModel platformStatusModel1 = new PlatformStatusModel();

        //platform 2
        ObservableCollection<DoorModel> psdCollection2 = new ObservableCollection<DoorModel>();
        PlatformStatusModel platformStatusModel2 = new PlatformStatusModel();

        List<AlarmsModel> alarmsGeneric = new List<AlarmsModel>(); 
        List<OverviewModel> platformValues;


        int platformStatusCounter = 0;
        int summaryValuesCounter = 0;

        DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Send);
        DispatcherTimer platformStatusTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };


        Boolean REMOVE_PSD = false;

        int CURRENT_PLATFORM = 1;

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

            // PLATFORM ONE
            platformStatusModel1 = new PlatformStatusModel() { cLStatus = "Live", inputStatus = "-", signalingStatus = "Healthy" };
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection1.Add(new DoorModel() { DoorNum = "PSD5", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            platforms.Add(1, new PlatformModel() { platformStatuses = platformStatusModel1, psdCollection = psdCollection1 });

            // PLATFORM TWO
            platformStatusModel2 = new PlatformStatusModel() { cLStatus = "Live", inputStatus = "-", signalingStatus = "Healthy" };
            psdCollection2.Add(new DoorModel() { DoorNum = "PSD1", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection2.Add(new DoorModel() { DoorNum = "PSD2", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection2.Add(new DoorModel() { DoorNum = "PSD3", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            psdCollection2.Add(new DoorModel() { DoorNum = "PSD4", URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric, Visibility = "Visible" });
            
            platforms.Add(2, new PlatformModel() { platformStatuses = platformStatusModel2, psdCollection = psdCollection2 });

            platformValues = new List<OverviewModel>();
            platformValues.Add(new OverviewModel() { titleLabel = "Doors Failed to Open/close", valueLabel = "1" });
            platformValues.Add(new OverviewModel() { titleLabel = "Platform Voltage", valueLabel = "80V" });
            titleLabel.Content = platformValues[0].titleLabel;
            valueLabel.Content = platformValues[0].valueLabel;

            // platform 1 itemsource bidning
            DoorsDataBinding.ItemsSource = platforms[1].psdCollection;
            IndicatorsDataBinding.ItemsSource = platforms[1].psdCollection;

            // platform 2 itemsource bidning
            IndicatorsDataBinding2.ItemsSource = platforms[2].psdCollection;

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
            ObservableCollection<DoorModel> doorItems = (ObservableCollection<DoorModel>)DoorsDataBinding.ItemsSource;

            /* Platform 1 door animation*/
            if (doorItems == psdCollection1)
            {
                if (doorItems[1].URI == "../Assets/Animation/fd1.png")
                {
                    foreach (var doorModel in platforms[1].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd2.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd2.png")
                {
                    foreach (var doorModel in platforms[1].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd3.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd3.png")
                {
                    foreach (var doorModel in platforms[1].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd4.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd4.png")
                {
                    foreach (var doorModel in platforms[1].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd5.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd5.png")
                {
                    foreach (var doorModel in platforms[1].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd1.png";
                    }
                }
            }else if (doorItems == psdCollection2)
            {
                /* Platform 2 door animation*/
                if (doorItems[1].URI == "../Assets/Animation/fd5.png")
                {
                    foreach (var doorModel in platforms[2].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd4.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd4.png")
                {
                    foreach (var doorModel in platforms[2].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd3.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd3.png")
                {
                    foreach (var doorModel in platforms[2].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd2.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd2.png")
                {
                    foreach (var doorModel in platforms[2].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd1.png";
                    }
                }
                else if (doorItems[1].URI == "../Assets/Animation/fd1.png")
                {
                    foreach (var doorModel in platforms[2].psdCollection)
                    {
                        doorModel.URI = "../Assets/Animation/fd5.png";
                    }
                }
            }


        }

        void Add_PSD(object sender, EventArgs e)
        {
            if (REMOVE_PSD)
            {
                ObservableCollection<DoorModel> doorItems = (ObservableCollection<DoorModel>)DoorsDataBinding.ItemsSource;
                System.Diagnostics.Debug.Write(doorItems.Count());
                if (CURRENT_PLATFORM == 1)
                {
                    String doorNum_temp = ((Button)sender).Tag.ToString();
                    char c = doorNum_temp.Last();
                    int num = (int)Char.GetNumericValue(c);
                    string doorNum = "NEW_PSD" + (num + 1).ToString();

                    psdCollection1.Insert(num, new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
                }
                else if (CURRENT_PLATFORM == 2)
                {
                    String doorNum_temp = ((Button)sender).Tag.ToString();
                    char c = doorNum_temp.Last();
                    int num = (int)Char.GetNumericValue(c);
                    string doorNum = "NEW_PSD" + (num + 1).ToString();

                    psdCollection2.Insert(num, new DoorModel() { DoorNum = doorNum, URI = "../Assets/Animation/fd1.png", URI_I = "../Assets/PSD_fullheight.png", alarmsList = alarmsGeneric });
                }
            }
        }

        void Remove_PSD(object sender, EventArgs e)
        {
            string doorNum = ((Button)sender).Tag.ToString();

            System.Diagnostics.Debug.WriteLine("trying to remove door");

            if (REMOVE_PSD)
            {
                ObservableCollection<DoorModel> doorItems = (ObservableCollection<DoorModel>)DoorsDataBinding.ItemsSource;
                if (CURRENT_PLATFORM == 1)
                {
                    foreach (var doorModel in psdCollection1.Where(item => item.DoorNum == doorNum).ToArray()) psdCollection1.Remove(doorModel);
                }
                else if (CURRENT_PLATFORM == 2)
                {
                    foreach (var doorModel in psdCollection2.Where(item => item.DoorNum == doorNum).ToArray()) psdCollection2.Remove(doorModel);
                }
            }
        }

        void Edit_mode(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Edit Mode");
            System.Diagnostics.Debug.WriteLine(psdCollection1[1].Visibility);

            foreach (var doorModel in psdCollection1)
            {
                doorModel.Visibility = "Visible";
            }
            System.Diagnostics.Debug.WriteLine(psdCollection1[1].Visibility);
            btn_editPSD.Visibility = Visibility.Hidden;
            btn_UneditPSD.Visibility = Visibility.Visible;
            REMOVE_PSD = !REMOVE_PSD;
        }

        void UnEdit_mode(object sender, RoutedEventArgs e)
        {
            foreach (var doorModel in psdCollection1)
            {
                doorModel.Visibility = "Hidden";
            }
            btn_UneditPSD.Visibility = Visibility.Hidden;
            btn_editPSD.Visibility = Visibility.Visible;
            REMOVE_PSD = !REMOVE_PSD;
        }

        void ChangePlatform1(object sender, EventArgs e)
        {
            CURRENT_PLATFORM = 1;
            DoorsDataBinding.ItemsSource = psdCollection1;
        }
        void ChangePlatform2(object sender, EventArgs e)
        {
            CURRENT_PLATFORM = 2;
            DoorsDataBinding.ItemsSource = psdCollection2;
        }

        void ChangePlatform3(object sender, EventArgs e)
        {
            
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
