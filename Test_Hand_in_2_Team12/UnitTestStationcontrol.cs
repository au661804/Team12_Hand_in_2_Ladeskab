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
        StationControl _uut;
        IDoor _door;
        IRFIDReader _rFIDReader;
        IChargeControl _chargeControl;
        LogFile _logFile;



        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _rFIDReader = Substitute.For<IRFIDReader>();
            _door = Substitute.For<IDoor>();
            _chargeControl = Substitute.For<IChargeControl>();
            _logFile = Substitute.For<LogFile>();
            _uut = new StationControl(_rFIDReader, _door, _display, _chargeControl, _logFile);

        }

        [TestCase(false)]
        public void DoorEventHasBeenCalled_DoorClosed(bool door)
        {
            _door.DoorStateHandleEvent += Raise.EventWith(new DoorEventArgs {isDoorOpen = door});

            _display.Received(1).ViewReadID();
        }

        [TestCase(true)]
        public void DoorEventHasBeenCalled_DoorOpen(bool door)
        {
            _door.DoorStateHandleEvent += Raise.EventWith(new DoorEventArgs {isDoorOpen = door});

            _display.Received(1).ViewConnectPhone();
        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(0)]
        public void RFIDEventHasBeenCalled_DoorLocked(int id)
        {
            _door.lockState = false;
            _door.doorState = false;
            _chargeControl.Connected = true;
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs {_ID = id});

            _display.Received(1).ViewLockDoor();

        }

       [Test]
        public void RFIDEventHasBeenCalled_DoorUnLocked(int id)
        {

            _chargeControl.Connected.Returns(true);
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id });
            _door.lockState.Returns(true);

            _door.Received(1).UnlockDoor();

        }



        [TestCase(1)]
        [TestCase(33)]
        [TestCase(0)]
        public void RFIDEventHasBeenCalled__StartCharge_is_Called(int id)
        {
            _door.lockState = false;
            _door.doorState = false;
            _chargeControl.Connected = true;
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id});

            _chargeControl.Received(1).StartCharge();

        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(0)]
        public void RFIDEventHasBeenCalled__FailedConnection(int id)
        {
            _door.lockState = false;
            _door.doorState = false;
            _chargeControl.Connected = false;
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id });

            _display.Received(1).ViewFailedConnection();
            

        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(0)]
        public void RFIDEventHasBeenCalled__LogID_is_Called(int id)
        {
            _door.lockState = false;
            _door.doorState = false;
            _chargeControl.Connected = true;
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id });

            //_display.Received(1).ViewLockDoor();
            _logFile.Received(1).LogDoorLocked(id);

        }
    }
}