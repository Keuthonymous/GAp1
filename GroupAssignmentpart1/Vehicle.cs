using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public Vehicle()
        {
        }

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

        public bool Equals(Vehicle other)
        {
            if (other == null) return false;
            return (this.liPlate.Equals(other.liPlate));
        }

        #endregion

        #region Serialization management

        public XElement Serialize()
        {
            XElement element = new XElement("Vehicle",
                new XElement("LicencePlate", liPlate),
                new XElement("Color", color),
                new XElement("Brand", brand),
                new XElement("Model", model),
                new XElement("EngineType", engineType),
                new XElement("NumberOfWheels", numOfWheels.ToString()),
                new XElement("FuelType", fuelType),
                new XElement("Transmition", transmition),
                new XElement("NumberOfDoors", numOfDoors.ToString()),
                new XElement("Fee", fee.ToString()));

            return element;
        }

        public void Deserialize(XElement element)
        {
//            element = element.Element("Vehicle");

            liPlate = (string)element.Element("LicencePlate");
            color = (string)element.Element("Color");
            brand = (string)element.Element("Brand");
            model = (string)element.Element("Model");
            engineType = (string)element.Element("EngineType");
            numOfWheels = 0;
            int.TryParse((string)element.Element("NumberOfWheels"), out numOfWheels);
            fuelType = (string)element.Element("FuelType");
            transmition = (string)element.Element("Transmition");
            numOfDoors = 0;
            int.TryParse((string)element.Element("NumberOfDoors"), out numOfDoors);
            fee = (double)element.Element("Fee");
        }

        #endregion
    }
}
