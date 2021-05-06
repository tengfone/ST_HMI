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

namespace ST_HMI
{
    /// <summary>
    /// Interaction logic for PSDPopup.xaml
    /// </summary>
    /// 
    public partial class PSDPopup : Window
    {
        public PSDPopup(string value)
        {
            InitializeComponent();
            List<Alarms> alarms = new List<Alarms>();
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "WARN", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "WARN", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarms.Add(new Alarms() { date = "<ON>    02-08 17:27:07    PSD DSI  FAILURE", alarmType = "GOOD", actionRequired = "Immediate action required by Administrator" });
            alarmsDataGrid.ItemsSource = alarms;
        }
    }
}
