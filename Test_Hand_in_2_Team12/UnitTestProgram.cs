using NSubstitute;
using NUnit.Framework;
using System;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Team12_Hand_in_2_Ladeskab;

namespace Test_Hand_in_2_Team12
{
    public class UnitTestProgram
    {
        bool finish = false;
        private IDoor _door;
        private IRFIDReader _rfidReader;
        private USBCharger _charger;
        private IDisplay _display;
        private LogFile _logFile;
        private IChargeControl _chargecontrol;
        private Program _uut;
        private string ExpectedInput;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _rfidReader = Substitute.For<IRFIDReader>();
            _door = Substitute.For<IDoor>();
            _chargecontrol = Substitute.For<IChargeControl>();
            _logFile = Substitute.For<LogFile>();
            _chargecontrol = new ChargeControl(_charger, _display);
        }


        // Hvordan kan man teste et user input?
        //[Test]
        //public void Test1()
        //{
        //    TextReader input;
        //    input = new StringReader("o");
        //    Console.SetIn(input);
        //    Program.Main();

        //    Assert.That(Program.Main(), Is.);

        //    _door.Received(1).OnDoorOpen();
        //}
    }
    
}