using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab_Class_Library;


namespace Test_Hand_in_2_Team12
{
    public class UnitTestRFIDReader
    {
        private IRFIDReader _uut;
        private RFIDEventArgs _eventArgs;

        [SetUp]
        public void Setup()
        {
           
            _uut = new rfidReader();
             _eventArgs = null;
            

            _uut.RFIDHandleEvent +=
                (sender, args) =>
                {
                    _eventArgs = args;
                };

        }

        [Test]
        public void noEventRaised_expNoReceived()
        {
            Assert.That(_eventArgs, Is.Null);
        }

        [Test]
        public void oneEventRaised_expOneReceivedNotNull()
        {
            _uut.RFIDValue(23);
            Assert.That(_eventArgs._ID, Is.Not.Null);     
        }

        [Test]
        public void oneEventRaised_expOneReceived1()
        {
            _uut.RFIDValue(23);
            Assert.That(_eventArgs._ID,Is.EqualTo(23));
           
        }

        
    }
}
