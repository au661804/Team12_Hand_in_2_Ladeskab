﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    class USBCharger : IUsbCharger
    {
        public double CurrentValue => throw new NotImplementedException();

        public bool Connected => throw new NotImplementedException();

        public event EventHandler<CurrentEventArgs> CurrentValueEvent;

        public void StartCharge()
        {
            throw new NotImplementedException();
        }

        public void StopCharge()
        {
            throw new NotImplementedException();
        }
    }
}
