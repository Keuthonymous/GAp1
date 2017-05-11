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

        internal T SearchByIdentificationPlate(string identificationPlate)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            throw new NotImplementedException();
        }
    }
}
