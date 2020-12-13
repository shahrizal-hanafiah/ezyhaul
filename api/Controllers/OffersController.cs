using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Services;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api
{

    [Route("api/offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private static readonly IList<string> _vehicleSize = new List<string> { "1TON", "3TON", "5TON", "10TON" };
        private static readonly IList<string> _vehicleBuildUp = new List<string> { "Hardbox truck", "Canvas truck", "Open truck" };
        private static readonly IList<string> _states = new List<string> { "Johor","Kedah","Kelantan","Melaka","Negeri Sembilan","Pahang","Perak","Perlis","Pulau Pinang","Selangor","Terengganu","W.P. Kuala Lumpur","W.P. Putrajaya"};
        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet("shipmentNumber/{shipmentNumber}",Name ="GetOfferByShipNumber")]
        public async Task<ActionResult> GetOfferByShipmentNumber(string shipmentNumber)
        {
            var offers = await _offerService.GetOfferByShipmentNumber(shipmentNumber);
            return new OkObjectResult(offers);
        }

        [HttpGet]
        public async Task<ActionResult> GetOffers()
        {
            var offers = await _offerService.GetOffers();
            return new OkObjectResult(offers);
        }

        [HttpPost]
        public async Task<ActionResult> AddOffer(AddOfferViewModel offer)
        {

            if (offer.PickupDateTime >= offer.DeliveryDateTime)
                return new BadRequestObjectResult("Pickup date time should be earlier than delivery date time");

            if (!_vehicleSize.Contains(offer.VehicleSize))
                return new BadRequestObjectResult("Vehicle size only accept 1TON, 3TON, 5TON or 10TON");

            if (!_vehicleBuildUp.Contains(offer.VehicleBuildUp))
                return new BadRequestObjectResult("Vehicle build up only accept Hardbox truck, Canvas truck or Open truck");

            if(!_states.Contains(offer.PickupLocationName))
                return new BadRequestObjectResult("Pickup location only allow states in Peninsula Malaysia");

            if (!_states.Contains(offer.DeliveryLocationName))
                return new BadRequestObjectResult("Delivery location only allow states in Peninsula Malaysia");

            var result = await _offerService.AddOffer(offer);

            if(result!=null) return new CreatedAtRouteResult("GetOfferByShipNumber",new { shipmentNumber = result.ShipmentNumber});

            return new BadRequestObjectResult("Problem adding the offer");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOffer(OfferViewModel offer)
        {

            if (offer.PickupDateTime >= offer.DeliveryDateTime)
                return new BadRequestObjectResult("Pickup date time should be earlier than delivery date time");

            var existingOffer = await _offerService.GetOffer(offer.Id);

            if (offer == null)
                return new NotFoundObjectResult("No offer found to update");

            var result = await _offerService.UpdateOffer(offer, existingOffer);

            if(result) return new AcceptedResult();

            return new BadRequestObjectResult("Problem updating the offer");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOffer(Guid id)
        {

            var offer = await _offerService.GetOffer(id);

            if (offer == null)
                return new NotFoundObjectResult("No offer found");

            var result = await _offerService.DeleteOffer(offer);

            if(result) return new AcceptedResult();

            return new BadRequestObjectResult("Problem deleting the offer");
        }

    }
}