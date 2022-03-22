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

        [TestCase (false)]
        public void DoorEventHasBeenCalled_DoorClosed(bool door)
        {
            _door.DoorStateHandleEvent += Raise.EventWith(new DoorEventArgs { isDoorOpen = door });

            _display.Received(1).ViewReadID();
        }
        [TestCase(true)]
        public void DoorEventHasBeenCalled_DoorOpen(bool door)
        {
            _door.DoorStateHandleEvent += Raise.EventWith(new DoorEventArgs { isDoorOpen = door });

            _display.Received(1).ViewConnectPhone();
        }
    }
}