using System;
using System.Text.RegularExpressions;

namespace Sunfleet.Domain
{
    abstract class Vehicle
    {
        public Vehicle(string regNumber, string brand, string model)
        {
            this.RegNumber = regNumber;
            this.Brand = brand;
            this.Model = model;
        }

        public string RegNumber
        {
            get { return regNumber; }
            set{
                Regex regNumberRegex = new Regex(@"^\w{3}\d{3}$");
                if (!regNumberRegex.IsMatch(value))
                {
                    throw new ArgumentException("Invalid registration number. (abc123)");
                }
                regNumber = value;
            }
        }

        public string Brand
        {
            get { return brand; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter brand cannot be empty.");
                }
                else
                {
                    brand = value;
                }
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Parameter model cannot be empty.");
                }
                else
                {
                    model = value;
                }
            }
        }

        private string regNumber;
        private string model;
        private string brand;
    }
}
