using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortnoxClassLib
{
    public class Port
    {
        public int port_id { get; set; }
        public List<Device> devices = new List<Device>();
        public List<SwitchEvent> events { get; set; }

        public Port(int _port_id, List<SwitchEvent> ls)
        {
            port_id = _port_id;
            events = ls;

            foreach (string Device_Mac in events.Select(evt=>evt.Device_Mac).Distinct())
            {
                var device_ls = events.Where(evt => evt.Device_Mac == Device_Mac).ToList();
                devices.Add(new Device(Device_Mac, device_ls));
            }
        }
    }
}
