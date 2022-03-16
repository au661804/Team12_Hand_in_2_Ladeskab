using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
     class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDHandleEvent;

        private USBCharger charger;
        private int OldId;
        private Door _door;
        private Display display;
        private LogFile _log;

        public void RFIDdetected(int id)
        {
            if (charger.Connected == true)
            {
                OldId = id;
                _door.LockDoor();
                charger.StartCharge();
                display.ViewAvailable();
                _log.LogDoorLocked(id);
            }
            else if (id != OldId)
            {
                display.ViewFailRFID();
            }
            else if (charger.Connected == false)
            {
                display.ViewNotAvailable();
            }
            else if (OldId == id)
            {
                charger.StopCharge();
                _door.UnlockDoor();
                _log.LogDoorUnlocked(id);
                display.ViewRemovePhone();
                
            }
           
        }
    }
}
