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
        public void TurnOn()
        {

        }

        public void TurnOff()
        {

        }

        public bool RunSelfTest()
        {
            return true; 
        }
    }
}
