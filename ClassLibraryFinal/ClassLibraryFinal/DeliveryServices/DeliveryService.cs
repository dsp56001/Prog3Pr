using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public abstract class DeliveryService : IDeliveryService
    {

        protected double costPerRefuel;

        public double CostPerRefuel { get => costPerRefuel; protected set => costPerRefuel = value; }


        public IShippingVehicle ShippingVehicle
        {
            get => this.shippingVehicle;
            protected set { this.shippingVehicle = value; }
        }

        protected IShippingVehicle shippingVehicle;

        public DeliveryService(IShippingVehicle vehicle)
        {
            this.ShippingVehicle = vehicle;
        }

    }
}