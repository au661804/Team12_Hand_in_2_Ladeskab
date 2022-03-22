
using System;
using System.Collections.Generic;
using System.Text;
using Team12_Hand_in_2_Ladeskab;

namespace Team12_Hand_in_2_Ladeskab
{
    public class ChargeControl :IChargeControl
    {
        private IDisplay _display;
        private IUsbCharger _charger;
        public event EventHandler<CurrentEventArgs> USBEvent;
        double CurrentNow { get; set; }
        double StopLadestroem = 5;
        double NormalLadestroem = 500;
        double Kortslutning = 501;

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
                case <= 5: //StopLadestroem
                    {
                        _display.ViewDoneCharging();
                    }
                    break;
                case <= 500: //NormalLadestroem
                    {
                        _display.ViewCharging();
                    }
                    break;
                case >= 501: //Kortslutning
                    
                        _display.ViewFailedConnection();
                    
                   break;

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
