namespace Sunfleet.Domain
{
    class Car : Vehicle
    {
        public Car(string regNumber, string brand, string model, CarType carType, AutoPilot autoPilot)
            : base(regNumber, brand, model)
        {
            CarType = carType;
            AutoPilot = autoPilot;
        }

        public CarType CarType { get; }
        public AutoPilot AutoPilot { get; }
    }
}
