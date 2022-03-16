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
                display.ViewIsAvailable();
                doorState = true;
            
            
            OnNewDoor(new DoorEventArgs() { isDoorOpen = doorState });

            }


        }

        public void closeDoor()
        {
            if (doorState == true)
            {
                display.ViewReadID();
            doorState = false;
           
            OnNewDoor(new DoorEventArgs() {isDoorOpen = doorState});

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


        private void OnNewDoor(DoorEventArgs e)
        {
            doorStateEvent?.Invoke(this, e);
        }
    }
}
