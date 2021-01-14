using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortnoxClassLib
{
    public class Device
    {
        public string Device_Mac { get; set; }
        public List<SwitchEvent> events = new List<SwitchEvent>();

        public Device(string _Device_Mac, List<SwitchEvent> ls)
        {
            Device_Mac = _Device_Mac;
            events = ls;
        }
    }
}
