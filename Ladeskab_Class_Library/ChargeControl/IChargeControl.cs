using System;

namespace Ladeskab_Class_Library
{
    public interface IChargeControl
    {
        event EventHandler<CurrentEventArgs> USBEvent;

        void StartCharge();

        void StopCharge();

        bool Connected { get; set; }
    }
}
