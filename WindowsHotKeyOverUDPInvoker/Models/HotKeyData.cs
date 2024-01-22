using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHotKeyOverUDPInvoker.Models
{
    // generate a class that is json serializable
    [Serializable]
    public class HotKeyData
    {
        public HotKeyData(string id, Keys[] action, string actionString)
        {
            this.id = id;
            this.action = action;
            this.actionString = actionString;
        }

        public string id { get; set; }
        public Keys[] action { get; set; }
        public string actionString { get; set; }

        override public string ToString()
        {
            return string.Format("HotKeyData: id={0}, action={1}, actionString={2}", id, action, actionString);
        }
    }
}

