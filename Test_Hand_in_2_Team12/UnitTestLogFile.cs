using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Team12_Hand_in_2_Ladeskab;

namespace Test_Hand_in_2_Team12
{
     class UnitTestLogFile
    {
        StationControl _stationControl;
        Door _uut;

        [SetUp]
        public void Setup()
        {
            _stationControl=Substitute.For<StationControl>();
            _uut = new Door();

        }

        [Test]
        public void Test1()
        {
            
        }
    }
}
