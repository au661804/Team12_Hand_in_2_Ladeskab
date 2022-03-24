using System;
using Ladeskab_Class_Library;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using NUnit.Framework;


namespace Test_Hand_in_2_Team12
{
    public class UnitTestDisplay
    {
        StationControl _stationControl;
        IDisplay _uut;

        [SetUp]
        public void Setup()
        {
            _stationControl = Substitute.For<StationControl>();
            _uut = new Display();

        }

        //[TestCase("Charging..." )]
        //public void Test1(string line)
        //{
        //    _uut.ViewCharging();
            
        //    //Assert.That(_uut.ViewCharging, Is.EqualTo(line));
        //    _uut.Received(1).ViewCharging();

        //}
    }
}