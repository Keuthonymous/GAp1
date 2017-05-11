using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Bus : Vehicle
    {
        public Bus(string liPlate, string color, string brand, string model, string engineType, string fuelType, string transmition)
            : base(liPlate, color, brand, model, engineType, 6, fuelType, transmition, 2, 30)
        {
        }

    }
}
