using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private List<T> garage = new List<T>();

        internal void Add(T vehicle)
        {
            garage.Add(vehicle);
            vehicle.PSpot = garage.ToList().IndexOf(vehicle);
        }

        internal bool Remove(T vehicle)
        {
            return garage.Remove(vehicle);
        }

        internal T SearchByLiPlate(string liPlate)
        {
            return (from v in garage
                    where v.LiPlate == liPlate
                    orderby v.LiPlate
                    select v).FirstOrDefault();
        }

        internal IEnumerable<T> SearchByVehicleType(string brand, string model)
        {
            var query = from v in garage
                        where string.Compare(v.Brand, brand, true) == 0 && string.Compare(v.Model, model, true) == 0
                        orderby v.LiPlate
                        select v;
            return query;
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            if (before)
                return garage.Where(t => t.PTime <= date);
            else
                return garage.Where(t => t.PTime >= date);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return garage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public List<T> Vehicles { get { return garage; } private set { } }
    }
}
