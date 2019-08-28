using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace L07
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //第一种 Mutex
            Mutex mutex = new Mutex(true,"单实例",out bool isCreatedNew);
            if (isCreatedNew==false)
            {
                //第二种
                IntPtr intPtr = FindWindowW(null, "MainWindow");
                if (intPtr!=IntPtr.Zero)
                {
                    SetForegroundWindow(intPtr);
                }
                Shutdown();
            }
        }
        //HWND FindWindowW(
        //    LPCWSTR lpClassName,
        //    LPCWSTR lpWindowName
        //);
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowW(string lpClassName, string lpWindowName);

        //BOOL SetForegroundWindow(
        //    HWND hWnd
        //);
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

    }
}
