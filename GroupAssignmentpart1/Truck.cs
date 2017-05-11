using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Truck:Vehicle
    {
        public Truck(string liPlate, string color, string brand, string model, string engineType,int numOfWheels, string fuelType, string transmition)
            : base( liPlate, color, brand, model, engineType, numOfWheels, fuelType, transmition, 2, 50)
        {
        }
    }
}
