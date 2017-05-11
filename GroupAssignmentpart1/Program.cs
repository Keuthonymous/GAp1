using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            Menu menu = new Menu(new Dictionary<string, string> { { "1", "View information of all vehicles in the garage."},
                                                                  { "2", "Search for vehicles in the garage."},
                                                                  { "3", "Check in a new vehicle."},
                                                                  { "4", "Check out a vehicle from the garage."},
                                                                  { "0", "Exit."}},
                                 "What do you want to do?");

            do
            {
                switch (menu.Show())
                {
                    case "1":
                        MenuViewInformation();
                        break;
                    case "2":
                        MenuSearchVehicles();
                        break;
                    case "3":
                        MenuCheckInVehicle();
                        break;
                    case "4":
                        MenuCheckOutVehicle();
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
            while (!exit);

        }

        private static void MenuViewInformation()
        {
            Dictionary<string, string> menuItems = new Dictionary<string, string>();
            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

            int noVehicle = -1;
            foreach (Vehicle vehicle in GarageLogic.Vehicles())
            {
                menuItems.Add(noVehicle.ToString(), vehicle.ToString());
                vehicles.Add(noVehicle.ToString(), vehicle);

                noVehicle -= 1;
            }

            noVehicle -= 1;
            menuItems.Add(noVehicle.ToString(), string.Empty);
            menuItems.Add("0", "Exit.");

            new Menu(menuItems, "Vehicles currently parked in the garage:").Show();
        }

        #region Searching for vehicles

        private static void MenuSearchVehicles()
        {
            bool exit = false;

            Menu menu = new Menu(new Dictionary<string, string> { { "1", "Registration number." },
                                                                  { "2", "Type of vehicle." },
                                                                  { "3", "Parking date."},
                                                                  { "0", "Exit."} },
                                 "Do you want to search by:");

            do
            {
                switch (menu.Show())
                {
                    case "1":
                        SearchByRegistrationNumber();
                        break;
                    case "2":
                        SearchByVehicleType();
                        break;
                    case "3":
                        SearchByParkingDate();
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }

        private static void SearchByRegistrationNumber()
        {
            Console.WriteLine("Please enter a valid Reg. number.");
            string LiPlate = Console.ReadLine();

            if (GarageLogic.SearchByLiPlate(LiPlate) == null)
            {
                Console.WriteLine("This car does not exist in this garage.");
            }
            else
            {
                Console.WriteLine(GarageLogic.SearchByLiPlate(LiPlate));
            }

            Console.ReadKey();
        }

        private static void SearchByVehicleType()
        {
            Console.WriteLine("Please enter the brand and model of car that you're searching for: ");

        }

        private static void SearchByParkingDate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Check in a vehicle

        private static void MenuCheckInVehicle()
        {
            bool exit = false;
            Menu menu = new Menu(new Dictionary<string, string> { { "1", "Motorcycle." },
                                                                  { "2", "Car." },
                                                                  { "3", "Bus." },
                                                                  { "4", "Truck." },
                                                                  { "0", "Exit." } },
                                "What type of vehicle do you want to check in?");

            do
            {
                switch (menu.Show())
                {
                    case "1":
                        CheckInMotorcycle();
                        break;
                    case "2":
                        CheckInCar();
                        break;
                    case "3":
                        CheckInBus();
                        break;
                    case "4":
                        CheckInTruck();
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }

        private static void CheckInMotorcycle()
        {
            string vehicleName = "motorcycle";

            string liPlate = GetString("registration plate", vehicleName, false);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);
            string engineType = GetString("engine type", vehicleName);
            string fuelType = GetString("fuel type", vehicleName);
            string transmition = GetString("transmition", vehicleName);

            Motorcycle motorcycle = new Motorcycle(liPlate, color, brand, model, engineType, fuelType, transmition);

            int parkingPlace = GarageLogic.ParkVehicle(motorcycle);

            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static void CheckInCar()
        {
            string vehicleName = "car";

            string liPlate = GetString("registration plate", vehicleName, false);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);
            string engineType = GetString("engine type", vehicleName);
            string fuelType = GetString("fuel type", vehicleName);
            string transmition = GetString("transmition", vehicleName);
            int numOfDoors = GetInteger("number of doors", vehicleName);

            Car car = new Car(liPlate, color, brand, model, engineType, fuelType, transmition, numOfDoors);

            int parkingPlace = GarageLogic.ParkVehicle(car);

            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static void CheckInBus()
        {
            string vehicleName = "bus";

            string liPlate = GetString("registration plate", vehicleName, false);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);
            string engineType = GetString("engine type", vehicleName);
            string fuelType = GetString("fuel type", vehicleName);
            string transmition = GetString("transmition", vehicleName);

            Bus bus = new Bus(liPlate, color, brand, model, engineType, fuelType, transmition);

            int parkingPlace = GarageLogic.ParkVehicle(bus);

            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static void CheckInTruck()
        {
            string vehicleName = "truck";

            string liPlate = GetString("registration plate", vehicleName, false);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);
            string engineType = GetString("engine type", vehicleName);
            int numOfWheels = GetInteger("number of wheels", vehicleName);
            string fuelType = GetString("fuel type", vehicleName);
            string transmition = GetString("transmition", vehicleName);

            Truck truck = new Truck(liPlate, color, brand, model, engineType, numOfWheels, fuelType, transmition);

            int parkingPlace = GarageLogic.ParkVehicle(truck);

            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static string GetString(string stringName, string vehicleName, bool allowBlank = true)
        {
            string input = string.Empty;
            string canLetBlank = string.Empty;
            bool inputOK = true;

            if (allowBlank)
                canLetBlank = " (just press 'Enter' if you want to let it blank)";

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the {0} of the {1}{2}:", stringName, vehicleName, canLetBlank);
                input = Console.ReadLine();

                if (input.Length == 0 && !allowBlank)
                {
                    Console.WriteLine("The value you entered is incorrect!");
                    inputOK = false;
                }
            }
            while (!inputOK);

            return input;
        }

        private static int GetInteger(string integerName, string vehicleName)
        {
            string input = string.Empty;
            int result = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the {0} of the {1}:", integerName, vehicleName);
                input = Console.ReadLine();

                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("The value you entered is incorrect!");
                    input = string.Empty;
                }
            }
            while (input.Length == 0);

            return result;
        }

        #endregion

        #region Check out a vehicle

        private static void MenuCheckOutVehicle()
        {
            bool exit = false;

            do
            {
                Dictionary<string, string> menuItems = new Dictionary<string, string>();
                Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

                int noVehicle = 1;
                foreach (Vehicle vehicle in GarageLogic.Vehicles())
                {
                    menuItems.Add(noVehicle.ToString(), vehicle.ToString());
                    vehicles.Add(noVehicle.ToString(), vehicle);

                    noVehicle += 1;
                }

                menuItems.Add("-1", string.Empty);
                menuItems.Add("0", "Exit.");

                string input = new Menu(menuItems, "Vehicles currently parked in the garage:").Show();

                if (input == "0")
                    exit = true;
                else if (ConfirmCheckOut())
                {
                    Vehicle vehicle = vehicles[input];
                    double fee = GarageLogic.UnparkVehicle(vehicle);
                    Console.WriteLine("The vehicle has been parked since {0}, which gives a fee of {1:N2}", vehicle.PTime.ToString(), vehicle.Fee);
                    Console.ReadKey();
                }
            }
            while (!exit);
        }

        #endregion

        private static bool ConfirmCheckOut()
        {
            return (new Menu(new Dictionary<string, string> { { "Y", "Yes." }, 
                                                              { "N", "No." } },
                             "Do you really want to check out the chosen vehicle?")
                             .Show()
                             .ToUpper() == "Y");
        }


    }
}
