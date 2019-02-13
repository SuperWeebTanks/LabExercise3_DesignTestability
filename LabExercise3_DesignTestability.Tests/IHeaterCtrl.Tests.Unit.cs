using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;

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
}
