using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Team12_Hand_in_2_Ladeskab
{
    public class Display:IDisplay
    {
        private bool isConnected = false;
        

        public void ViewCharge(int battery)
        {
            if (isConnected == true)
            {
                Console.WriteLine(battery + "%");
            }
            else
            {
                Console.WriteLine("Error connecting phone - try again");
            }

        }

        public void ViewAvailable()
        {
            
                Console.WriteLine("Box is occupied");
              Console.WriteLine("Connect phone");
        }
        public void ViewNotAvailable()
        {
            Console.WriteLine("Failed connecting.");


        }

        public void ViewReadID()
        {
            Console.WriteLine("Scan RFID");

        }

        public void ViewLockDoor()
        {
            Console.WriteLine("Door locked");
        }

        public void ViewFailRFID()
        {
            Console.WriteLine("RFID failed!");


        }
        public void ViewRemovePhone()
        {
            Console.WriteLine("Remove phone.");

        }

    }
}
