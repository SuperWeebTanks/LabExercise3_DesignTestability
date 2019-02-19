using System;
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
              IHeaterCtrl _heater = Substitute.For<IHeaterCtrl>();
              ISensorCtrl _sensor = Substitute.For<ISensorCtrl>();

              var _uut = new ECS.Legacy.ECS(20, _heater, _sensor);
          }

          [Test]
          public void 


      }
    }
}
