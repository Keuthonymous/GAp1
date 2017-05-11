using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;

namespace GroupAssignmentpart1
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private List<T> garage = new List<T>();
        private int availablePlace = 0;

        internal void Add(T vehicle)
        {
            garage.Add(vehicle);
            vehicle.PTime = DateTime.Now.Date;
            vehicle.PSpot = availablePlace;
            availablePlace += 1;
        }

        internal bool Remove(T vehicle)
        {
            return garage.Remove(vehicle);
        }

        internal T SearchByLiPlate(string liPlate)
        {
            return (from v in garage
                    where v.LiPlate == liPlate
                    orderby v.LiPlate
                    select v).FirstOrDefault();
        }

        internal IEnumerable<T> SearchByVehicleType(string brand, string model)
        {
            var query = from v in garage
                        where string.Compare(v.Brand, brand, true) == 0 && string.Compare(v.Model, model, true) == 0
                        orderby v.LiPlate
                        select v;
            return query;
        }

        internal IEnumerable<T> SearchByParkingDate(DateTime date, bool before)
        {
            if (before)
                return garage.Where(t => t.PTime <= date);
            else
                return garage.Where(t => t.PTime >= date);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return garage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public List<T> Vehicles
        {
            get { return garage; }
            private set { }
        }

        #region Serialization management

        private string SerializationPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vehicles.xml");
        }

        public void Save()
        {
            XElement root = new XElement("Root");
            foreach (T t in garage)
            {
                root.Add(t.Serialize());
            }

            XDocument doc = new XDocument(root);
            doc.Save(SerializationPath());
        }

        public void Load()
        {
            // Checking that the xml file currently exists
            string strPath = SerializationPath();

            if (!File.Exists(strPath))
                return;

            XElement elements = XElement.Load(strPath);
            IEnumerable<XElement> childElements =
                from el in elements.Elements()
                select el;
            foreach (XElement el in elements.Elements())
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                t.Deserialize(el);
                garage.Add(t);
                Console.WriteLine("Name: " + el.Name);
            }
        }

        #endregion
    }
}
