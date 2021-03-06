using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab_Class_Library;
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
        public void startCharge_received_once_by_ChargeControl()
        {
            uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
            
        }
        
        [Test]
        public void StopCharge_received_once_by_ChargeControl()
        {
            uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
        }

        [Test]

        public void zero_StopCharge_received_StartCharge_sent()
        {
            uut.StartCharge();
            _usbCharger.Received(0).StopCharge();
        }

        [Test]
        public void zero_StartCharge_received_StopCharge_sent()
        {
            uut.StopCharge();
            _usbCharger.Received(0).StartCharge();
        }

        [Test]
        public void PhoneConnected_test()
        {
            _usbCharger.Connected.Returns(true);
            
            Assert.That(uut.PhoneConnected(), Is.True);
        }

        [Test]
        public void Connected_test()
        {
            uut.Connected = true;
            
            Assert.That(uut.Connected, Is.True);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void FullyChargedPhone_DisplayShowDoneCharging(int fullyCharged)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = fullyCharged });
            _display.Received(1).ViewDoneCharging();
        }

        [TestCase(-5)]
        [TestCase(100)]
        [TestCase(6)]
        public void FullyChargedPhone_DisplayShowDoneCharging_withIncorrectValues(int fullyCharged)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = fullyCharged });
            _display.Received(0).ViewDoneCharging();
        }
       
        [TestCase(6)]
        [TestCase(150)]
        [TestCase(500)]    
        public void PhoneCurrentlyCharging_withCorrectValues(int PhoneCharging)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = PhoneCharging });
            _display.Received(1).ViewCharging();
        }
       
        [TestCase(5)]
        [TestCase(501)]
        [TestCase(-10)]
        public void PhoneCurrentlyCharging_withInCorrectValues(int PhoneCharging)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = PhoneCharging });
            _display.Received(0).ViewCharging();
        }
        
        [TestCase(501)]
        [TestCase(1000)]
        public void ShortCircuit_withCorrectValues(int ShortCircuit)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = ShortCircuit });
            _display.Received(1).ViewFailedConnection();
        }
       
        [TestCase(500)]
        [TestCase(-10)]
        public void ShortCircuit_withInCorrectValues(int ShortCircuit)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = ShortCircuit });
            _display.Received(0).ViewFailedConnection();
        }
       
        [Test]
        public void IsConnectedWhenChargingStarts_ExpTrue()
        {
            _usbCharger.Connected.Returns(true);
            uut.StartCharge();
           

            Assert.That(uut.PhoneConnected, Is.EqualTo(true));
        }
        
        



    }

    
}
