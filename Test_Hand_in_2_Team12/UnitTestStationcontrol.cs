using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Team12_Hand_in_2_Ladeskab;

namespace Test_Hand_in_2_Team12
{
    public class Tests
    {
        IDisplay _display;
        IChargeControl uut;
        IUsbCharger _usbCharger;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
            uut = new ChargeControl(_display, _usbCharger);

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }