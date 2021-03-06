﻿namespace ECS.Legacy
{
    public interface IHeaterCtrl
    {
        void TurnOn();
        void TurnOff();
        bool RunSelfTest(); 

    }

    public class Heater : IHeaterCtrl
    {
        public void TurnOn()
        {
            System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}