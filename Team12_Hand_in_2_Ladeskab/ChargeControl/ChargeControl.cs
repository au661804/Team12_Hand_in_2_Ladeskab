using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    class ChargeControl :IChargeControl
    {
        private IDisplay _display;

        private IUsbCharger _charger;



        

        public ChargeControl(IUsbCharger charger)
        {
            charger.CurrentValueEvent += HandleChargeChangedEvent;
        }

        private void HandleChargeChangedEvent(object sender, CurrentEventArgs e)
        {
            switch (e.Current)
            {


            }
        }

        public void StartCharge()
        {
            throw new NotImplementedException();
        }

        public void StopCharge()
        {
            throw new NotImplementedException();
        }

        public bool Connected()
        {
            throw new NotImplementedException();
        }
    }
}
