using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace oprydning
{
    class Program
    {
        static void Main(string[] args)
        {
            logic.ShowDiskMetadata();
            logic.ShowSerial();
            logic.ShowCPU();
            logic.ShowMainStorage();
            logic.ProcessSearch();


            Console.ReadKey();
        } 
    }
}
