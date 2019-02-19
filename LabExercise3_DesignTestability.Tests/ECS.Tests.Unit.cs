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

          [SetUp]
          public void Setup()
          {
              IHeaterCtrl _heater = Substitute.For<IHeaterCtrl>();
              ISensorCtrl _sensor = Substitute.For<ISensorCtrl>();

              var _uut = new ECS.Legacy.ECS(20, _heater, _sensor);
          }

      }
    }
}
