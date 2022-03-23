﻿using NUnit.Framework;
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
        public void zero_StartCharge_received_StopCharge_sent()
        {
            uut.StopCharge();
            _usbCharger.Received(0).StartCharge();
        }

        public void PhoneConnected_test()
        {
            uut.PhoneConnected();
            Assert.That(uut.PhoneConnected, Is.True);
        }



    }

    
}
