using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return garage.ToList().IndexOf(vehicle);
        }

        /// <summary>
        /// Allows the user to unpark a vehicle
        /// </summary>
        /// <param name="vehicle">Vehicle to be unparked</param>
        /// <returns>Value of the fee, accoring to the type of vehicle and how long it has been parked</returns>
        public static double UnparkVehicle(Vehicle vehicle)
        {
            if (garage.Remove(vehicle))
                return vehicle.Fee;
            else
                return 0;
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
        /// <param name="LiPlate">Identificaction plate to be searched in the garage</param>
        /// <returns></returns>
        public static Vehicle SearchByLiPlate(string LiPlate)
        {
            return garage.SearchByLiPlate(LiPlate);
        }

        /// <summary>
        /// Allows the user to search for vehicles in the garage those have been parked before or after a given date
        /// </summary>
        /// <param name="<PTime">Date the parking date of the vehicle has to be compared with</param>
        /// <param name="before">Indicates if the vehicles have to have been parked before or after the given date</param>
        /// <returns></returns>
        public static IEnumerable<Vehicle> SearchByParkingDate(DateTime PTime, bool before)
        {
            return garage.SearchByParkingDate(PTime, before);
        }
    }
}
