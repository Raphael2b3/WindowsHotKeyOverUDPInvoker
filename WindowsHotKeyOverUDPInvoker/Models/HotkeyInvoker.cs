using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;
using WindowsInput;
using System.Runtime.Remoting.Messaging;

namespace WindowsHotKeyOverUDPInvoker.Models
{
    internal class HotkeyInvoker
    {

        static InputSimulator sim = new InputSimulator();

        static public Action<string> logCallback = (_) => { };
        public static void invokeKey(IEnumerable<HotKeyData> list, string id)
        {
            foreach (HotKeyData data in list)
            {
                if (data.id == id)
                {
                    logCallback("Found hotkey for " + id);
                    performHotkey(data);
                }
            }
        }

        public static void performHotkey(HotKeyData data)
        {

            /*
          0 None
          10 LineFeed
          65535 KeyCode
          65536 Shift
          131072 Control
          262144 Alt
          -65536 Modifiers
          */

            logCallback("Performing Hotkey for" + data);
            IEnumerable<VirtualKeyCode> actions = data.action.Select((key) =>
            {
                switch (key)
                {
                    case Keys.None: return VirtualKeyCode.NONAME;
                    case Keys.KeyCode: return VirtualKeyCode.NONAME;
                    case Keys.LineFeed: return VirtualKeyCode.NONAME;
                    case Keys.Modifiers: return VirtualKeyCode.NONAME;
                    case Keys.ShiftKey: return VirtualKeyCode.SHIFT;
                    case Keys.ControlKey: return VirtualKeyCode.CONTROL;
                    case Keys.Alt: return VirtualKeyCode.MENU;
                    default: return (VirtualKeyCode)key;
                }

            });
            try
            {
                foreach (VirtualKeyCode key in actions)
                {

                    sim.Keyboard.KeyDown(key);
                    logCallback("Keydown: " + key);
                }

                foreach (VirtualKeyCode key in actions)
                {
                    sim.Keyboard.KeyUp(key);

                    logCallback("Keyup: " + key);
                }
            }
            catch (Exception e)
            {
                logCallback("Error while performing hotkey: " + e.Message);
            }
        }
    }
}
