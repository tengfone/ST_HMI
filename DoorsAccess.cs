using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ST_HMI
{
    class DoorsAccess
    {
        string[] doorImgs = new string[] { "PSD1", "PSD2", "PSD3", "PSD4", "PSD5" };


        public List<Models.DoorModel> GetDoors()
        {
            List<Models.DoorModel> doorsOutput = new List<Models.DoorModel>();
            for (int i = 0; i < doorImgs.Length; i++)
            {
                Models.DoorModel output = new Models.DoorModel();
                output.DoorNum = doorImgs[i];
                doorsOutput.Add(output);
            }

            return doorsOutput;
        }
    }
}
