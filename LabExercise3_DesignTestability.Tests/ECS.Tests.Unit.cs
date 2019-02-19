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
          public void Regulate_TempBelowThreshold_HeaterTurnOn()
          {
              _sensor.GetTemp().Returns(_uut.GetThreshold() - 10); 
              _uut.Regulate();
              _heater.Received(1).TurnOn();
          }

          [Test]
          public void Regulate_TempAboveThreshold_HeaterTurnOff()
          {
              _sensor.GetTemp().Returns(_uut.GetThreshold()); 
              _uut.Regulate();
              _heater.Received(1).TurnOff();
          }

          [Test]
          public void ECS_InitHeaterAndSensor_HeaterAndSensorInit()
          {
              var _uut = new ECS.Legacy.ECS(10, _heater, _sensor);
              _uut._heater.Received(1);
              _uut._tempSensor.Received(1); 
          }
    }
}
