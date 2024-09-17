using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class Airport
    {

        public List<AerialVehicle> Vehicles;
        public int MaxVehicles;
        public string AirportCode { get; protected set; }

        public Airport(string Code) : this(Code, 5)
        {
            //Default to 5 vehicles   
        }

        public Airport(string Code, int MaxVehicles)
        {
            this.AirportCode = Code;
            this.Vehicles = new List<AerialVehicle>();
            this.MaxVehicles = MaxVehicles;
        }

        public string Land(AerialVehicle a)
        {
            if (this.Vehicles.Count < this.MaxVehicles)
            {
                this.Vehicles.Add(a);
                
                if (a.CurrentAltitude > 0)
                {
                    a.FlyDown(a.CurrentAltitude);
                }
                return string.Format("{0} lands at {1}", a, this.AirportCode);
            }
            return string.Format("{0} is full can't land here", this.AirportCode);
        }

        public string TakeOff(AerialVehicle a)
        {
            this.Vehicles.Remove(a);
            return a.TakeOff() + " from " + this.AirportCode;
        }

        public string AllTakeOff()
        {
            string allTakeOff = string.Empty;
            for (int i = 0; i < this.Vehicles.Count; i++)
            {
                allTakeOff += this.TakeOff(this.Vehicles[i]);
            }
            //foreach(AerialVehicle av in this.Vehicles)
            //{
            //    allTakeOff += this.TakeOff(av);
            //}
            return allTakeOff;

        }

        public string Land(List<AerialVehicle> landing)
        {
            string stringLand = string.Empty;
            foreach(AerialVehicle av in landing)
            {
                stringLand += this.Land(av);   
            }

            return stringLand;
        }

    }
}
