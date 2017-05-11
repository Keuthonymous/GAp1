using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Garage<T>:IEnumerable<T> where T:Vehicle
    {

        internal void Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        internal bool Remove(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        internal Vehicle SearchByLiPlate(string LiPlate)
        {
            var query = from v in GarageLogic.garage
                        where v.LiPlate == LiPlate
                        orderby v.LiPlate
                        select v;

            return query;
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Vehicles { get; private set; }
    }
}
