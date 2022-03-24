using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;


namespace Ladeskab_Class_Library
{
    public class Display : IDisplay
    {
        

        public void ViewCharging()
        {
            Console.WriteLine("Charging...");
           
        }
        public void ViewDoneCharging()
        {
            Console.WriteLine("Done charging. Remove phone. ");

        }

        public void ViewConnectPhone()
        {
            Console.WriteLine("Connect phone");
        }
        public void ViewFailedConnection()
        {
            Console.WriteLine("Failed connecting. Charging is stopped.");


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
