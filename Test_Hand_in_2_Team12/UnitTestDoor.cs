using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab_Class_Library;


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
        public void lockstate_is_false_after_running_unlockdoor_test()
        {
            uut.UnlockDoor();
            Assert.That(uut.lockState, Is.False);
        }

        [Test]
        public void Lockdoor_Is_true_after_running_Lockdoor_test()
        {
            uut.LockDoor();
            Assert.That(uut.lockState, Is.True);
        }


        [Test]
        public void Doorstate_is_true_when_OnDoorOpen_is_Called_test()
        {
            uut.OnDoorOpen();
            Assert.That(uut.doorState, Is.True);

        }
       
        [Test]
        public void Doorstate_is_false_when_Ondoorclosed_Is_Called()
        {
            uut.OnDoorClosed();
            Assert.That(uut.doorState, Is.False);
        
        }
        

    }
}
