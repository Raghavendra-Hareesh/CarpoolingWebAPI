using CarpoolingWebAPI.ViewModels;
using CarPoolingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolingWebAPI.Services
{
    public interface IBookingServices
    {
        public IEnumerable<Ride> FilterRides(RideRequest filterARideRequest);

        public string BookRide(BookingRequest bookARideRequest, Ride ride);
    }
}
