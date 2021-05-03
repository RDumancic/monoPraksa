using System;

namespace day1App
{
    class Program
    {
        static void Main(string[] args)
        {
            CarClass subaru = new CarClass();
            Console.WriteLine(subaru.Fuel);
            subaru.Travel();
            Console.WriteLine(subaru.Fuel);

            CarClass mitsubishi = new CarClass(47,"Mitsubishi");
            Console.WriteLine(mitsubishi.Fuel);
            mitsubishi.Travel();
            mitsubishi.TurnOffEngine();

            GarageClass<string> carGarage = new GarageClass<string>();
            carGarage.AddVehicle(mitsubishi.Model);
            carGarage.AddVehicle(subaru.Model);
            carGarage.ListVehicles();

            PlaneClass mig = new PlaneClass(1000, 21);
            mig.BarrelRoll();
            mig.Travel();
            Console.WriteLine(mig.Fuel);

            GarageClass<int> planeGarage = new GarageClass<int>();
            planeGarage.AddVehicle(mig.NumberDesignation);
            planeGarage.ListVehicles();

            MiG mig21 = new MiG();
            mig21.Patrol();
        }
    }
}
