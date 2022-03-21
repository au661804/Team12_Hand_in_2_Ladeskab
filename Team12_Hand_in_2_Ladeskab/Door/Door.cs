using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Team12_Hand_in_2_Ladeskab
{
    public class Door
    {
        public event EventHandler<DoorEventArgs> DoorStateHandleEvent;
        public bool doorState { get; private set; } 
        public bool lockState { get; private set; } 


        public Door()
        {
            doorState = false;
            lockState = false;
        }

        public void SetDoorState(bool newDoorState)
        {
            if (doorState != newDoorState)
            {
                doorState = newDoorState;
                OnDoorChanged(new DoorEventArgs() { isDoorOpen = newDoorState });

            }
        }

        public void SetLockDoor(bool newLock)
        {
            if (lockState != newLock)
            {
                lockState = newLock;
                OnDoorChanged(new DoorEventArgs() { isDoorLocked = newLock });

            }
        }

        public void UnlockDoor()
        {
           SetLockDoor(false);
        }

        public void LockDoor()
        {
            SetLockDoor(true);
        }

        private void OnDoorChanged(DoorEventArgs e)
        {
            DoorStateHandleEvent?.Invoke(this, e);
        }

        public void OnDoorOpen()
        {
            SetDoorState(true);

        }

        public void OnDoorClose()
        {
            SetDoorState(false);
        }

    }
}
