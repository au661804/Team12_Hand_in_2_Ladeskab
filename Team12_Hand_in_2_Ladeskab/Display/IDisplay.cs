using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
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

