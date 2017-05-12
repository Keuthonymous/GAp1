using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GroupAssignmentpart1
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private List<T> garage = new List<T>();
        private bool modified = false;

        /// <summary>
        /// Adds a new "T" in the garage and checks that the registration plate doesn't already exists
        /// </summary>
        /// <param name="t">"T" that has to be added to the garage</param>
        internal void Add(T t)
        {
            garage.Add(t);

            modified = true;
        }

        /// <summary>
        /// Removes a "T" from the garage
        /// </summary>
        /// <param name="t">"T" to be removed</param>
        /// <returns>True if t was already in the garage, false otherwise</returns>
        internal bool Remove(T t)
        {
            if (garage.Remove(t))
            {
                modified = true;
                return true;
            }
            else
                return false;
        }

        internal void CheckIn(T t)
        {
            Add(t);
            t.ParkingTime = DateTime.Now;
            t.ParkingSpot = AvailablePlace();
        }

        internal int AvailablePlace()
        {
            // Let's get the list of occupied spots, sort it ascending and from 0, look for the next available spot
            IEnumerable<int> occupiedSpots = Vehicles.OrderBy(t => t.ParkingSpot).Select(t => t.ParkingSpot);
            int availableSpot = 0;
            foreach (int occupiedSpot in occupiedSpots)
                if (occupiedSpot == availableSpot)
                    availableSpot += 1;
                else
                    break;

            return availableSpot;
        }

        /// <summary>
        /// Indicates if changes occured in the garage list
        /// </summary>
        internal bool Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        /// <summary>
        /// Searches a "T" in the garage, according to its registration plate
        /// </summary>
        /// <param name="registrationPlate"></param>
        /// <returns></returns>
        internal T SearchByRegistrationPlate(string registrationPlate)
        {
            return (from v in Vehicles
                    where string.Compare(v.RegistrationPlate, registrationPlate, true) == 0
                    orderby v.RegistrationPlate
                    select v).FirstOrDefault();
        }

        internal IEnumerable<T> SearchByVehileType(Type type)
        {
            return Vehicles.Where(t => t.GetType() == type);
        }

        internal IEnumerable<T> SearchByBrandAndModel(string brand, string model)
        {
            var query = from v in Vehicles
                        where string.Compare(v.Brand, brand, true) == 0 && string.Compare(v.Model, model, true) == 0
                        orderby v.RegistrationPlate
                        select v;
            return query;
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            if (before)
                return Vehicles.Where(t => t.ParkingTime <= date);
            else
                return Vehicles.Where(t => t.ParkingTime >= date);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public List<T> Vehicles
        {
            get { return garage.ToList(); }
            private set { }
        }
    }
}
