using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    public class DoorEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public bool isDoorOpen { set; get; }

        public bool isDoorLocked { get; set; }
    }

    public interface IDoor
    {
        // Event triggered on new door state
        event EventHandler<DoorEventArgs> DoorStateHandleEvent;

        // Direct access to the door state
        bool doorState { get; set; }
        bool lockState { get; set; }

        void openDoor();

       
        void LockDoor();
        void UnlockDoor();

        void OnDoorOpen();
        void OnDoorClosed();


    }
}
