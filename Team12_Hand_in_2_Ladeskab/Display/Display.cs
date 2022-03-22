using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Team12_Hand_in_2_Ladeskab
{
    public class Display : IDisplay
    {
        

        public void ViewCharge(int battery)
        {
            Console.WriteLine(battery + "%");
           
        }

        public void ViewConnectPhone()
        {
            Console.WriteLine("Connect phone");
        }
        public void ViewFailedConnection()
        {
            Console.WriteLine("Failed connecting.");


        }

        public void ViewReadID()
        {
            Console.WriteLine("Scan RFID");

        }

        public void ViewUnlock()
        {
            Console.WriteLine("Box is locked. Scan RFID to unlock.");

        }

        public void ViewLockDoor()
        {
            Console.WriteLine("Door locked. Start Charging.");
        }

        public void ViewFailRFID()
        {
            Console.WriteLine("RFID failed!");


        }
        public void ViewRemovePhone()
        {
            Console.WriteLine("Take phone and close the door.");

        }

        
    }
}
