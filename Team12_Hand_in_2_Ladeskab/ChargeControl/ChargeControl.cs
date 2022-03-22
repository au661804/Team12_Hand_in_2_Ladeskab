using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    class ChargeControl :IChargeControl
    {
        private IDisplay _display;
        private IUsbCharger _charger;
        public event EventHandler<CurrentEventArgs> USBEvent;
        public bool Connected { get;set; }

        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            _charger = charger;
            _display = display;
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

       
    }
}
