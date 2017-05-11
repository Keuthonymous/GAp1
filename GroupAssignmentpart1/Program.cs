using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            Menu menu = new Menu(new Dictionary<string, string> { { "1", "View information of all vehicles in the garage."},
                                                                  { "2", "Search for vehicles in the garage."},
                                                                  { "3", "Check in a new vehicle."},
                                                                  { "4", "Check out a vehicle from the garage."},
                                                                  { "0", "Exit."}},
                                 "What do you want to do?");

            do
            {
                switch (menu.Show())
                {
                    case "1":
                        MenuViewInformation();
                        break;
                    case "2":
                        MenuSearchVehicles();
                        break;
                    case "3":
                        MenuCheckInVehicle();
                        break;
                    case "4":
                        MenuCheckOutVehicle();
                        break;
                    case "0":
                        exit = ConfirmExit();
                        break;
                }
            }
            while (!exit);

        }

        private static void MenuViewInformation()
        {
            Dictionary<string, string> menuItems = new Dictionary<string, string>();
            Dictionary<string, Vehicle> vehicles = new Dictionary<string, Vehicle>();

            int noVehicle = -1;
            foreach (Vehicle vehicle in GarageLogic.Vehicles())
            {
                menuItems.Add(noVehicle.ToString(), vehicle.ToString());
                vehicles.Add(noVehicle.ToString(), vehicle);

                noVehicle -= 1;
            }

            noVehicle -= 1;
            menuItems.Add(noVehicle.ToString(), string.Empty);
            menuItems.Add("0", "Exit.");

            new Menu(menuItems, "Vehicles currently parked in the garage:").Show();
        }

        #region Searching for vehicles

        private static void MenuSearchVehicles()
        {
            bool exit = false;

            Menu menu = new Menu(new Dictionary<string, string> { { "1", "Registration number." },
                                                                  { "2", "Type of vehicle." },
                                                                  { "3", "Parking date."},
                                                                  { "0", "Exit."},},
                                 "Do you want to search by:");

            do
            {
                switch (menu.Show())
                {
                    case "1":
                        SearchByRegistrationNumber();
                        break;
                    case "2":
                        SearchByVehicleType();
                        break;
                    case "3":
                        SearchByParkingDate();
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }

        private static void SearchByRegistrationNumber()
        {
            throw new NotImplementedException();
        }

        private static void SearchByVehicleType()
        {
            throw new NotImplementedException();
        }

        private static void SearchByParkingDate()
        {
            throw new NotImplementedException();
        }

        #endregion

        private static void MenuCheckInVehicle()
        {
            throw new NotImplementedException();
        }

        private static void MenuCheckOutVehicle()
        {
            throw new NotImplementedException();
        }

        private static bool ConfirmExit()
        {
            return (new Menu(new Dictionary<string, string> { { "Y", "Yes." }, 
                                                              { "N", "No." } },
                             "Are you sure you want to exit?")
                             .Show()
                             .ToUpper() == "Y");
        }


    }
}
