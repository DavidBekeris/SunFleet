using System;
using System.Collections.Generic;
using System.Text;

namespace Sunfleet.Domain
{
    class Truck : Vehicle
    {
        public Truck(string regNumber, string brand, string model, double capacity, TruckLift truckLift)
            :base(regNumber,brand,model)
        {
            Capacity = capacity;
            TruckLift = truckLift;
        }

        public double Capacity { get; }
        public TruckLift TruckLift { get; }
    }
}
