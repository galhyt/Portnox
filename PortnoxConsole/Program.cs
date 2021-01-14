using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortnoxClassLib;

namespace PortnoxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SwitchCollection switch_coll = new SwitchCollection(NetworkEventsFactory.GetNetworkEvents());
        }
    }
}