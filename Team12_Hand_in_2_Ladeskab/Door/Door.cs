using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Team12_Hand_in_2_Ladeskab
{
    public class Door
    {
        public event EventHandler<DoorEventArgs> doorStateEvent;
        public bool doorState { get; private set; }
       
        private Display display;

        public Door()
        {
            doorState = false;

        }

        public void openDoor()
        {
            if (doorState == false )
            {
                display.ViewAvailable();
                doorState = true;
            
            
            OnDoorOpen(new DoorEventArgs() { isDoorOpen = doorState });

            }


        }

        public void closeDoor()
        {
            if (doorState == true)
            {
                display.ViewReadID();
            doorState = false;
           
            OnDoorClosed(new DoorEventArgs() {isDoorOpen = doorState});

            }

        }

        public void LockDoor()
        {
            display.ViewLockDoor();


        }

        public void UnlockDoor()
        {
            display.ViewReadID();
        }


        private void OnDoorOpen(DoorEventArgs e)
        {
            doorStateEvent?.Invoke(this, e);
        }

        private void OnDoorClosed(DoorEventArgs e)
        {
            doorStateEvent?.Invoke(this, e);
        }
    }
}
