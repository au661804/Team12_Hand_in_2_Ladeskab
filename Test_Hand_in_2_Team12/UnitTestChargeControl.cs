using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Team12_Hand_in_2_Ladeskab;
using NSubstitute;

namespace Test_Hand_in_2_Team12
{
     public class UnitTestChargeControl
    {
        IDisplay _display;
        ChargeControl uut;
        IUsbCharger _usbCharger;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
             uut = new ChargeControl(_usbCharger, _display);
        }

        [Test]
        public void startCharge_sent_once_Test()
        {
            uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
            
        }

        [Test]
        public void StopCharge_sent_once_startCharget()
        {
            uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
           

        }
        [Test]
        public void StartCharge_sent_twice()
        {
            uut.StartCharge();
            uut.StartCharge();
            _usbCharger.Received(2).StartCharge();
        }
        [Test]
        public void StopCharge_sent_twice()
        {
            uut.StopCharge();
            uut.StopCharge();
            _usbCharger.Received(2).StopCharge();
        }
        
        




    }

    
}
