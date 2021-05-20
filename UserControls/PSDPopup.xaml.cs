using ST_HMI.Models;
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
using System.Windows.Threading;

namespace ST_HMI
{
    /// <summary>
    /// Interaction logic for PSDPopup.xaml
    /// </summary>
    /// 
    public partial class PSDPopup : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Send);
        DoorModel doorModel_1 = new DoorModel() { path = "../Assets/Animation/fd1.png" };
        DoorModel doorModel_2 = new DoorModel() { path = "../Assets/Animation/fd2.png" };
        DoorModel doorModel_3 = new DoorModel() { path = "../Assets/Animation/fd3.png" };
        DoorModel doorModel_4 = new DoorModel() { path = "../Assets/Animation/fd4.png" };
        DoorModel doorModel_5 = new DoorModel() { path = "../Assets/Animation/fd5.png" };
        int door_animation = 1;

        public PSDPopup()
        {
            InitializeComponent();
            List<AlarmsModel> alarms = new List<AlarmsModel>();
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "WARN", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "WARN", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new AlarmsModel() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarmsDataGrid.ItemsSource = alarms;

            dispatcherTimer.Tick += Animation;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();

            DoorsDataBinding.SetBinding(Image.SourceProperty, new Binding("path")
            {
                Source = doorModel_1
            });
        }

        class DoorModel
        {
            public string path { get; set; }
        }

        private void Animation(object sender, EventArgs e)
        {
            
            if (door_animation == 1)
            {
                DoorsDataBinding.SetBinding(Image.SourceProperty, new Binding("path")
                {
                    Source = doorModel_2
                });
                door_animation = 2;
            }
            else if (door_animation == 2)
            {
                DoorsDataBinding.SetBinding(Image.SourceProperty, new Binding("path")
                {
                    Source = doorModel_3
                });
                door_animation = 3;
            }
            else if (door_animation == 3)
            {
                DoorsDataBinding.SetBinding(Image.SourceProperty, new Binding("path")
                {
                    Source = doorModel_4
                });
                door_animation = 4;
            }
            else if (door_animation == 4)
            {
                DoorsDataBinding.SetBinding(Image.SourceProperty, new Binding("path")
                {
                    Source = doorModel_5
                });
                door_animation = 5;
            }
            else if (door_animation == 5)
            {
                DoorsDataBinding.SetBinding(Image.SourceProperty, new Binding("path")
                {
                    Source = doorModel_1
                });
                door_animation = 1;
            }
        }

        DoorModel doorModel = new DoorModel(){ path = "../Assets/Animation/fd3.png"};


    }


}
