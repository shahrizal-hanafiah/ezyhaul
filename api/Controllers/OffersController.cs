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

        [HttpGet("{id}",Name ="GetOffer")]
        public async Task<ActionResult> GetOffer()
        {
            var offers = await _offerService.GetOffers();
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

            var result = await _offerService.AddOffer(offer);

            if(result!=null) return new CreatedResult("GetOffer",new { id = result.Id});

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

        [HttpDelete]
        public async Task<ActionResult> DeletOffer(Guid id)
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