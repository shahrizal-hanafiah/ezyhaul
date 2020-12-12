using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Context;
using api.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Enums;
using System.Globalization;

namespace api.Services {
    public class OfferService : IOfferService
    {
        private readonly object addLock = new object();
        private readonly MyContext _context;

        public OfferService(MyContext myContext) {
            _context = myContext;
        }

        public async Task<Offer> AddOffer(AddOfferViewModel offer)
        {
            var newOffer = new Offer()
            {
                Id = Guid.NewGuid(),
                ShipmentNumber = GenerateRunningNo(),
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

            if (await _context.SaveChangesAsync() > 0) return newOffer;

            return null;
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

        public async Task<bool> UpdateOffer(OfferViewModel offer,Offer existingOffer)
        {

            existingOffer.ShipmentNumber = offer.ShipmentNumber;
            existingOffer.Currency = offer.Currency;
            existingOffer.DeliveryDateTime = offer.DeliveryDateTime;
            existingOffer.DeliveryLocationName = offer.DeliveryLocationName;
            existingOffer.LoadDetail1 = offer.LoadDetail1;
            existingOffer.LoadDetail2 = offer.LoadDetail2;
            existingOffer.LoadDetail3 = offer.LoadDetail3;
            existingOffer.PickupDateTime = offer.PickupDateTime;
            existingOffer.PickupLocationName = offer.PickupLocationName;
            existingOffer.Price = offer.Price;
            existingOffer.VehicleBuildUp = offer.VehicleBuildUp;
            existingOffer.VehicleSize = offer.VehicleSize;

            _context.Entry(existingOffer).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        private string GenerateRunningNo(){

            var newRunningNo = "";

            var runningNo = _context.Offers.Max(x=>x.ShipmentNumber);

            if (!string.IsNullOrEmpty(runningNo))
            {
                string[] splitRunningNo = runningNo.Split("-", 2);

                string dtRunningNo = splitRunningNo[0].Replace("S","");

                newRunningNo = splitRunningNo[1];

                if(!dtRunningNo.Equals(DateTime.UtcNow.ToString("yyMMdd"))) newRunningNo = "0";
            }
            
            var currentNo = $"S{DateTime.UtcNow.ToString("yyMMdd")}-{(Convert.ToInt32(newRunningNo) + 1).ToString().PadLeft(4,'0')}";

            return currentNo;

        }

    }
}