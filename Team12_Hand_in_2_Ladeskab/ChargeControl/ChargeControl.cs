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
        double CurrentNow { get; set; }
        double StopLadestroem = 5;
        double NormalLadestroem = 500;

        public bool Connected { get;set; }

        private enum ChargerState
        {
            Charging,
            DoneCharging         
        };

        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            _charger = charger;
            _display = display;
            _charger.CurrentValueEvent += HandleChargeChangedEvent;
        }

        private void HandleChargeChangedEvent(object sender, CurrentEventArgs e)
        {
            CurrentNow = e.Current;

            switch (CurrentNow) //hvorfor skal vi have en switch?
            {
                case <= 0:
                    break;
                case <= StopLadestroem:
                    {
                        _display.ViewDoneCharging();
                    }
                    break;
                case <= NormalLadestroem:
                    {
                        _display.ViewCharging();
                    }
                case > NormalLadestroem:
                    {
                        _display.ViewFailedConnection();
                    }


            }
        }
        

        public void StartCharge()
        {
            _charger.StartCharge();
        }
       

        public void StopCharge()
        {
            _charger.StopCharge();
        }

        public bool PhoneConnected()
        {
            return _charger.Connected;
        }

       
    }
}
