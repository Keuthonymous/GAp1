using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Motorcycle : Vehicle
    {
        public Motorcycle()
        {
        }

        public Motorcycle(string registrationPlate,
                          string color,
                          string brand,
                          string model)
            : base(registrationPlate, color, brand, model, 2, 0, 15)
        {
        }
    }
}
