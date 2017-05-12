using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Truck : Vehicle
    {
        public Truck()
        {
        }

        public Truck(string registrationPlate,
                     string color,
                     string brand,
                     string model,
                     int numberOfWheels)
            : base(registrationPlate, color, brand, model, numberOfWheels, 2, 50)
        {
        }
    }
}
