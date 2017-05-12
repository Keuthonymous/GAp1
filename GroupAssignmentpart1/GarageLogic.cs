using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroupAssignmentpart1
{
    static class GarageLogic
    {
        private static Garage<Vehicle> garage = new Garage<Vehicle>();

        /// <summary>
        /// Allows the user to park a vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to be parked</param>
        public static int ParkVehicle(Vehicle vehicle)
        {
            garage.Add(vehicle);
            return vehicle.ParkingSpot;
        }

        /// <summary>
        /// Allows the user to unpark a vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to be unparked</param>
        /// <returns>Value of the fee, accoring to the type of vehicle and how long it has been parked</returns>
        public static double UnparkVehicle(Vehicle vehicle)
        {
            if (garage.Remove(vehicle))
                return vehicle.PayCheckOut();
            else
                return 0;
        }

        public static bool GarageModified()
        {
            return garage.Modified;
        }

        /// <summary>
        /// Returns a string containing all information of all vehicles currently parked in the garage
        /// </summary>
        /// <returns></returns>
        public static List<Vehicle> Vehicles()
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle vehicle in garage.Vehicles)
                result.Add(vehicle);

            return result;
        }

        /// <summary>
        /// Allows the user to search for a vehicle according to its identification plate
        /// </summary>
        /// <param name="registrationPlate">Identificaction plate to be searched in the garage</param>
        /// <returns></returns>
        public static Vehicle SearchByRegistrationPlate(string registrationPlate)
        {
            return garage.SearchByRegistrationPlate(registrationPlate);
        }

        public static IEnumerable<Vehicle> SearchByVehicleType(Type type)
        {
            return garage.SearchByVehileType(type);
        }

        /// <summary>
        /// Allows the user to search for vehicles in the garage by brand and model.
        /// </summary>
        /// <param name="<brand">brand of the vehicle</param>
        /// <param name="model">model of the vehicle</param>
        /// <returns></returns>
        public static IEnumerable<Vehicle> SearchByBrandAndModel(string brand, string model)
        {
            return garage.SearchByBrandAndModel(brand, model);
        }

        /// <summary>
        /// Allows the user to search for vehicles in the garage those have been parked before or after a given date
        /// </summary>
        /// <param name="<parkingTime">Date the parking date of the vehicle has to be compared with</param>
        /// <param name="before">Indicates if the vehicles have to have been parked before or after the given date</param>
        /// <returns></returns>
        public static IEnumerable<Vehicle> SearchByParkingDate(DateTime parkingTime, bool before)
        {
            return garage.SearchByParkingDate(parkingTime, before);
        }

        #region Serialization management

        private static string SerializationPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vehicles.xml");
        }

        public static void Save()
        {
            XElement rootMotorcycles = new XElement("Root");
            XElement rootCars = new XElement("Root");
            XElement rootBusses = new XElement("Root");
            XElement rootTrucks = new XElement("Root");

            foreach (Vehicle vehicle in garage.Vehicles)
                if (vehicle.GetType() == typeof(Motorcycle))
                    rootMotorcycles.Add(vehicle.Serialize());
                else if (vehicle.GetType() == typeof(Car))
                    rootCars.Add(vehicle.Serialize());
                else if (vehicle.GetType() == typeof(Bus))
                    rootBusses.Add(vehicle.Serialize());
                else if (vehicle.GetType() == typeof(Truck))
                    rootTrucks.Add(vehicle.Serialize());

            XDocument docMotorcycles = new XDocument(rootMotorcycles);
            docMotorcycles.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Motorcycles.xml"));

            XDocument docCars = new XDocument(rootCars);
            docCars.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cars.xml"));

            XDocument docBusses = new XDocument(rootBusses);
            docBusses.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Busses.xml"));

            XDocument docTrucks = new XDocument(rootTrucks);
            docTrucks.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trucks.xml"));
        }

        public static void Load()
        {
            LoadMotorcycles();
            LoadCars();
            LoadBusses();
            LoadTrucks();

            garage.Modified = false;
        }

        private static void LoadMotorcycles()
        {
            // Checking that the xml file currently exists
            string strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Motorcycles.xml");

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Motorcycle vehicle = (Motorcycle)Activator.CreateInstance(typeof(Motorcycle));
                vehicle.Deserialize(el);
                garage.Add(vehicle);
            }
        }

        private static void LoadCars()
        {
            // Checking that the xml file currently exists
            string strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cars.xml");

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Car vehicle = (Car)Activator.CreateInstance(typeof(Car));
                vehicle.Deserialize(el);
                garage.Add(vehicle);
            }
        }

        private static void LoadBusses()
        {
            // Checking that the xml file currently exists
            string strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Busses.xml");

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Bus vehicle = (Bus)Activator.CreateInstance(typeof(Bus));
                vehicle.Deserialize(el);
                garage.Add(vehicle);
            }
        }

        private static void LoadTrucks()
        {
            // Checking that the xml file currently exists
            string strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trucks.xml");

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Truck vehicle = (Truck)Activator.CreateInstance(typeof(Truck));
                vehicle.Deserialize(el);
                garage.Add(vehicle);
            }
        }

        #endregion
    }
}
