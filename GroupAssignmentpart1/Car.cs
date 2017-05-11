using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Car:Vehicle
    {
        public Car(string liPlate, string color, string brand, string model, string engineType, string fuelType, string transmition, int numOfDoors, double fee)
            : base( liPlate, color, brand, model, engineType, 4, fuelType, transmition, numOfDoors, fee)
        {
        }
    }
}
