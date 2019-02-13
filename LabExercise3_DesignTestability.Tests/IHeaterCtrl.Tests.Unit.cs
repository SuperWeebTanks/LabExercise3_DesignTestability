﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;
using NUnit.Framework;

namespace LabExercise3_DesignTestability.Tests
{
    class FakeHeater : IHeaterCtrl
    {
        public string TurnOnP { get; private set; }
        public string TurnOffP { get; private set; }

        public FakeHeater()
        {
            TurnOnP = "Not turned On";
            TurnOffP = "Not turned Off";
        }
        public void TurnOn()
        {
            TurnOnP = "Fake Turn On";
        }

        public void TurnOff()
        {
            TurnOnP = "Fake Turn Off";
        }

        public bool RunSelfTest()
        {
            return true; 
        }

        
    }

    [TestFixture]
    class FakeHeaterTests
    {
        private string _FakeTestStringTurnOn { get; set; }
        private string _FakeTestStringTurnOff { get; set; }
        private readonly FakeHeater _uut = new FakeHeater(); 

        [SetUp]
        public void Setup()
        {
            _FakeTestStringTurnOn = "Fake Turn On";
            _FakeTestStringTurnOff = "Fake Turn Off"; 
        }

        [Test]
        public void RunSelfTest_RunSelfTestSuccess_ReturnTrue()
        {
            Assert.That(_uut.RunSelfTest, Is.EqualTo(true)); 
        }

        [Test]
        public void TurnOn_CheckIfTurnOnIsCalled_StringEqualTrue()
        {
            _uut.TurnOn();
            //Assert.That(_FakeTestStringTurnOn, Is.Equal(_uut.TurnOn_));
        }

        [Test]
        public void TurnOff_CheckIfTurnOffIsCalled_StringEqualTrue()
        {
            _uut.TurnOff();
            //Assert.That(_FakeTestStringTurnOff, Is.Equal(_uut.TurnOn_)); 
        }

    }
}
