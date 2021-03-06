using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab_Class_Library;


namespace Test_Hand_in_2_Team12
{
    public class UnitTestStationControl
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
            _chargeControl.Connected = true;

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

            _door.Received(1).LockDoor();
            

        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(0)]
        public void RFIDEventHasBeenCalled_DoorUnLocked(int id)
        {
            _door.doorState.Returns(false);
            _door.lockState.Returns(false);
            _chargeControl.Connected = true;
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id });
            
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id });

            _door.Received(1).UnlockDoor();

        }
        
        [TestCase(1,2)]
        public void RFIDEventHasBeenCalled_IDnotOldId(int id, int newid)
        {
            _door.doorState.Returns(false);
            _chargeControl.Connected = true;
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = id });
            _door.lockState.Returns(false);

            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = newid });

            _display.Received(1).ViewFailRFID();

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

            
            _logFile.Received(1).LogDoorLocked(id);

        }

        //Her forventes ikke at ske noget, da den skal breake
        [Test]
        public void RFIDEventHasBeenCalled__LadeskabState_DoorOpen()
        {
            _door.lockState = false;
            _door.doorState = false;
            
            _door.DoorStateHandleEvent += Raise.EventWith(new DoorEventArgs { isDoorOpen = true });

            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = 1 });
            
        }

        //Her forventes ikke at ske noget, da den skal breake
        [TestCase(true, true)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        public void RFIDEventHasBeenCalled__lockstate_doorstate(bool door, bool _lock)
        {
            _door.lockState = _lock;
            _door.doorState = door;
            
            _rFIDReader.RFIDHandleEvent += Raise.EventWith(new RFIDEventArgs { _ID = 1 });

        }
        

    }
}