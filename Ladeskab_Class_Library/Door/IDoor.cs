using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab_Class_Library
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

     
        void UnlockDoor();
        void LockDoor();

        void OnDoorOpen();
        void OnDoorClosed();


    }
}
