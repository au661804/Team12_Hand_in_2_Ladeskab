using System;

namespace Ladeskab_Class_Library
{
    public interface IChargeControl
    {
        void StartCharge();

        void StopCharge();

        bool Connected { get; set; }
    }
}
