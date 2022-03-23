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


        //[Test]
        //public void startCharge_Test()
        //{
        //   uut.StartCharge();

        [Test]
        public void StopCharge_Test()
        {
            uut.StopCharge();
            Assert.That(uut.StopCharge, Is.True);
        }
        [Test]
        public void PhoneConnected_test()
        {
            uut.PhoneConnected();
            Assert.That(uut.PhoneConnected, Is.True);
        }



    }

    
}
