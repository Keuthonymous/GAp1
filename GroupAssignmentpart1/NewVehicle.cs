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
            const double MAX_FEE = 20.00;
            double parkFee;
            Console.WriteLine("Time parked in hours: Eg 1.5 or 2.75");
            parkTime = double.Parse(Console.ReadLine());

            if (parkTime > 8)
            {
                Console.Write("Total fee is $" + MAX_FEE);
            }
            else
            {
                parkFee = parkTime(Math.Ceiling) * HOURLY_RATE;
                Console.Write("Parking Fee = $" + parkFee);
            }

        }
    }
}
