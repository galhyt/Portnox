using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortnoxClassLib
{
    public class NetworkEventsFactory
    {
        public static DataTable GetNetworkEvents(string type = "SqlServer")
        {
            switch (type)
            {
                default:
                case "SqlServer":
                    string ConnectionString = @"Server=DESKTOP-F8373R2\SQLEXPRESS; Database=Portnox; Integrated Security=True;";
                    SqlConnection Connection = new SqlConnection(ConnectionString);
                    Connection.Open();
                    try
                    {
                        SqlDataAdapter Data = new SqlDataAdapter("select * from Switch_Events order by Switch_Ip", Connection);
                        DataTable dt = new DataTable();
                        Data.Fill(dt);
                        Connection.Close();
                        return dt;
                    }
                    catch (Exception e) { }
                    break;
            }

            return null;
        }
    }
}

