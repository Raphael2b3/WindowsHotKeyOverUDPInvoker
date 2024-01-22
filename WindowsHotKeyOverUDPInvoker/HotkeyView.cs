using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsHotKeyOverUDPInvoker.Models;

namespace WindowsHotKeyOverUDPInvoker
{
    public partial class HotkeyView : UserControl
    {
        private List<Keys> recordedKeys = new List<Keys>(); // List to store the recorded keys
        bool recording = false;

        public delegate void onDelete(HotKeyData data);
        public onDelete deleteCallback = (data) => { };

        HotKeyData hotkeyKeyData;

        public HotkeyView(HotKeyData data)
        {
            hotkeyKeyData = data;
            InitializeComponent();
            idtext.Text = data.id;
            recordkeylabel.Text = friendlyHotkeyName(data.action);


        }


        string friendlyHotkeyName(IEnumerable<Keys> keys)
        {
            string friendlyname = "";

            foreach (Keys keyname in keys)
            {
                // dont add + to the last key
                if (keyname == keys.Last())
                {
                    friendlyname += keyname;
                    break;
                }
                friendlyname += keyname + " + ";

            }
            return friendlyname;
        }

        // is this function called before the text is changed? the awnser is
        private void idtext_TextChanged(object sender, EventArgs e)
        {
            hotkeyKeyData.id = idtext.Text;
        }



        private void Form_KeyDown(object sender, KeyEventArgs e)
        {

            if (ActiveControl is Button)
            {
                var button = this.ActiveControl;
                button.Enabled = false;
                Application.DoEvents();
                button.Enabled = true;
                button.Focus();
            }

            Console.WriteLine("down " + e.KeyValue+" Recording "+recording);
            if (!recording) return;
            // Check if the pressed key is not already in the list

            Console.WriteLine("Is recording");
            if (!recordedKeys.Contains(e.KeyCode))
            {
                // Add the pressed key to the list
                recordedKeys.Add(e.KeyCode);
                Console.WriteLine("Added "+e.KeyCode+"to list");
                // Display or use the recorded keys as needed
                recordkeylabel.Text = friendlyHotkeyName(recordedKeys);
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {

            Console.WriteLine("up " + e.KeyValue+ " first "+ recordedKeys.First());
            if (!recording) return;
            if (recordedKeys.Count == 0) return;

            
            if (e.KeyCode == recordedKeys.First())
            {
                storeKeyCombination(null, null);
                return;
            }

            // Remove the released key from the list
            recordedKeys.Remove(e.KeyCode);

            // Display or use the recorded keys as needed
            recordkeylabel.Text = friendlyHotkeyName(recordedKeys);
        }

        private void storeKeyCombination(object sender, EventArgs e)
        {
            var keys = recordedKeys.ToArray();
            hotkeyKeyData.action = keys;
            hotkeyKeyData.actionString = friendlyHotkeyName(keys);
        }

        private void recordhotkey_Click(object sender, EventArgs e)
        {
            recordedKeys.Clear();
            recording = true;
            recordkeylabel.Text = "recording...";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            deleteCallback(hotkeyKeyData);

        }

        
    }
}
