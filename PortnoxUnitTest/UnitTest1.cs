using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using PortnoxClassLib;

namespace PortnoxUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataTable dt = GetMockDataTable();
            SwitchCollection coll = new SwitchCollection(dt);

            Assert.AreEqual(6, dt.Rows.Count, "rows count suppose to be 6!");
            Assert.AreEqual(3, coll.Count, string.Format("Number of total switches is {0}, but expected 3!", coll.Count));
            Assert.AreEqual(3, coll[0].ports.Count, string.Format("Number of ports for Switch 192.168.1.1 is {0}, but expected 3!", coll[0].ports.Count));
        }

        private DataTable GetMockDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Event_Id", typeof(int)),
                new DataColumn("Switch_Ip", typeof(string)),
                new DataColumn("Port_Id", typeof(int)),
                new DataColumn("Device_Mac", typeof(string))
            });

            List<dynamic> ls = new List<dynamic>
            {
                new {Device_Mac="AABBCC000001", Event_Id=1001, Port_Id=10, Switch_Ip="192.168.1.1"},
                new {Device_Mac="AABBCC000004", Event_Id=1003, Port_Id=14, Switch_Ip="192.168.1.2"},
                new {Device_Mac="AABBCC000002", Event_Id=1002, Port_Id=80, Switch_Ip="192.168.1.1"},
                new {Device_Mac="AABBCC000001", Event_Id=1001, Port_Id=15, Switch_Ip="192.168.1.3"},
                new {Device_Mac="AABBCC000003", Event_Id=1003, Port_Id=10, Switch_Ip="192.168.1.2"},
                new {Device_Mac="AABBCC000002", Event_Id=1002, Port_Id=11, Switch_Ip="192.168.1.1"},
            };

            foreach (dynamic obj in ls)
            {
                var dr = dt.NewRow();
                dr["Switch_Ip"] = obj.Switch_Ip;
                dr["Event_Id"] = obj.Event_Id;
                dr["Port_Id"] = obj.Port_Id;
                dr["Device_Mac"] = obj.Device_Mac;

                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
