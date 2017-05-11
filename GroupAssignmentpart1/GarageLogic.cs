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
        public static void ParkVehicle(Vehicle vehicle)
        {
            garage.Add(vehicle);
        }

        public static double UnparkVehicle(Vehicle vehicle)
        {
            if (garage.Remove(vehicle))
                return vehicle.Fee;
            else
                return 0;
        }

        /// <summary>
        /// Allows the user to search for a vehicle according to its identification plate
        /// </summary>
        /// <param name="identificationPlate">Identificaction plate to be searched in the garage</param>
        /// <returns></returns>
        public static Vehicle SearchByIdentificationPlate(string identificationPlate)
        {
            return garage.SearchByIdentificationPlate(identificationPlate);
        }

        /// <summary>
        /// Allows the user to search for vehicles in the garage those have been parked before or after a given date
        /// </summary>
        /// <param name="date">Date the parking date of the vehicle has to be compared with</param>
        /// <param name="before">Indicates if the vehicles have to have been parked before or after the given date</param>
        /// <returns></returns>
        public static IEnumerable<Vehicle> SearchByParkingDate(DateTime date, bool before)
        {
            return garage.SearchByParkingDate(date, before);
        }
    }
}
