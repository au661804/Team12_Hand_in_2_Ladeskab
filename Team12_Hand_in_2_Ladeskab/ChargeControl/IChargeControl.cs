using System;

namespace Team12_Hand_in_2_Ladeskab
{
    public interface IChargeControl
    {
        event EventHandler<CurrentEventArgs> USBEvent;

        void StartCharge();

        void StopCharge();

        bool Connected { get; set; }
    }
}
