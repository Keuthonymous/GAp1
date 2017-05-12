using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuLoadVehicles();

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
                        MenuSaveVehicles();
                        exit = true;
                        break;
                }
            }
            while (!exit);

        }

        private static void MenuViewInformation()
        {
            DisplayVehicles(GarageLogic.Vehicles(), "Vehicles currently parked in the garage:");
        }

        #region Import/export management

        private static void MenuLoadVehicles()
        {
            if (new Menu(new Dictionary<string, string> { { "Y", "Yes." },
                                                          { "N", "No." } },
                         new List<string> { "Would you want to load the vehicle list",
                                            "from your previous session?" }).Show().ToUpper() == "Y")
                GarageLogic.Load();
        }

        private static void MenuSaveVehicles()
        {
            if (GarageLogic.GarageModified() && new Menu(new Dictionary<string, string> { { "Y", "Yes." },
                                                                                          { "N", "No." } },
                                                         "Do you want to save the vehicle list before you quit?").Show().ToUpper() == "Y")
                GarageLogic.Save();
        }

        #endregion

        #region Searching for vehicles

        private static void MenuSearchVehicles()
        {
            bool exit = false;

            Menu menu = new Menu(new Dictionary<string, string> { { "1", "Registration number." },
                                                                  { "2", "Type of vehicle." },
                                                                  { "3", "Brand and model." },
                                                                  { "4", "Parking date."},
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
                        SearchByBrandAndModel();
                        break;
                    case "4":
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
            string registrationPlate = Console.ReadLine();

            if (GarageLogic.SearchByRegistrationPlate(registrationPlate) == null)
            {
                Console.WriteLine("This car does not exist in this garage.");
            }
            else
            {
                Console.WriteLine(GarageLogic.SearchByRegistrationPlate(registrationPlate));
            }
            Console.ReadKey();
        }

        private static void SearchByVehicleType()
        {
            bool exit = false;

            Dictionary<string, string> menuItems = new Dictionary<string, string>();
            Dictionary<string, Type> types = new Dictionary<string, Type>();

            int noType = 1;
            foreach (Type t in typeof(Vehicle).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Vehicle))))
            {
                menuItems.Add(noType.ToString(), t.Name + ".");
                types.Add(noType.ToString(), t);

                noType += 1;
            }

            menuItems.Add("0", "Exit.");

            Menu menu = new Menu(menuItems, "Please select the type of vehicle you want to list:");

            do
            {
                string input=menu.Show();
                if (input == "0")
                    exit = true;
                else
                    DisplayVehicles(GarageLogic.SearchByVehicleType(types[input]), "List of the found vehicles:");
            }
            while (!exit);
        }

        private static void SearchByBrandAndModel()
        {
            Console.WriteLine("Please enter the brand and model of car that you're searching for: ");
            string brand = GetString("brand", "vehicle", false);
            string model = GetString("model", "vehicle", false);

            DisplayVehicles(GarageLogic.SearchByBrandAndModel(brand, model), "result");
            Console.ReadKey();

        }

        private static void SearchByParkingDate()
        {
            Console.WriteLine("Please enter the time that your car was parked");

            string timeInput = "";
            DateTime PTime = GetDateTime(timeInput);
            DateTime now = DateTime.Now.Date;
            if (PTime < now)
            {
                bool before = true;
                while (before == true)
                {
                    Console.WriteLine(GarageLogic.SearchByParkingDate(PTime, before));
                    Console.ReadKey();
                }
            }
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

            string registrationPlate = GetRegistrationPlate(vehicleName);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);

            Motorcycle motorcycle = new Motorcycle(registrationPlate, color, brand, model);

            int parkingPlace = GarageLogic.ParkVehicle(motorcycle);
            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static void CheckInCar()
        {
            string vehicleName = "car";

            string registrationPlate = GetRegistrationPlate(vehicleName);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);
            int numOfDoors = GetInteger("number of doors", vehicleName);

            Car car = new Car(registrationPlate, color, brand, model, numOfDoors);

            int parkingPlace = GarageLogic.ParkVehicle(car);
            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static void CheckInBus()
        {
            string vehicleName = "bus";

            string registrationPlate = GetRegistrationPlate(vehicleName);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);

            Bus bus = new Bus(registrationPlate, color, brand, model);

            int parkingPlace = GarageLogic.ParkVehicle(bus);
            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
        }

        private static void CheckInTruck()
        {
            string vehicleName = "truck";

            string registrationPlate = GetRegistrationPlate(vehicleName);
            string color = GetString("color", vehicleName);
            string brand = GetString("brand", vehicleName);
            string model = GetString("model", vehicleName);
            int numberOfWheels = GetInteger("number of wheels", vehicleName);

            Truck truck = new Truck(registrationPlate, color, brand, model, numberOfWheels);

            int parkingPlace = GarageLogic.ParkVehicle(truck);
            Console.WriteLine("Your {0} has been parked on place {1}", vehicleName, parkingPlace);
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

                string input = new Menu(menuItems, "Vehicles currently parked in the garage:", GetColumnNames()).Show();

                if (input == "0")
                    exit = true;
                else
                {
                    Vehicle vehicle = vehicles[input];
                    if (ConfirmCheckOut(vehicle))
                    {
                        double totalPrice = GarageLogic.UnparkVehicle(vehicle);
                        Console.WriteLine("The vehicle has been parked since {0} with a fee of {1},\nwhich gives a total of {2:N2}",
                                          vehicle.ParkingTime.ToString(),
                                          vehicle.Fee,
                                          totalPrice);
                        Console.ReadKey();
                    }
                }
            }
            while (!exit);
        }

        #endregion

        private static bool ConfirmCheckOut(Vehicle vehicle)
        {
            return (new Menu(new Dictionary<string, string> { { "-1", vehicle.ToString() },
                                                              {"-2", string.Empty },
                                                              { "Y", "Yes." }, 
                                                              { "N", "No." } },
                             "Do you really want to check out the chosen vehicle?",
                             GetColumnNames())
                             .Show()
                             .ToUpper() == "Y");
        }

        private static void DisplayVehicles(IEnumerable<Vehicle> vehicles, string title)
        {
            Dictionary<string, string> menuItems = new Dictionary<string, string>();
            Dictionary<string, Vehicle> dicVehicles = new Dictionary<string, Vehicle>();

            int noVehicle = -1;
            foreach (Vehicle vehicle in vehicles)
            {
                menuItems.Add(noVehicle.ToString(), vehicle.ToString());
                dicVehicles.Add(noVehicle.ToString(), vehicle);

                noVehicle -= 1;
            }

            noVehicle -= 1;
            menuItems.Add(noVehicle.ToString(), string.Empty);
            menuItems.Add("0", "Exit.");

            new Menu(menuItems, title, GetColumnNames()).Show();
        }

        #region Get methods

        private static List<string> GetColumnNames()
        {
            return new List<string> { "Type",
                                      "Reg. plate",
                                      "Brand",
                                      "Model",
                                      "Color",
                                      "Doors",
                                      "Wheels",
                                      "Time parked" };
        }

        private static DateTime GetDateTime(string timeInput)
        {
            string Format = "dd/MM/yyyy HH:mm";
            Console.WriteLine("Enter the date you parked in (dd/MM/yyyy hh:mm) time format.");

            timeInput = Console.ReadLine();
            DateTime now = DateTime.Now.Date;
            DateTime dateTime = DateTime.ParseExact(timeInput, Format, CultureInfo.InvariantCulture);

            return dateTime;
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
                    Console.ReadKey();
                }
            }
            while (input.Length == 0);

            return result;
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
                    Console.ReadKey();
                }
            }
            while (!inputOK);

            return input;
        }

        private static string GetRegistrationPlate(string vehicleName)
        {
            string input = string.Empty;

            do
            {
                input = GetString("registration plate", vehicleName, false);
                if (GarageLogic.SearchByRegistrationPlate(input) != null)
                {
                    Console.WriteLine("A vehicle with the same registration plate is already parked in the garage.");
                    Console.ReadKey();
                    input = string.Empty;
                }
            }
            while (input.Length == 0);

            return input.ToUpper();
        }

        #endregion
    }
}
