using System;
using System.IO;
using Ladeskab_Class_Library;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using NUnit.Framework;


namespace Test_Hand_in_2_Team12
{
    public class UnitTestDisplay
    {

        IDisplay _uut;
        StringWriter stringwriter;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            stringwriter = new StringWriter();
            Console.SetOut(stringwriter);


        }

        [Test]
        public void viewCharging_test()
        {
            _uut.ViewCharging();
            Assert.AreEqual("Charging...\r\n", stringwriter.ToString());

        }
        [Test]
        public void viewDoneCharging_test()
        {
            _uut.ViewDoneCharging();
            Assert.AreEqual("Done charging. Remove phone. \r\n", stringwriter.ToString());

        }
        [Test]
        public void viewConnectPhone_test()
        {
            _uut.ViewConnectPhone();
            Assert.AreEqual("Connect phone\r\n", stringwriter.ToString());

        }
        [Test]
        public void viewFailedConnection_test()
        {
            _uut.ViewFailedConnection();
            Assert.AreEqual("Failed connecting. Charging is stopped.\r\n", stringwriter.ToString());

        }
        [Test]
        public void ViewReadID_test()
        {
            _uut.ViewReadID();
            Assert.AreEqual("Scan RFID\r\n", stringwriter.ToString());

        }
        [Test]
        public void ViewUnlock()
        {
            _uut.ViewUnlock();
            Assert.AreEqual("Box is locked. Scan RFID to unlock.\r\n", stringwriter.ToString());

        }
        [Test]
        public void ViewLockDoor()
        {
            _uut.ViewLockDoor();
            Assert.AreEqual("Door locked. Start Charging.\r\n", stringwriter.ToString());

        }
        [Test]
        public void ViewFailRFI()
        {
            _uut.ViewFailRFID();
            Assert.AreEqual("RFID failed!\r\n", stringwriter.ToString());

        }
        [Test]
        public void ViewRemovePhone()
        {
            _uut.ViewRemovePhone();
            Assert.AreEqual("Take phone and close the door.\r\n", stringwriter.ToString());

        }

    }
}