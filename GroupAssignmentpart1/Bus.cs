using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Bus : Vehicle
    {
        public Bus()
        {
        }

        public Bus(string registrationPlate,
                   string color,
                   string brand,
                   string model)
            : base(registrationPlate, color, brand, model, 6, 2, 30)
        {
        }

    }
}
