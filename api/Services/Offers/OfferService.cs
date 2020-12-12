using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Context;
using api.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Enums;

namespace api.Services {
    public class OfferService : IOfferService
    {
        private readonly MyContext _context;

        public OfferService(MyContext myContext) {
            _context = myContext;
        }

        public async Task<bool> AddOffer(AddOfferViewModel offer)
        {
            
            var newOffer = new Offer()
            {
                Id = Guid.NewGuid(),
                ShipmentNumber = await GenerateRunningNo(),
                Currency = offer.Currency,
                DeliveryDateTime = offer.DeliveryDateTime,
                DeliveryLocationName = offer.DeliveryLocationName,
                LoadDetail1 = offer.LoadDetail1,
                LoadDetail2 = offer.LoadDetail2,
                LoadDetail3 = offer.LoadDetail3,
                PickupDateTime = offer.PickupDateTime,
                PickupLocationName = offer.PickupLocationName,
                Price = offer.Price,
                VehicleBuildUp = offer.VehicleBuildUp,
                VehicleSize = offer.VehicleSize
            };

            _context.Add(newOffer);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOffer(Offer offer)
        {            
            if(offer != null) _context.Offers.Remove(offer); 

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Offer> GetOffer(Guid id)
        {
             var offer = await _context.Offers.SingleOrDefaultAsync(x=>x.Id == id);

            return offer;
        }

        public async Task<IEnumerable<OfferViewModel>> GetOffers()
        {
            var offers = await _context.Offers.Select(o => new OfferViewModel() {
                Id = o.Id,
                ShipmentNumber = o.ShipmentNumber,
                Currency = o.Currency,
                DeliveryDateTime = o.DeliveryDateTime,
                DeliveryLocationName = o.DeliveryLocationName,
                LoadDetail1 = o.LoadDetail1,
                LoadDetail2 = o.LoadDetail2,
                LoadDetail3 = o.LoadDetail3,
                PickupDateTime = o.PickupDateTime,
                PickupLocationName = o.PickupLocationName,
                Price = o.Price,
                VehicleBuildUp = o.VehicleBuildUp,
                VehicleSize = o.VehicleSize
            }).ToListAsync();

            return offers;
        }

        public async Task<bool> UpdateOffer(OfferViewModel offer)
        {

            var updateOffer = new Offer()
            {
                ShipmentNumber = offer.ShipmentNumber,
                Currency = offer.Currency,
                DeliveryDateTime = offer.DeliveryDateTime,
                DeliveryLocationName = offer.DeliveryLocationName,
                LoadDetail1 = offer.LoadDetail1,
                LoadDetail2 = offer.LoadDetail2,
                LoadDetail3 = offer.LoadDetail3,
                PickupDateTime = offer.PickupDateTime,
                PickupLocationName = offer.PickupLocationName,
                Price = offer.Price,
                VehicleBuildUp = offer.VehicleBuildUp,
                VehicleSize = offer.VehicleSize
            };

            _context.Entry(updateOffer).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> GenerateRunningNo(){

            var runningNo = await _context.Offers.MaxAsync(x=>x.ShipmentNumber);
            
            var currentNo = $"S{DateTime.UtcNow.ToString("YYMMDD")}-{Convert.ToInt32(runningNo.Split("-",4)) + 1}";

            return currentNo;

            // var runningNo = await _context.RunningNo.FirstOrDefaultAsync(x=>x.Type == RunningNoType.SHIPMENTNUMBER.ToString());

            // if(runningNo==null){

            //     if(await AddRunningNo()) return $"S{runningNo.TodayDate.ToString("YYMMDD")}-";

            // }
        }

        // private async Task<bool> AddRunningNo(){
        //     var newShipmentRunningNo = new RunningNo
        //     {
        //         Id = Guid.NewGuid(),
        //         Type = RunningNoType.SHIPMENTNUMBER.ToString(),
        //         TodayDate = DateTime.UtcNow,
        //         referenceNo = 1
        //     };

        //     await _context.RunningNo.AddAsync(newShipmentRunningNo);

        //     return await _context.SaveChangesAsync() > 0;
        // }
    }
}