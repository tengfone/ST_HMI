using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_HMI.Models
{
    class DoorModel : INotifyPropertyChanged
    {
        public string DoorNum { get; set; }

        private string uri;
        public string URI
        {
            get { return this.uri; }
            set
            {
                if (this.uri != value)
                {
                    this.uri = value;
                    NotifyPropertyChanged("URI");
                }
            }
        }

        public string URI_I { get; set; }

        public string Visibility { get; set; }

        public List<AlarmsModel> alarmsList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

