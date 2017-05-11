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
        }

        internal bool Remove(T vehicle)
        {
            return garage.Remove(vehicle);
        }

        internal T SearchByLiPlate(string LiPlate)
        {
            return (from v in garage
                    where v.LiPlate == LiPlate
                    orderby v.LiPlate
                    select v).FirstOrDefault();
        }

        internal IEnumerable<T> SearchByVehicleType(string Brand, string Model)
        {
            var query = from v in garage
                        where v.Brand == Brand && v.Model == Model
                        orderby v.LiPlate
                        select v;
            return query;
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() //Did this VV
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException(); //To this ^^
        }

        public List<T> Vehicles { get { return garage; } private set { } }
    }
}
