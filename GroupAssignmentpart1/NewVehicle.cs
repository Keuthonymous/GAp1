using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class NewVehicle
    {
        public double ParkFee()
        {

            double parkTime;
            const double HOURLY_RATE = 2.50;
            double parkFee;
            Console.WriteLine("Time parked in hours: Eg 1.5 or 2.75");
            parkTime = double.Parse(Console.ReadLine());
            parkFee = Math.Ceiling(parkTime) * HOURLY_RATE;
            Console.Write("Parking Fee = $" + parkFee);
            

        }
    }
}
