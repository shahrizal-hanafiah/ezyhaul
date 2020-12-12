using System;

namespace api.Models {

    public class Offer {
        public Guid Id { get; set; }
        public string ShipmentNumber { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string VehicleSize { get; set; }
        public string VehicleBuildUp { get; set; }
        public string PickupLocationName { get; set; }
        public long PickupDateTime { get; set; }
        public string DeliveryLocationName { get; set; }
        public long DeliveryDateTime { get; set; }
        public string LoadDetail1 { get; set; }
        public string LoadDetail2 { get; set; }
        public string LoadDetail3 { get; set; }
        
    }

}