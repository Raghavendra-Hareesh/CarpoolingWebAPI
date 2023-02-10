using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;

namespace CarpoolingWebAPI.Interfaces
{
    public interface IOfferServices
    {
        public Ride OfferRide(OfferRequest availableRides);
    }
}
