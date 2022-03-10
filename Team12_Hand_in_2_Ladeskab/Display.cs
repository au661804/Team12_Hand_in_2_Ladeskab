using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Team12_Hand_in_2_Ladeskab
{
    class Display
    {
        private bool isConnected = false;
        private bool readRFID = false;

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

        public void ViewIsAvailable()
        {
            if (isConnected == true)
            {
                Console.WriteLine("Box is occupied");
            }
            else
            {
                Console.WriteLine("Box is available");
            }
            
        }

        public void ViewReadID()
        {
            Console.WriteLine("Scan RFID");
            if (readRFID == false)
            {
                Console.WriteLine("RFID failed");
            }
            else
            {
                Console.WriteLine("Door open");
            }
            
        }


        public void View()
        {}
    }
}
