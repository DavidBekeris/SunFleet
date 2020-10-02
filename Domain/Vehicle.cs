using System;
using System.Collections.Generic;
using System.Text;

namespace Sunfleet.Domain
{
    class Vehicle
    {
        public Vehicle(string regNumber, string brand, string model)
        {
            RegNumber = regNumber;
            Brand = brand;
            Model = model;
        }

        public string RegNumber { get; }
        public string Brand { get; }
        public string Model { get; }
    }
}
