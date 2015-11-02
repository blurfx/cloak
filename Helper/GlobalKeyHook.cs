using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;


namespace Cloak.Helper
{
    public class GlobalKeyHook
    {
        Cloaker cloaker = new Cloaker();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYDOWN = 0x0100;

        private static IntPtr _hookID = IntPtr.Zero;

        private static LowLevelKeyboardProc proc = HookCallback;

        public void SetHook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public bool UnHook()
        {
            return UnhookWindowsHookEx(_hookID);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((vkCode >= 49 && vkCode <= 57) && Keys.Alt == Control.ModifierKeys)
                {
                    Regex rgx = new Regex("[^0-9]");
                    Cloaker.SetWindowTransparent(Convert.ToInt32(rgx.Replace(((Keys)vkCode).ToString(), "")));
                }
                else if (vkCode == 192 && Keys.Alt == Control.ModifierKeys)
                {
                    uint pid;
                    GetWindowThreadProcessId(GetForegroundWindow(), out pid);
                    Process p = Process.GetProcessById((int)pid);
                    

                    MessageBox.Show(String.Format("{0}\nprocess name : {1}.exe",p.MainWindowTitle,p.ProcessName),"Current Focused Window");
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}