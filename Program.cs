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

                        break;

                    case ConsoleKey.D3: // Remove vehicle, place holder

                        break;

                    case ConsoleKey.D9: // Exit menu

                        Console.WriteLine("Program now closing");
                        Thread.Sleep(2000);
                        insideMenu = false;
                        break;
                }
            }
        }

        private static void ShowSubMenuCarOrTruck()
        {
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
            Console.WriteLine("Vehicle has been added.");
            Thread.Sleep(2000);
        }

        private static void AddTruckConfiguration()
        {
            Console.Clear();

            Console.Write("Registration number: ");

            string regNumber = Console.ReadLine();

            Console.Write("Brand: ");

            string brand = Console.ReadLine();

            Console.Write("Model: ");

            string model = Console.ReadLine();

            Console.Write("Capacity (cubic meters): ");

            double capacity;
            if (!double.TryParse(Console.ReadLine(), out capacity))
            {
                Console.WriteLine("Try again, wrong input.");
            }

            Console.Write("Has lift: (Yes/No): ");

            TruckLift truckLift = (TruckLift)Enum.Parse(typeof(TruckLift), Console.ReadLine());

            Truck truck = new Truck(regNumber, brand, model, capacity, truckLift);

            vehicleDictionary.Add(truck.RegNumber, truck);
        }

        private static void AddCarConfiguration()
        {
            Console.Clear();

            Console.Write("Registration number: ");

            string regNumber = Console.ReadLine();

            Console.Write("Brand: ");

            string brand = Console.ReadLine();

            Console.Write("Model: ");

            string model = Console.ReadLine();

            Console.Write("Type (Sedan, Compact, Subcompact): ");

            CarType carType = (CarType)Enum.Parse(typeof(CarType), Console.ReadLine());

            Console.Write("Auto pilot (Yes, No): ");

            AutoPilot autoPilot = (AutoPilot)Enum.Parse(typeof(AutoPilot), Console.ReadLine());

            Car car = new Car(regNumber, brand, model, carType, autoPilot);

            vehicleDictionary.Add(car.RegNumber, car);
        }
    }
}
