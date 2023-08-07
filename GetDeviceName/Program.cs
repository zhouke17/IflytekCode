using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace GetDeviceName
{
    class Program
    {
        static void Main(string[] args)
        {
            bool res = getDevice();
            Console.WriteLine($"是否包含Finger Module USB Device设备：{res}");
            Console.Read();
        }
        public static bool getDevice()
        {
            StringBuilder sbDwv = new StringBuilder();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM win32_PnPEntity");
            foreach (ManagementObject mgt in searcher.Get())
            {
               if( Convert.ToString(mgt["Name"]).Contains("Finger Module USB Device"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
