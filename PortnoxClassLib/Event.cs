using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortnoxClassLib
{
    public class SwitchEvent
    {
        public int Event_Id { get; set; }
        public string Switch_Ip {get; set;}

        public int Port_Id { get; set; }
        public string Device_Mac { get; set; }

        public SwitchEvent(DataRow dr)
        {
            Event_Id = Convert.ToInt32(dr["Event_Id"]);
            Switch_Ip = dr["Switch_Ip"].ToString();
            Port_Id = Convert.ToInt32(dr["Port_Id"]);
            Device_Mac = (dr["Device_Mac"] != DBNull.Value ? dr["Device_Mac"].ToString() : null);
        }

    }
}
