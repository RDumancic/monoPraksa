using System;
using System.Collections.Generic;
using System.Text;

namespace day1App
{
    class GarageClass<T>
    {
        List<T> vehicles = new List<T>();

        public void AddVehicle(T data)
        {
            vehicles.Add(data);
        }

        public void ListVehicles()
        {
            foreach(T data in vehicles)
            {
                Console.WriteLine(data);
            }
        }
    }
}
