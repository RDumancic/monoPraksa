using System;
using System.Collections.Generic;
using System.Text;

namespace day1App
{
    class CarClass : Vehicle
    {
        private string model;
        public CarClass ()
        {
            this.fuel = 250;
            this.model = "Not Specified";
        }

        public CarClass(int fuel)
        {
            this.fuel = fuel;
            this.model = "Not Specified";
        }

        public CarClass(int fuel, string model)
        {
            this.fuel = fuel;
            this.model = model;
        }

        public string Model
        {
            get { return this.model; }
        }

        public override int Fuel
        {
            get { return this.fuel; }
        }
        public override void Travel()
        {
            if(this.fuel < 50)
            {
                Console.WriteLine("You don't have enough fuel for travel");
            }else
            {
                this.fuel -= 50;
                Console.WriteLine("You traveled somewhere successfully");
            }
        }
    }
}
