using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_HMI.Models
{
    class DoorModel
    {
        public string DoorNum { get; set; }
        public string URI { get; set; }
        public string URI_I { get; set; }
        public List<AlarmsModel> alarmsList { get; set; }

    }
}

