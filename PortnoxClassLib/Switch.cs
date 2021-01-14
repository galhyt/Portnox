using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortnoxClassLib
{
    public class Switch : IEquatable<Switch>
    {
        public string Switch_Ip { get; set; }
        public List<Port> ports = new List<Port>();
        public List<SwitchEvent> events;

        public Switch(string _Switch_Ip, List<SwitchEvent> ls)
        {
            Switch_Ip = _Switch_Ip;
            events = ls;

            foreach (int port_id in ls.Select(evt => evt.Port_Id).Distinct())
            {
                ports.Add(new Port(port_id, ls.Where(evt => evt.Port_Id == port_id).ToList()));
            }
        }
        public bool Equals(Switch other)
        {
            return base.Equals(other);
        }
    }

    public class SwitchCollection : ICollection<Switch>
    {
        private List<Switch> _switches = new List<Switch>();

        public int Count => _switches.Count;

        public bool IsReadOnly => false;

        public SwitchCollection(DataTable dt)
        {
            GetNetworkEvents(dt);
        }

        private void GetNetworkEvents(DataTable dt)
        {
            Dictionary<string, List<SwitchEvent>> _switches_Evts_dict = new Dictionary<string, List<SwitchEvent>>();
            foreach (DataRow dr in dt.Rows)
            {
                string Switch_Ip = dr["Switch_Ip"].ToString();
                if (!_switches_Evts_dict.ContainsKey(Switch_Ip))
                    _switches_Evts_dict.Add(Switch_Ip, new List<SwitchEvent>());
                _switches_Evts_dict[Switch_Ip].Add(new SwitchEvent(dr));
            }

            foreach(var Switch_Ip in _switches_Evts_dict.Keys)
            {
                var ls = _switches_Evts_dict[Switch_Ip];
                Add(new Switch(Switch_Ip, ls));
            }
        }

        public Switch this[int index]
        {
            get { return _switches[index]; }
            set { _switches[index] = value; }
        }

        public void Add(Switch item)
        {
            _switches.Add(item);
        }

        public void Clear()
        {
            _switches.Clear();
        }

        public bool Contains(Switch item)
        {
            return _switches.Contains(item);
        }

        public void CopyTo(Switch[] array, int arrayIndex)
        {
            _switches.CopyTo(array);
        }

        public bool Remove(Switch item)
        {
            return _switches.Remove(item);
        }

        public IEnumerator<Switch> GetEnumerator()
        {
            return new SwitchEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SwitchEnumerator(this);
        }
    }

    public class SwitchEnumerator : IEnumerator<Switch>
    {
        private SwitchCollection _collection;
        private int curIndex = -1;
        private Switch curSwitch;
        public Switch Current => curSwitch;

        object IEnumerator.Current => curSwitch;

        public SwitchEnumerator(SwitchCollection coll)
        {
            _collection = coll;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            curIndex++;
            if (curIndex >= _collection.Count) return false;

            curSwitch = _collection[curIndex];
            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }
    }
}
