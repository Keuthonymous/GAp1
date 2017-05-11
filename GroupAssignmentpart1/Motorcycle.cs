using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Motorcycle:Vehicle
    {
        public Motorcycle(string liPlate, string color, string brand, string model, string engineType, string fuelType, string transmition, double fee)
            : base( liPlate, color, brand, model, engineType, 2, fuelType, transmition, 0, fee)
        {
        }
    }
}
