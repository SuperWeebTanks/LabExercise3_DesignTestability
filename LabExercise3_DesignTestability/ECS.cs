﻿using System.ComponentModel;

namespace ECS.Legacy
{
    public class ECS
    {
        private int _threshold;
        public ISensorCtrl _tempSensor { get; private set; }
        public IHeaterCtrl _heater { get; private set; }

        public ECS(int thr, IHeaterCtrl heater, ISensorCtrl tempSensor) //Constructor injection
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
