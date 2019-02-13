using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;

namespace LabExercise3_DesignTestability.Tests
{
    class FakeSensor : ISensorCtrl
    {
        public int Temp { get; set; } = 0;

        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true; 
        }
    }

    [TestFixture]
    public class ECSSensorTests
    {
        private FakeSensor myFakeSensor;
        [SetUp]
        public void Setup()
        {
            myFakeSensor = new FakeSensor();
        }

        [Test]
        public void FakeSensor_RunSelfTest_ReturnsTrue()
        {
            bool result = myFakeSensor.RunSelfTest();
            Assert.True(result);
        }

        [Test]
        public void FakeSensor_GetTemp_ReturnsZero()
        {
            int result = myFakeSensor.GetTemp();
            Assert.That(result,Is.EqualTo(0));
        }

        [Test]
        public void FakeSensor_SettingTemp_EqualTo20()
        {
            myFakeSensor.Temp = 20;
            int result = myFakeSensor.GetTemp();
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void FakeSensor_SettingTemp_EqualTo0()
        {
            myFakeSensor.Temp = 0;
            int result = myFakeSensor.GetTemp();
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
