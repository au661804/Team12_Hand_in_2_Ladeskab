using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    public class DoorEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public bool isOpen { set; get; }
    }

    public interface IDoor
    {
        // Event triggered on new door state
        event EventHandler<DoorEventArgs> doorStateEvent;

        // Direct access to the door state
        bool doorState { get; }

        void openDoor();

        void closeDoor();

    }
}
