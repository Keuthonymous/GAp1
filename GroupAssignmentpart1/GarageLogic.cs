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
        public static void CheckIn(Vehicle vehicle)
        {
            garage.CheckIn(vehicle);
        }

        /// <summary>
        /// Allows the user to unpark a vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to be unparked</param>
        /// <returns>Value of the fee, accoring to the type of vehicle and how long it has been parked</returns>
        public static double CheckOut(Vehicle vehicle)
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

        /// <summary>
        /// Returns the path to the default XML file in which motorcycle informations are supposed to be stored
        /// </summary>
        /// <returns></returns>
        private static string SerializationPathMotorcycles()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Motorcycles.xml");
        }

        /// <summary>
        /// Returns the path to the default XML file in which car informations are supposed to be stored
        /// </summary>
        /// <returns></returns>
        private static string SerializationPathCars()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cars.xml");
        }

        /// <summary>
        /// Returns the path to the default XML file in which bus informations are supposed to be stored
        /// </summary>
        /// <returns></returns>
        private static string SerializationPathBusses()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Busses.xml");
        }

        /// <summary>
        /// Returns the path to the default XML file in which truck informations are supposed to be stored
        /// </summary>
        /// <returns></returns>
        private static string SerializationPathTrucks()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Trucks.xml");
        }

        /// <summary>
        /// Exports all information of all vehicles into default XML files
        /// </summary>
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
            docMotorcycles.Save(SerializationPathMotorcycles());

            XDocument docCars = new XDocument(rootCars);
            docCars.Save(SerializationPathCars());

            XDocument docBusses = new XDocument(rootBusses);
            docBusses.Save(SerializationPathBusses());

            XDocument docTrucks = new XDocument(rootTrucks);
            docTrucks.Save(SerializationPathTrucks());
        }

        /// <summary>
        /// Loads all vehicles stored in the default XML files
        /// </summary>
        public static void Load()
        {
            LoadMotorcycles();
            LoadCars();
            LoadBusses();
            LoadTrucks();

            garage.Modified = false;
        }

        /// <summary>
        /// Loads all motorcycle vehicles stored in the default XML file
        /// </summary>
        private static void LoadMotorcycles()
        {
            // Checking that the xml file currently exists
            string strPath = SerializationPathMotorcycles();

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Motorcycle vehicle = (Motorcycle)Activator.CreateInstance(typeof(Motorcycle));
                if (vehicle.Deserialize(el))
                    garage.Add(vehicle);
            }
        }

        /// <summary>
        /// Loads all car vehicles stored in the default XML file
        /// </summary>
        private static void LoadCars()
        {
            // Checking that the xml file currently exists
            string strPath = SerializationPathCars();

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Car vehicle = (Car)Activator.CreateInstance(typeof(Car));
                if (vehicle.Deserialize(el))
                    garage.Add(vehicle);
            }
        }

        /// <summary>
        /// Loads all bus vehicles stored in the default XML file
        /// </summary>
        private static void LoadBusses()
        {
            // Checking that the xml file currently exists
            string strPath = SerializationPathBusses();

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Bus vehicle = (Bus)Activator.CreateInstance(typeof(Bus));
                if (vehicle.Deserialize(el))
                    garage.Add(vehicle);
            }
        }

        /// <summary>
        /// Loads all truck vehicles stored in the default XML file
        /// </summary>
        private static void LoadTrucks()
        {
            // Checking that the xml file currently exists
            string strPath = SerializationPathTrucks();

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);

            foreach (XElement el in elements.Elements())
            {
                Truck vehicle = (Truck)Activator.CreateInstance(typeof(Truck));
                if (vehicle.Deserialize(el))
                    garage.Add(vehicle);
            }
        }

        #endregion
    }
}
