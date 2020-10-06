using Sunfleet.Domain;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Sunfleet
{
    class Program
    {
        static Dictionary<string, Vehicle> vehicleDictionary = new Dictionary<string, Vehicle>();
        static void Main(string[] args)
        {
            bool invalidInput = false;
            ConsoleKeyInfo menuChoice;
            string correctUserName = ""; // TODO: Add back values for hardcoded login
            string correctUserPassword = "";
            string userNameInput;
            string userPasswordInput;
            bool notLoggedIn = true;
            bool insideMenu = true;

            Console.WriteLine("Welcome to the vehicle manager.");
            Console.WriteLine("You need to log in to access the menu. Press any key to continue..");
            Console.CursorVisible = false;
            Console.ReadKey(true); // Just to get the user to continue to log in.
            Console.CursorVisible = true;

            while (notLoggedIn)
            {
                Console.Clear();

                Console.Write("Username: \nPassword: ");

                Console.CursorTop--;

                userNameInput = Console.ReadLine();

                Console.SetCursorPosition(10, 1);

                userPasswordInput = Console.ReadLine();

                if (userNameInput == correctUserName && userPasswordInput == correctUserPassword)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("You've successfully logged in.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.CursorVisible = true;
                    notLoggedIn = false;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.Clear();
                    Console.WriteLine("Access denied! Incorrect password or username.");
                    Thread.Sleep(2000);
                    Console.CursorVisible = true;
                }
            }

            while (insideMenu)
            {
                Console.Clear();
                Console.WriteLine("Press the respective number from the menu to enter.\n");
                Console.WriteLine("1. Add vehicle");
                Console.WriteLine("2. Search vehicle");
                Console.WriteLine("3. Remove vehicle"); // TODO: Frivillig, göra om jag hinner. Place holder for now.
                Console.WriteLine("9. Log out");

                do
                {
                    menuChoice = Console.ReadKey(true);

                    invalidInput = !(
                               menuChoice.Key == ConsoleKey.D1
                            || menuChoice.Key == ConsoleKey.D2
                            || menuChoice.Key == ConsoleKey.D3
                            || menuChoice.Key == ConsoleKey.D9);

                } while (invalidInput);

                switch (menuChoice.Key)
                {
                    case ConsoleKey.D1: // Add vehicle, wich leads to another switch case to choose from Car || truck

                        ShowSubMenuCarOrTruck();
                        break;

                    case ConsoleKey.D2: // Search Vehicle

                        SearchVehicle();

                        break;

                    case ConsoleKey.D3: // Remove vehicle, place holder

                        RemoveVehicle();

                        break;

                    case ConsoleKey.D9: // Exit menu

                        Console.WriteLine("Program now closing");
                        Thread.Sleep(2000);
                        insideMenu = false;
                        break;
                }
            }
        }

        private static void SearchVehicle()
        {
            Console.Clear();

            Console.Write("Registration number: ");
            string regSearchNumber = Console.ReadLine();
            if (vehicleDictionary.ContainsKey(regSearchNumber))
            {
                Console.Clear();

                Vehicle vehicle = vehicleDictionary[regSearchNumber];

                Console.WriteLine("Registration number: {0}", vehicle.RegNumber);
                Console.WriteLine("Brand: {0}", vehicle.Brand);
                Console.WriteLine("Model: {0}", vehicle.Model);

                if (vehicle is Car car)
                {
                    Console.WriteLine("Car type: {0}", car.CarType);
                    Console.WriteLine("Autopilot: {0}", car.AutoPilot);

                    Console.WriteLine("\n\nPress any key to go back to menu..");
                    Console.ReadKey(true);
                }

                else if (vehicle is Truck truck)
                {
                    Console.WriteLine("Capacity: {0}", truck.Capacity);
                    Console.WriteLine("Trucklift: {0}", truck.TruckLift);

                    Console.WriteLine("\n\nPress any key to go back to menu..");
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("No vehicle was found.");
                Thread.Sleep(2500);
            }
        }
        private static void RemoveVehicle()
        {
            Console.Clear();

            Console.Write("Registration number: ");
            string regNumberRemove = Console.ReadLine();
            if (vehicleDictionary.ContainsKey(regNumberRemove))
            {
                Console.Clear();

                Vehicle vehicle = vehicleDictionary[regNumberRemove];

                Console.WriteLine("Registration number: {0}", vehicle.RegNumber);
                Console.WriteLine("Brand: {0}", vehicle.Brand);
                Console.WriteLine("Model: {0}", vehicle.Model);

                if (vehicle is Car car)
                {
                    Console.WriteLine("Car type: {0}", car.CarType);
                    Console.WriteLine("Autopilot: {0}", car.AutoPilot);
                }

                else if (vehicle is Truck truck)
                {
                    Console.WriteLine("Capacity: {0}", truck.Capacity);
                    Console.WriteLine("Trucklift: {0}", truck.TruckLift);
                }

                Console.WriteLine("\n\nDo you want to remove this vehicle [Y]es [N]o");
                ConsoleKeyInfo removeConfirmation = Console.ReadKey();

                if (removeConfirmation.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    vehicleDictionary.Remove(regNumberRemove);
                    Console.WriteLine("Vehicle removed.");
                    Thread.Sleep(2000);
                }
                else if (removeConfirmation.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("Nothing removed.");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("\nNo vehicle was found.");
                Thread.Sleep(2500);
            }
        }

        private static void ShowSubMenuCarOrTruck()
        {
            Console.Clear();
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");

            ConsoleKeyInfo subMenuChoice = Console.ReadKey(true);

            switch (subMenuChoice.Key)
            {
                case ConsoleKey.D1:
                    {
                        AddCarConfiguration();
                    }
                    break;

                case ConsoleKey.D2:
                    {
                        AddTruckConfiguration();
                    }
                    break;
            }
            Console.Clear();
        }
        private static void AddTruckConfiguration()
        {
            Console.Clear();

            Console.WriteLine("Registration number: ");
            Console.WriteLine("Brand: ");
            Console.WriteLine("Model: ");
            Console.WriteLine("Capacity (cubic meters): ");
            Console.WriteLine("Has lift: (Yes/No): ");

            Console.SetCursorPosition(25, 0);
            string regNumber = Console.ReadLine();

            Console.SetCursorPosition(25, 1);
            string brand = Console.ReadLine();

            Console.SetCursorPosition(25, 2);
            string model = Console.ReadLine();

            Console.SetCursorPosition(25, 3);
            double capacity;
            if (!double.TryParse(Console.ReadLine(), out capacity))
            {
                Console.WriteLine("Try again, wrong input.");
            }

            Console.SetCursorPosition(25, 4);
            TruckLift truckLift = (TruckLift)Enum.Parse(typeof(TruckLift), Console.ReadLine());

            Console.WriteLine("\nIs this correct? [Y]es [N]o");

            ConsoleKeyInfo correctInformation = Console.ReadKey(true);

            if (correctInformation.Key == ConsoleKey.Y)
            {

                if (vehicleDictionary.ContainsKey(regNumber))
                {
                    Console.Clear();
                    Console.WriteLine("Registration number already exists.");
                    Console.WriteLine("Try again? [Y] [N]");

                    ConsoleKeyInfo regExistTryAgain = Console.ReadKey(true);

                    if (regExistTryAgain.Key == ConsoleKey.Y)
                    {
                        AddTruckConfiguration();
                    }
                    else if (regExistTryAgain.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Console.WriteLine("Going back to menu.");
                        Thread.Sleep(2500);
                    }
                }
                else if (!vehicleDictionary.ContainsKey(regNumber))
                {
                    Console.Clear();
                    Truck truck = new Truck(regNumber, brand, model, capacity, truckLift);
                    vehicleDictionary.Add(truck.RegNumber, truck);
                    Console.WriteLine("Vehicle has been added.");
                    Thread.Sleep(3000);
                }
            }
            else if (correctInformation.Key == ConsoleKey.N)
            {
                Console.WriteLine("Nothing added. Form reseted.");
                Thread.Sleep(3000);
                AddTruckConfiguration();
            }
        }

        private static void AddCarConfiguration()
        {
            Console.Clear();

            Console.WriteLine("Registration number: ");
            Console.WriteLine("Brand: ");
            Console.WriteLine("Model: ");
            Console.WriteLine("Type (Sedan, Compact, Subcompact): ");
            Console.WriteLine("Auto pilot (Yes, No): ");

            Console.SetCursorPosition(36, 0);
            string regNumber = Console.ReadLine();

            Console.SetCursorPosition(36, 1);
            string brand = Console.ReadLine();

            Console.SetCursorPosition(36, 2);
            string model = Console.ReadLine();

            Console.SetCursorPosition(36, 3);
            CarType carType = (CarType)Enum.Parse(typeof(CarType), Console.ReadLine());

            Console.SetCursorPosition(36, 4);
            AutoPilot autoPilot = (AutoPilot)Enum.Parse(typeof(AutoPilot), Console.ReadLine());

            Console.WriteLine("\nIs this correct? [Y]es [N]o");

            ConsoleKeyInfo correctInformation = Console.ReadKey(true);

            if (correctInformation.Key == ConsoleKey.Y)
            {

                if (vehicleDictionary.ContainsKey(regNumber))
                {
                    Console.Clear();
                    Console.WriteLine("Registration number already exists.");
                    Console.WriteLine("Try again? [Y] [N]");

                    ConsoleKeyInfo regExistTryAgain = Console.ReadKey(true);

                    if (regExistTryAgain.Key == ConsoleKey.Y)
                    {
                        AddCarConfiguration();
                    }
                    else if (regExistTryAgain.Key == ConsoleKey.N)
                    {
                        Console.Clear();
                        Console.WriteLine("Going back to menu.");
                        Thread.Sleep(2500);
                    }
                }
                else if (!vehicleDictionary.ContainsKey(regNumber))
                {
                    Console.Clear();
                    Car car = new Car(regNumber, brand, model, carType, autoPilot);
                    vehicleDictionary.Add(car.RegNumber, car);
                    Console.WriteLine("Vehicle has been added.");
                    Thread.Sleep(3000);
                }
            }
            else if (correctInformation.Key == ConsoleKey.N)
            {
                Console.WriteLine("Nothing added. Form reseted.");
                Thread.Sleep(3000);
                AddCarConfiguration();
            }
        }
    }
}




// TODO: Logiska operatorer.                                                                                   DONE ? I hope, aren't using too many.
// TODO: Accept only abc123. Regex ? Split ?                                                                   DONE
// TODO: Make sure there isn't a vehicle with the same reg number.                                             DONE
// TODO: Absract class.                                                                                        DONE ? Not sure if correct, but contains abstract Vehicle class
// TODO: Säkerställa att model/brand inte kan vara null/tom sträng. Samma sak med bil typ. I property ?        DONE ? Need to check g doc.
// TODO: Car/Truck utskrift ska visas på samma gång. Och markören för inmatning ska flyttas längst input.      DONE
// TODO: När man skrivit i information, fråga användaren ifall dem är säkra på att dem vill läga till.         DONE
// TODO: Söka fordon.                                                                                          DONE
// TODO: Radera fordon ---- FRIVILLIG ----                                                                     DONE
































//    if(regNumber == vehicleDictionary.RegNumber)
//    {

//    }
//if(vehicleDictionary.Contains(car.RegNumber, regNumber, StringComparison.OrdinalIgnoreCase))
//{

//}
// vehicleDictionary.Contains(x => string.Equals(x.RegNumber, regNumber, StringComparison.OrdinalIgnoreCase))