using System;
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
        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
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

            var result = await _offerService.AddOffer(offer);

            if(result) return new NoContentResult();

            return new BadRequestObjectResult("Problem adding offer");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOffer(OfferViewModel offer)
        {

            if (offer.PickupDateTime >= offer.DeliveryDateTime)
                return new BadRequestObjectResult("Pickup date time should be earlier than delivery date time");

            var result = await _offerService.UpdateOffer(offer);

            if(result) return new NoContentResult();

            return new BadRequestObjectResult("Problem adding offer");
        }

        [HttpDelete]
        public async Task<ActionResult> DeletOffer(Guid id)
        {

            var offer = await _offerService.GetOffer(id);

            if (offer == null)
                return new NotFoundObjectResult("No offer found");

            var result = await _offerService.DeleteOffer(offer);

            if(result) return new NoContentResult();

            return new BadRequestObjectResult("Problem deleting offer");
        }

    }
}