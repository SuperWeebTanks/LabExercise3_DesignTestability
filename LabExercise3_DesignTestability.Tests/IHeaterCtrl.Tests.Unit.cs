using System;
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
            TurnOnP = "Not Turned On";
            TurnOffP = "Not Turned Off";
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
            Assert.That(_FakeTestStringTurnOn, Is.EqualTo(_uut.TurnOnP));
        }

        [Test]
        public void TurnOff_CheckIfTurnOffIsCalled_StringEqualTrue()
        {
            _uut.TurnOff();
            Assert.That(_FakeTestStringTurnOff, Is.EqualTo(_uut.TurnOnP)); 
        }

        [Test]
        public void FakeHeaterConstructor_TestIfStringsSetCorrectly_StringsAreEqual()
        {
            FakeHeater _uut2 = new FakeHeater();
            var TurnOn_ = "Not Turned On";
            var TurnOff_ = "Not Turned Off"; 

            Assert.That(TurnOn_, Is.EqualTo(_uut2.TurnOnP));
            Assert.That(TurnOff_, Is.EqualTo(_uut2.TurnOffP));
        }
    }

    [TestFixture]
    class FakeHeaterNSubstituteTests
    {

    }
}
