using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHotKeyOverUDPInvoker.Models
{
    internal class StorageHandler
    {

        static public List<HotKeyData> LoadHotkeysFromStorage()
        {
            var hotkeys = new List<HotKeyData>();


            if (!System.IO.File.Exists("hotkeys.json"))
            {
                SaveHotkeysToStorage(hotkeys= new List<HotKeyData>());
                return hotkeys;
            }

            var json = System.IO.File.ReadAllText("hotkeys.json");

            var hotkeydata = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, HotKeyData>>(json);
            
            foreach (var data in hotkeydata)
            {
                hotkeys.Add(new HotKeyData(id: data.Value.id, action: data.Value.action, actionString: data.Value.actionString));
            }

            return hotkeys;

        }

        static public void SaveHotkeysToStorage(List<HotKeyData> hotkeys)
        {
            var hotkeydata = new Dictionary<int, HotKeyData> ();

            var i = 0; 
            foreach (var hotkey in hotkeys)
            {
                Console.WriteLine("Saving " +
                    "Hotkey to storage" + hotkey.id);
                hotkeydata.Add( i , hotkey);
                i++;
            }

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(hotkeydata);
            System.IO.File.WriteAllText("hotkeys.json", json);
        }


        static public AppSettings GetAppSettings()
        {

            Dictionary<string, dynamic> data;

            if (!System.IO.File.Exists("settings.json"))
            {
                var s = new AppSettings(port: 5001, host: "0.0.0.0");
                SaveAppSettings(s);
                return s;
            }

            var json = System.IO.File.ReadAllText("settings.json");

            data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);


            // to fix this code write a custom json deserializer
            Console.WriteLine(data["port"]);
            return new AppSettings(port: Convert.ToInt32(data["port"]), host: data["host"]);

        }

        static public void SaveAppSettings(AppSettings settings)
        {
            var data = new Dictionary<string, dynamic> { { "port", settings.port }, { "host", settings.host } };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText("settings.json", json);
        }

    }
}
