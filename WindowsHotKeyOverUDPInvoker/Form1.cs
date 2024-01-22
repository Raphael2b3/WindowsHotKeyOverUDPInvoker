using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsHotKeyOverUDPInvoker.Models;

namespace WindowsHotKeyOverUDPInvoker
{
    public partial class Form1 : Form
    {
        UDPServer server;

        AppSettings appSettings = StorageHandler.GetAppSettings();

        List<HotKeyData> hotkeys = StorageHandler.LoadHotkeysFromStorage();

        public Form1()
        {
            HotkeyInvoker.logCallback += (data) =>
            {
                logInUIThread(string.Format("From Key Invoker Callback: "+data));
            };
            InitializeComponent();

            server = new UDPServer(appSettings.port, appSettings.host);
            server.receivedDataCallback += (data) =>
            {
                Console.WriteLine(data);

                HotkeyInvoker.invokeKey(hotkeys, data);
                logInUIThread(
                    generateLog(data)
                );
            };

            server.stateChangedCallback += (is_running) =>
            {
                set_running_label(is_running);
            };
        }

        string generateLog(string data)
        {
            return string.Format("[{0}] Recieved {1}", DateTime.Now.ToString("HH:mm:ss"), data);
        }

        void logInUIThread(string data)
        {
            var action = new Action(() =>
            {
                logfield.AppendText(data + "\n");
                logfield.ScrollToCaret();
            });
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
        void createAndInsertHotkeyView(HotKeyData hdata)
        {

            var view = new HotkeyView(hdata);
            view.deleteCallback += (data) =>
            {
                hotkeys.Remove(data);
                hotkeylist.Controls.Remove(view);
            };

            hotkeylist.Controls.Add(view);
        }

        override protected void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (var hotkey in hotkeys)
            {
                createAndInsertHotkeyView(hotkey);
            }

            hostip.Text = appSettings.host;
            porttext.Text = appSettings.port.ToString();

            server.start();
        }

        private void addnewhotkey_Click(object sender, EventArgs e)
        {
            Console.WriteLine(hotkeylist.Controls.Count);
            var newdata = new HotKeyData("0", new[] { Keys.ControlKey, Keys.S }, "^(S)");

            hotkeys.Add(newdata);
            createAndInsertHotkeyView(newdata);
        }

        private void porttext_TextChanged(object sender, EventArgs e)
        {
            try
            {
                appSettings.port = Convert.ToInt32(porttext.Text);
            }
            catch (Exception)
            {
                porttext.Text = appSettings.port.ToString();
            }
        }

        private void hostip_TextChanged(object sender, EventArgs e)
        {
            appSettings.host = hostip.Text;

        }

        private void reload_server_Click(object sender, EventArgs e)
        {
            server.update(appSettings.host, appSettings.port);

        }

        private void set_running_label(bool running)
        {
            // to execute this function on the main thread 

            if (runningindic.InvokeRequired)
            {
                runningindic.Invoke(new Action(() => set_running_label(running)));
                return;
            }

            runningindic.Text = running ? "Running on " + gethostip : "Not running";
        }

        // get ipv4 address of host

        string gethostip
        {
            get
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "";
            }
        }


        private void save_Click(object sender, EventArgs e)
        {
            StorageHandler.SaveHotkeysToStorage(hotkeys);
            StorageHandler.SaveAppSettings(appSettings);

        }

        private void stop_Click(object sender, EventArgs e)
        {
            server.stop();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            server.stop();

            save_Click(null, null);
        }
    }
}
