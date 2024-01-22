using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHotKeyOverUDPInvoker.Models
{
    // generate a class that is json serializable
    [Serializable]
    public class AppSettings
    {
        public AppSettings(int port, string host)
        {
            this.port = port;
            this.host = host;
        }

        public int port { get; set; }
        public string host{ get; set; }
    }



    
}
