using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        protected static List<T> garage = new List<T>();

        internal void Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        internal bool Remove(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        internal T SearchByLiPlate(string LiPlate)
        {
            var query = (from v in garage
                         where v.LiPlate == LiPlate
                         orderby v.LiPlate
                         select v).FirstOrDefault();

            return query;
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Vehicles { get; private set; }
    }
}
