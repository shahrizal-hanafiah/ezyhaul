using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.ViewModels;

namespace api.Services {
    public interface IOfferService {
        Task<Offer> GetOffer(Guid id);
        Task<Offer> GetOfferByShipmentNumber(string shipmentNumber);
        Task<IEnumerable<OfferViewModel>> GetOffers();
        Task<Offer> AddOffer(AddOfferViewModel offer);
        Task<bool> UpdateOffer(OfferViewModel offer,Offer existingOffer);
        Task<bool> DeleteOffer(Offer offer);
    }
}