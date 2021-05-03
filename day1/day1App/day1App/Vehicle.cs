using System;
using System.Collections.Generic;
using System.Text;

namespace day1App
{
    abstract class Vehicle
    {
        protected int fuel;
        public abstract int Fuel { get; }
        public abstract void Travel();
        public void TurnOffEngine()
        {
            Console.WriteLine("Engine is shutting down");
        }
    }
}
