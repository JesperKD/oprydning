using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace oprydning
{
    public class logic
    {
        public static void ShowCPU()
        {
            foreach (ManagementObject obj in DataLayer.GetCPU().Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine(name + " : " + usage);
                Console.WriteLine("CPU");
            }

        }

        public static void ShowDiskMetadata()
        {
            foreach (ManagementObject managementObject in DataLayer.GetDiskMetadata())
            {
                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());

                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());

                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());

                Console.WriteLine("---------------------------------------------------");
            }
        }

        public static void ShowMainStorage()
        {
            foreach (ManagementObject result in DataLayer.GetMainStorage())
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
        }

        public static void ProcessSearch() 
        {
            Console.WriteLine("process søgning");
            LISTAllServices();
        }

        private static void LISTAllServices()
        {
            Console.WriteLine("There are {0} Windows services: ", DataLayer.GetAllServices().Count);

            foreach (ManagementObject windowsService in DataLayer.GetAllServices())
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }

        public static string ShowSerial()
        {
            string temp = DataLayer.GetHardDiskSerialNumber();
            return temp;
        }
    }
}
