using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHotKeyOverUDPInvoker.Models
{
    internal class UDPServer
    {

        // the server should be able to be started with a port and a host name

        public UDPServer(int port, string hostname )
        {
            this.hostname = hostname;
            this.port = port;
        }
        public string hostname { get; set; }
        public int port { get; set; }
        public bool Isrunning { get => isrunning; set { 
                if (isrunning != value) { 
                    
                    stateChangedCallback(value); 
                }
                
                
                isrunning = value; } }

        bool isrunning = false;
        private UdpClient server;
        

        // callback function to handle the received data

        public delegate void ReceivedDataCallback(string data);

        public ReceivedDataCallback receivedDataCallback = (_) => { } ;

        public delegate void StateChangedCallback(bool state);

        public StateChangedCallback stateChangedCallback = (_) => { };

        public void start()
        {
            Isrunning = true;

            server = new UdpClient(port);
            Task.Run(() => _start());
            
        }

        void _start()
        {
         
            var groupEP = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(hostname), port);

            try
            {
                while (Isrunning)
                {
                    Console.WriteLine("Waiting for broadcast");
                    var bytes = server.Receive(ref groupEP);
                    string returnData = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    receivedDataCallback(returnData);
                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    Console.WriteLine($"DATA {returnData}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                stop();
            }

            


        }

        public void update(string hostname, int port)
        {
            this.hostname = hostname;
            this.port = port;
            if (Isrunning)
            {
                stop();
            }
            start();
        }   


        public void stop()
        {
            Isrunning = false;

            server.Close();
        }
    }
}
