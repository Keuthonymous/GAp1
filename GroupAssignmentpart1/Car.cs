using System;

namespace GroupAssignmentpart1
{
    class Car:Vehicle
    {
        public Car(string registrationPlate,
                   string color,
                   string brand,
                   string model,
                   int numOfDoors)
            : base( registrationPlate, color, brand, model, 4, numOfDoors, 20)
        {

        }
    }
}
