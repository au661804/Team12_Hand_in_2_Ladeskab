using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab_Class_Library
{
    public interface IDisplay
    {
         void ViewCharging();
        void ViewDoneCharging();


         void ViewConnectPhone();

         void ViewFailedConnection();


         void ViewReadID();


         void ViewLockDoor();

         void ViewUnlock();

         void ViewFailRFID();
         void ViewRemovePhone();


    };
}

