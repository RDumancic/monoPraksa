using System;
using System.Collections.Generic;
using System.Text;

namespace day1App
{
    class PlaneClass : Vehicle, IFlyable
    {
        private int numberDesignation;
        public PlaneClass()
        {
            this.fuel = 2500;
            this.numberDesignation = 0;
        }

        public PlaneClass(int fuel)
        {
            this.fuel = fuel;
            this.numberDesignation = 0;
        }

        public PlaneClass(int fuel, int num)
        {
            this.fuel = fuel;
            this.numberDesignation = num;
        }

        public override int Fuel
        {
            get { return this.fuel; }
        }

        public int NumberDesignation
        {
            get { return this.numberDesignation; }
        }
        public override void Travel()
        {
            if (this.fuel < 250)
            {
                Console.WriteLine("You don't have enough fuel for travel");
            }else
            {
                this.fuel -= 250;
                Console.WriteLine("You traveled somewhere successfully");
            }
        }

        public void BarrelRoll()
        {
            Console.WriteLine("You barrel roll mid air");
        }
    }
}
