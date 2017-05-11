using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Vehicle : IEquatable<Vehicle>
    {
        //License plate number
        //Color
        //Brand/model
        //Engine type
        //Amount of Wheels
        //Fuel type
        //Transmition
        //Amount of doors
        //fee
        //Parking spot
        //Parking time

        #region PrivateVariables
        private string liPlate;
        private string color;
        private string brand;
        private string model;
        private string engineType;
        private int numOfWheels;
        private string fuelType;
        private string transmition;
        private int numOfDoors;
        private double fee;
        private int pSpot;
        private DateTime pTime;

        #endregion
        
        #region PublicProperties
        
        public string LiPlate
        {
            get { return liPlate; }
            set { liPlate = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public string EngineType
        {
            get { return engineType; }
            set { engineType = value; }
        }
        
        public int NumOfWheels
        {
            get { return numOfWheels; }
            set { numOfWheels = value; }
        }
        
        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }
        
        public string Transmition
        {
            get { return transmition; }
            set { transmition = value; }
        }
        
        public int NumOfDoors
        {
            get { return numOfDoors; }
            set { numOfDoors = value; }
        }
        
        public double Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        
        public int PSpot
        {
            get { return pSpot; }
            set { pSpot = value; }
        }
        
        public DateTime PTime
        {
            get { return pTime; }
            set { pTime = value; }
        }

        #endregion
        
        #region Constructor
        
        public Vehicle(string liPlate, string color, string brand, string model, string engineType, int numOfWheels, string fuelType, string transmition, int numOfDoors, double fee)
        {
            this.liPlate = liPlate;
            this.color = color;
            this.brand = brand;
            this.model = model;
            this.engineType = engineType;
            this.numOfWheels = numOfWheels;
            this.fuelType = fuelType;
            this.transmition = transmition;
            this.numOfDoors = numOfDoors;
            this.fee = fee;
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Join(Constants.MENU_ITEMS_SEPARATOR.ToString(),
                                new string[]{color,
                                brand,
                                model,
                                liPlate,
                                engineType,
                                transmition,
                                numOfDoors.ToString(),
                                numOfWheels.ToString(),
                                fuelType,
                                pTime.ToString()});
        }

        public bool Equals(Vehicle other)
        {
            if (other == null) return false;
            return (this.liPlate.Equals(other.liPlate));
        }
        
        #endregion
    }
}
