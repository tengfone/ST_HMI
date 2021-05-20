using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST_HMI.Models
{
    class PlatformModel
    { 
        public PlatformStatusModel platformStatuses { get; set; }
        public Dictionary<int, DoorModel> psdDict { get; set; }
    }
}
