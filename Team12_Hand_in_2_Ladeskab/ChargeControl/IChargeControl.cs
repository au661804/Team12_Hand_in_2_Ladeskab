using System;

public interface IChargeControl
{
    void StartCharge();

    void StopCharge();

    bool Connected();
}
