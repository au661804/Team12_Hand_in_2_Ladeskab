using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    public interface IDisplay
    {
         void ViewCharge(int battery);


         void ViewAvailable();

         void ViewNotAvailable();


         void ViewReadID();


         void ViewLockDoor();

         void ViewFailRFID();
         void ViewRemovePhone();


    };
}

