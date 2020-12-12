using System;
using Newtonsoft.Json;

namespace api.ViewModels {
    public class OfferViewModel {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("shipmentNumber")]
        public string ShipmentNumber { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("vehicleSize")]
        public string VehicleSize { get; set; }
        [JsonProperty("vehicleBuildUp")]
        public string VehicleBuildUp { get; set; }
        [JsonProperty("pickupLocationName")]
        public string PickupLocationName { get; set; }
        [JsonProperty("pickupDateTime")]
        public long PickupDateTime { get; set; }
        [JsonProperty("deliveryLocationName")]
        public string DeliveryLocationName { get; set; }
        [JsonProperty("deliveryDateTime")]
        public long DeliveryDateTime { get; set; }
        [JsonProperty("loadDetail1")]
        public string LoadDetail1 { get; set; }
        [JsonProperty("loadDetail2")]
        public string LoadDetail2 { get; set; }
        [JsonProperty("loadDetail3")]
        public string LoadDetail3 { get; set; }

    }
        public class AddOfferViewModel {
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("vehicleSize")]
        public string VehicleSize { get; set; }
        [JsonProperty("vehicleBuildUp")]
        public string VehicleBuildUp { get; set; }
        [JsonProperty("pickupLocationName")]
        public string PickupLocationName { get; set; }
        [JsonProperty("pickupDateTime")]
        public long PickupDateTime { get; set; }
        [JsonProperty("deliveryLocationName")]
        public string DeliveryLocationName { get; set; }
        [JsonProperty("deliveryDateTime")]
        public long DeliveryDateTime { get; set; }
        [JsonProperty("loadDetail1")]
        public string LoadDetail1 { get; set; }
        [JsonProperty("loadDetail2")]
        public string LoadDetail2 { get; set; }
        [JsonProperty("loadDetail3")]
        public string LoadDetail3 { get; set; }

    }
}