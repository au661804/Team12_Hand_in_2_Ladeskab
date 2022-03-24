using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab_Class_Library;


namespace Test_Hand_in_2_Team12
{
    class UnitTestRFIDReader
    {
        private IRFIDReader _uut;



        [SetUp]
        public void Setup()
        {
            _uut = new rfidReader();
        }
        //}

        //[TestCase(2)]
        //[TestCase(22)]
        //[TestCase(222)]
        //public void Test1(int id)
        //{

        //    Assert.That(RFIDEventArgs, Is.GreaterThan(4));

        //}
    }
}
