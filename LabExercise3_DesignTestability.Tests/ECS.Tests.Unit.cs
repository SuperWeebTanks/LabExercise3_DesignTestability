﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;
using NSubstitute;
using NUnit.Framework;

namespace LabExercise3_DesignTestability.Tests
{
    [TestFixture]
    class NSubstituteTests
    {
        private IHeaterCtrl _heater;
        private ISensorCtrl _sensor;
        private ECS.Legacy.ECS _uut;

          [SetUp]
          public void Setup()
          {
              _heater = Substitute.For<IHeaterCtrl>();
              _sensor = Substitute.For<ISensorCtrl>();

              _uut = new ECS.Legacy.ECS(20, _heater, _sensor);
          }

        [Test]
        public void Regulate_TempUnderThreshold_HeaterDoesNotTurnOff()
        {
            _sensor.GetTemp().Returns(_uut.GetThreshold() - 10);
            _uut.Regulate();
            _heater.DidNotReceive().TurnOff();
        }
          [Test]
          public void Regulate_TempBelowThreshold_HeaterTurnOn()
          {
              _sensor.GetTemp().Returns(_uut.GetThreshold() - 10); 
              _uut.Regulate();
              _heater.Received(1).TurnOn();
          }

        [Test]
        public void Regulate_TempOverThreshold_HeaterDoesNotTurnOn()
        {
            _sensor.GetTemp().Returns(_uut.GetThreshold() + 10);
            _uut.Regulate();
            _heater.DidNotReceive().TurnOn();
        }
          [Test]
          public void Regulate_TempAboveThreshold_HeaterTurnOff()
          {
              _sensor.GetTemp().Returns(_uut.GetThreshold()); 
              _uut.Regulate();
              _heater.Received(1).TurnOff();
          }

        [Test]
        public void Regulate_TempUnderThreshold_HeaterTurnOn3times()
        {
            _sensor.GetTemp().Returns(_uut.GetThreshold() - 10);
            _uut.Regulate();
            _sensor.GetTemp().Returns(_uut.GetThreshold() - 5);
            _uut.Regulate();
            _sensor.GetTemp().Returns(_uut.GetThreshold() - 2);
            _uut.Regulate();
            _heater.Received(3).TurnOn();
        }

          [Test]
          public void ECS_InitHeaterAndSensor_HeaterAndSensorInit()
          {
              var _uut = new ECS.Legacy.ECS(10, _heater, _sensor);
              _uut._heater.Received(1);
              _uut._tempSensor.Received(1); 
          }

          [TestCase(10)]
          [TestCase(0)]
          [TestCase(-10)]
        public void ECS_GetCurTemp_(int a)
          {
              _sensor.GetTemp().Returns(a);
              Assert.That(_uut.GetCurTemp(), Is.EqualTo(a));

          }

          [TestCase(10)]
          [TestCase(0)]
          [TestCase(-10)]
        public void ECS_setAndGetThreshold(int a)
          {
              _uut.SetThreshold(a);
              Assert.That(_uut.GetThreshold(), Is.EqualTo(a));
          }

        [Test]
        public void ECS_SetThreshold_ArgumentUnderOrEqualToMinus20_Exception()
        {
            Assert.Throws<Exception>(()=>_uut.SetThreshold(-20));
        }
    }
}
