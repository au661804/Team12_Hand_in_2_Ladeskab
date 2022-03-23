using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Team12_Hand_in_2_Ladeskab;

namespace Test_Hand_in_2_Team12
{
     class UnitTestDoor
    {
        DoorEventArgs DoorEventArgs;
        Door uut;

        [SetUp]
        public void Setup()
        {
            
            uut = new Door();

            DoorEventArgs = null;

        }

        [Test]
        public void DoorIsUnlocked_test()
        {
            uut.UnlockDoor();
            Assert.That(uut.lockState, Is.False);
            
        }

        [Test]
        public void IsDoorLocked_test()
        {
            uut.LockDoor();
            Assert.That(uut.lockState, Is.True);
        }
     
        [Test]
        public void isDoorChanged_test() //ændre navn
        {
            uut.OnDoorOpen();

            Assert.Multiple(() =>
            {
                Assert.That(DoorEventArgs, Is.Not.Null);
                Assert.That(uut.doorState, Is.True);

            });

        }
       

        [Test]
        public void isDoorOpen()
        {
            uut.OnDoorOpen();
            Assert.That(uut.doorState, Is.True);

        }
       
        [Test]
        public void isDoorClosed_test()
        {
            uut.OnDoorClosed();
            Assert.That(uut.doorState, Is.False);
        
        }

      
    }
}
