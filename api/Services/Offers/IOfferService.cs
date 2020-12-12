using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using api.ViewModels;

namespace api.Services {
    public interface IOfferService {
        Task<Offer> GetOffer(Guid id);
        Task<IEnumerable<OfferViewModel>> GetOffers();
        Task<bool> AddOffer(AddOfferViewModel offer);
        Task<bool> UpdateOffer(OfferViewModel offer);
        Task<bool> DeleteOffer(Offer offer);
    }
}