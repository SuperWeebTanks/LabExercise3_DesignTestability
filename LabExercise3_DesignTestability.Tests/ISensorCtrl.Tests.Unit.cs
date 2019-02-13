using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;

namespace LabExercise3_DesignTestability.Tests
{
    class FakeSensor : ISensorCtrl
    {
        public int GetTemp()
        {
            return 0;
        }

        public bool RunSelfTest()
        {
            return true; 
        }
    }
}
